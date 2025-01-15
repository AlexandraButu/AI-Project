using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIA
{
    public class GameState
    {
        public List<Character> AllCharacters { get; set; }
        public List<Character> remainingCharacters { get; set; }
        public List<string> AvailableQuestions { get; set; }
        public List<string> AskedQuestions { get; set; }
        public Character SelectedCharacter { get; set; }

        public GameState(List<Character> characters, List<string> questions)
        {
            AllCharacters = new List<Character>(characters);
            remainingCharacters = new List<Character>(characters);
            AvailableQuestions = new List<string>(questions);
            AskedQuestions = new List<string>();
        }

        public void RemoveQuestion(string question)
        {
            // Verifica daca intrebarea se afla in lista de intrebari disponibile
            if (AvailableQuestions.Contains(question))
            { // Elimina intrebarea din lista intrebarilor disponibile
                AvailableQuestions.Remove(question);
                // Adauga intrebarea eliminata in lista de intrebari deja adresate
                AskedQuestions.Add(question);
            }
        }

        public void UpdateRemainingCharacters(string question, bool answer)
        {
            // Filtreaza personajele ramase pastrand doar cele care corespund raspunsului la intrebare
            remainingCharacters = remainingCharacters.Where(character => character.CharacterMatchesQuestion(question) == answer).ToList();
        }

        public void Reset(List<Character> characters, List<string> questions)
        {
            AllCharacters = new List<Character>(characters);
            remainingCharacters = new List<Character>(characters);
            AvailableQuestions = new List<string>(questions);
            AskedQuestions.Clear();
        }

        public bool IsGameOver()
        {
            return remainingCharacters.Count <= 1;
        }
    }

}
