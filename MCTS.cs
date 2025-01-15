
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIA
{
    public class MCTS 
    {
                private GameState gameState;
        private int numberOfSimulations;
        private Random random = new Random();

        public MCTS(GameState state, int numberOfSimulations)
        {
            gameState = state;
            this.numberOfSimulations = numberOfSimulations;
        }

        public string SelectBestQuestion()
        {
            //Daca nu mai sunt intrebari disponibile return sir gol
            if (gameState.AvailableQuestions.Count == 0)
            {
                return string.Empty; 
            }

            // Creeaza nodul radacina al arborelui MCTS, folosind starea curenta a jocului
            var node = new MCTSNode(gameState);

            // Se executa un nr specificat de simulari pentru a evalua intrebarile posibile
            for (int i = 0; i < numberOfSimulations; i++)
            {
                // 1. Selectie
                // Alege cel mai promitator nod din arbore pe baza functiei UCB
                var promisingNode = SelectPromisingNode(node);

                // 2. Expansiune
                // Daca nodul promitator nu este un nod terminal (mai mult de un personaj) si mai are intrebari neutilizate,
                // extindem arborele adaugand noduri noi pentru intrebarile neexplorate
                if (promisingNode.GameState.remainingCharacters.Count > 1 && promisingNode.UntriedQuestions.Any())
                {
                    ExpandNode(promisingNode);
                }

                // 3. Simulare
                // Selecteaza un nod pentru simulare: daca exista copii neexplorati, se alege primul; altfel, se foloseste nodul promitator
                var nodeToRollout = promisingNode.Children.Any() ? promisingNode.Children.First(n => n.IsNotFullySimulated) : promisingNode;

                // Daca nodul selectat pentru simulare este un nod terminal (de exemplu, un singur personaj ramas), continuare cu urmatoarea simulare
                if (nodeToRollout.IsTerminalState) continue;
                // Ruleaza o simulare (rollout) pentru a estima rezultatul (reward-ul) asociat acestui nod
                var reward = Rollout(nodeToRollout.GameState);

                // 4. Backpropagare
                // Paropagarea rezultatului simularii (reward-ul) catre nodurile din arbore, incepand de la nodul curent
                BackPropagate(nodeToRollout, reward);
            }

            // Dupa toate simularile, se alege copilul nodului radacina cu cea mai mare rata de castig (WinRate)
            var bestChild = node.Children
                .OrderByDescending(c => c.WinRate)
                .FirstOrDefault();

            // Se returneaza intrebarea asociata copilului selectat. Daca nu exista copii, return sir gol
            return bestChild?.Question;
        }


        private MCTSNode SelectPromisingNode(MCTSNode rootNode)
        {
            MCTSNode currentNode = rootNode;
            while (currentNode.Children.Any() && !currentNode.IsNotFullySimulated)
            {
                currentNode = UCT.FindBestNodeWithUCT(currentNode);
            }
            return currentNode;
        }

        private void ExpandNode(MCTSNode node)
        {
            var question = node.UntriedQuestions.FirstOrDefault();
            if (question != null)
            {
                node.UntriedQuestions.Remove(question);

                // Simulate both possible answers to the question
                GameState gameStateIfYes = new GameState(node.GameState.remainingCharacters.ToList(), node.GameState.AvailableQuestions.ToList());
                gameStateIfYes.UpdateRemainingCharacters(question, true);
                gameStateIfYes.RemoveQuestion(question);
                node.AddChild(new MCTSNode(gameStateIfYes) { Parent = node, Question = question, Answer = true });

                GameState gameStateIfNo = new GameState(node.GameState.remainingCharacters.ToList(), node.GameState.AvailableQuestions.ToList());
                gameStateIfNo.UpdateRemainingCharacters(question, false);
                gameStateIfNo.RemoveQuestion(question);
                node.AddChild(new MCTSNode(gameStateIfNo) { Parent = node, Question = question, Answer = false });
            }
        }

        private int Rollout(GameState currentGameState)
        {
            GameState rolloutState = new GameState(currentGameState.remainingCharacters.ToList(), currentGameState.AvailableQuestions.ToList());
            Character computerCharacter = rolloutState.remainingCharacters.FirstOrDefault(); // Assume one character left if reached here due to expansion

            if (computerCharacter == null) return 0; // Should not happen

            while (rolloutState.remainingCharacters.Count > 1 && rolloutState.AvailableQuestions.Any())
            {
                string question = rolloutState.AvailableQuestions[random.Next(rolloutState.AvailableQuestions.Count)];
                bool answer = computerCharacter.CharacterMatchesQuestion(question);
                rolloutState.UpdateRemainingCharacters(question, answer);
                rolloutState.RemoveQuestion(question);
            }

            return rolloutState.remainingCharacters.Count == 1 ? 1 : 0; // Reward 1 if the simulation leads to identifying the character
        }

        private void BackPropagate(MCTSNode nodeToPropagate, int reward)
        {
            MCTSNode tempNode = nodeToPropagate;
            while (tempNode != null)
            {
                tempNode.VisitCount++;
                tempNode.WinCount += reward;
                tempNode = tempNode.Parent;
            }
        }
    }

    public class MCTSNode
    {
        public GameState GameState { get; set; }
        public MCTSNode Parent { get; set; }
        public List<MCTSNode> Children { get; set; }
        public string Question { get; set; }
        public bool? Answer { get; set; }
        public int VisitCount { get; set; }
        public int WinCount { get; set; }
        public List<string> UntriedQuestions { get; set; }

        public MCTSNode(GameState gameState)
        {
            GameState = gameState;
            Children = new List<MCTSNode>();
            VisitCount = 0;
            WinCount = 0;
            UntriedQuestions = new List<string>(gameState.AvailableQuestions);
        }

        public void AddChild(MCTSNode child)
        {
            Children.Add(child);
        }

        public double WinRate => VisitCount == 0 ? 0 : (double)WinCount / VisitCount;
        public bool IsNotFullySimulated => UntriedQuestions.Any();
        public bool IsTerminalState => GameState.IsGameOver();
    }

    public static class UCT
    {
        public static double UCBValue(MCTSNode parent, MCTSNode child)
        {
            // Daca nodul curent nu a fost explorat deloc, se intoarce o valoare infinita
            // pentru a favoriza explorarea acestuia
            if (child.VisitCount == 0)
                return double.MaxValue;

            // Calculul formulei UCB:
            // (WinCount / VisitCount) -> Exploatare: media castigurilor pentru nodul curent
            // Math.Sqrt(2 * Math.Log(parent.VisitCount) / child.VisitCount) -> Explorare: 
            // masoara cat de putin explorat este nodul curent in raport cu parintele sau
            return (double)child.WinCount / child.VisitCount +
                   Math.Sqrt(2 * Math.Log(parent.VisitCount) / child.VisitCount);
        }

        public static MCTSNode FindBestNodeWithUCT(MCTSNode node)
        {
            return node.Children.OrderByDescending(c => UCBValue(node, c)).FirstOrDefault();
        }
    }
}