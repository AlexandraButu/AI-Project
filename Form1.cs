namespace ProiectIA
{
    public partial class Form1 : Form
    {
        private Character? playerTargetCharacter;


        private GameState? gameStatePlayer; 
        private GameState? gameStateComputer; 
        private MCTS? mcts;
        private bool isComputerTurn = false;

        private List<Character> characters = new List<Character>();
        private System.Windows.Forms.Timer statusTimer = new System.Windows.Forms.Timer();
        private Queue<string> statusQueue = new Queue<string>();


        public Form1()
        {
            InitializeComponent();

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            gameStatePlayer = new GameState(new List<Character>(), new List<string>());
            gameStateComputer = new GameState(new List<Character>(), new List<string>());

            InitializeStatusTimer();
        }


        private void StartJocNou()
        {
            characters = new List<Character>
            {
                new Character("Alex", "M", "Negru", true, true, false, "Tanăr", "Images/alex.png"),
                new Character("Carol", "F", "Blond", false, false, false, "Senior", "Images/carol.png"),
                new Character("Daniel", "M", "Castaniu", false, false, true, "Senior", "Images/daniel.png"),
                new Character("David", "M", "Negru", false, true, true, "Matur", "Images/david.png"),
                new Character("Dorothy", "F", "Negru", false, true, false, "Tanar", "Images/dorothy.png"),
                new Character("Evelyn", "F", "Negru", true, false, false, "Tanar", "Images/evelyn.png"),
                new Character("Karen", "F", "Negru", false, true, false, "Tanar", "Images/karen.png"),
                new Character("Mary", "F", "Blond", false, true, false, "Tanar", "Images/mary.png"),
                new Character("Michael", "M", "Negru", true, false, true, "Tanar", "Images/michael.png"),
                new Character("Olivia", "F", "Negru", false, false, false, "Matur", "Images/olivia.png"),
                new Character("Joseph", "M", "Blond", true, true, false, "Tanar", "Images/joseph.png"),
                new Character("Sarah", "F", "Castaniu", false, false, false, "Tanar", "Images/sarah.png")
            };

            List<string> questions = new List<string>
            {
                "Personajul are par blond?",
                "Personajul are par negru?",
                "Personajul are par castaniu?",
                "Personajul are barba sau mustata?",
                "Personajul este femeie?",
                "Personajul este barbat?",
                "Personajul are palarie?",
                "Personajul este tanar?",
                "Personajul este matur?",
                "Personajul este senior?",
                "Personajul poartă ochelari?",
            };

            gameStatePlayer = new GameState(characters, questions);
            gameStateComputer = new GameState(characters, questions);

            Random random = new Random();

            gameStateComputer.SelectedCharacter = characters[random.Next(characters.Count)];

            LoadCharactersIntoGrid();

            UpdateComboBoxQuestions();

            mcts = new MCTS(gameStateComputer, (int)numericUpDown1.Value);

            labelStatus.Text = "Selectati un personaj din grid pentru a incepe jocul!";
            dataGridView1.Enabled = true;
            yesButton.Enabled = false;
            noButton.Enabled = false;
            comboBoxIntrebari.Enabled = false;
            isComputerTurn = false;
        }


        private void InitializeStatusTimer()
        {
            statusTimer.Interval = 1000; // 2 secunde
            statusTimer.Tick += StatusTimer_Tick;
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            if (statusQueue.Count > 0)
            {
                string nextStatus = statusQueue.Dequeue();
                labelStatus.Text = nextStatus;
            }
            else
            {
                statusTimer.Stop(); 
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                e.RowIndex < gameStatePlayer?.remainingCharacters.Count) 
            {
                playerTargetCharacter = gameStatePlayer.remainingCharacters[e.RowIndex];
                gameStatePlayer.SelectedCharacter = playerTargetCharacter;

                if (playerTargetCharacter != null && System.IO.File.Exists(playerTargetCharacter.ImagePath))
                {
                    characterPictureBox.Image = Image.FromFile(playerTargetCharacter.ImagePath);
                }

                labelNumePersonaj.Text = playerTargetCharacter.Name;

                labelStatus.Text =
                    "Jucătorul uman și-a ales personajul! Calculatorul și-a ales personajul, jocul începe!";


                comboBoxIntrebari.Enabled = true;

                dataGridView1.Enabled = false;

                AddToStatusQueue("Este rândul tău să alegi o întrebare");

                if (!statusTimer.Enabled)
                {
                    statusTimer.Start();
                }
            }
        }

        private void ProcessQuestion(string question, bool answer, bool isPlayerQuestion)
        {
            if (!isComputerTurn && gameStatePlayer != null)
            {
                gameStatePlayer.UpdateRemainingCharacters(question, answer);
                LoadCharactersIntoGrid();
            }
            else
            {
                if (gameStateComputer == null)
                    return;
                gameStateComputer.UpdateRemainingCharacters(question, answer);
            }
        }

        private void LoadCharactersIntoGrid()
        {
            if (gameStatePlayer == null) return;

            dataGridView1.Rows.Clear();

            foreach (var character in gameStatePlayer.remainingCharacters)
            {
                dataGridView1.Rows.Add(character.Name, character.Gender, character.HairColor,
                    character.HasGlasses ? "Da" : "Nu",
                    character.WearsHat ? "Da" : "Nu",
                    character.HasBeardOrMustache ? "Da" : "Nu",
                    character.EstimatedAge);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            characterPictureBox.Image = null;

            labelStatus.Text = "Apasa 'Start Joc Nou' pentru a incepe!";
        }


        private bool GetPlayerResponse(string question)
        {
            if (playerTargetCharacter == null)
                return false; 

            return playerTargetCharacter.CharacterMatchesQuestion(question);
        }


        private void EnableAnswerButtons(string question)
        {
            yesButton.Tag = question;
            noButton.Tag = question; 

            yesButton.Enabled = true;
            noButton.Enabled = true;
            comboBoxIntrebari.Enabled = false;

        }


        private void ComputerTurn()
        {
            if (gameStateComputer == null || mcts == null || gameStatePlayer.SelectedCharacter == null) return;

            isComputerTurn = true;

            string bestQuestion = mcts.SelectBestQuestion();

            if (!string.IsNullOrEmpty(bestQuestion))
            {
                EnableAnswerButtons(bestQuestion);
                gameStateComputer.RemoveQuestion(bestQuestion);
                AddToStatusQueue($"Calculatorul intreaba: {bestQuestion}");
            }
            else
            {
                AddToStatusQueue("Calculatorul nu stie ce sa intrebe.");
                EndComputerTurn(); 
            }
        }


        private void ResetGame()
        {
            dataGridView1.Rows.Clear();
            comboBoxIntrebari.Items.Clear();
            characterPictureBox.Image = null;

            labelNumePersonaj.Text = "";

            mcts = null;
            gameStatePlayer = null;
            gameStatePlayer = null;

            labelStatus.Text = "Apasă 'Start Joc Nou' pentru a începe!";
            comboBoxIntrebari.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private bool CheckGameOver()
        {
            if (gameState.RemainingCharacters.Count == 1 && playerTargetCharacter != null)
            {
                var remainingCharacter = gameState.RemainingCharacters.First();
                if (remainingCharacter.Name == playerTargetCharacter.Name)
                {
                    MessageBox.Show("Calculatorul a câștigat! Personajul tău a fost ghicit.", "Joc Terminat");
                    labelStatus.Text = $"Joc încheiat! Câștigătorul este: Calculatorul. Personajul tău a fost: {playerTargetCharacter.Name}.";
                    return true;
                }
            }

            if (gameState.RemainingCharacters.Count == 1 && computerTargetCharacter != null)
            {
                var remainingCharacter = gameState.RemainingCharacters.First();
                if (remainingCharacter.Name == computerTargetCharacter.Name)
                {
                    MessageBox.Show("Ai câștigat! Ai ghicit personajul calculatorului.", "Joc Terminat");
                    labelStatus.Text = $"Joc încheiat! Câștigătorul este: Jucătorul uman. Personajul calculatorului a fost: {computerTargetCharacter.Name}.";
                    return true;
                }
            }

            if (gameState.RemainingCharacters.Count == 0)
            {
                MessageBox.Show("Joc încheiat! Nu au mai rămas personaje în lista de joc.", "Joc Terminat");
                labelStatus.Text = "Joc încheiat! Nu au mai rămas personaje în lista.";
                return true;
            }

            return false;
        }


        private void UpdateComboBoxQuestions()
        {
            comboBoxIntrebari.Items.Clear();
            foreach (var question in gameState.AvailableQuestions)
            {
                comboBoxIntrebari.Items.Add(question);
            }
            comboBoxIntrebari.SelectedIndex = -1;
        }


        private void yesButton_Click(object sender, EventArgs e)
        {
            string question = yesButton.Tag.ToString();

            bool isAnswerCorrect = CharacterMatchesQuestion(playerTargetCharacter, question);

            ProcessQuestion(question, isAnswerCorrect);

            int charactersEliminated = gameState.RemainingCharacters.Count;

            if (isAnswerCorrect)
            {
                labelStatus.Text = $"Întrebarea a fost bună, s-au eliminat {charactersEliminated} personaje din grilă.";
            }
            else
            {
                labelStatus.Text = "Întrebarea nu a fost bună, nu s-a eliminat niciun personaj.";
            }

            yesButton.Enabled = false;
            noButton.Enabled = false;

            if (CheckGameOver()) return;

            AddToStatusQueue("Jucătorul uman trebuie să aleagă o întrebare.");
        }



        private void noButton_Click(object sender, EventArgs e)
        {
            string question = noButton.Tag.ToString();

            bool isAnswerCorrect = !CharacterMatchesQuestion(playerTargetCharacter, question);

            ProcessQuestion(question, isAnswerCorrect);

            int charactersEliminated = gameState.RemainingCharacters.Count;

            if (isAnswerCorrect)
            {
                labelStatus.Text = $"Întrebarea a fost bună, s-au eliminat {charactersEliminated} personaje din grilă.";
            }
            else
            {
                labelStatus.Text = "Întrebarea nu a fost bună, nu s-a eliminat niciun personaj.";
            }

            yesButton.Enabled = false;
            noButton.Enabled = false;

            if (CheckGameOver()) return;


            AddToStatusQueue("Jucătorul uman trebuie să aleagă o întrebare.");
        }




        private void startJocNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartJocNou();
        }


        private void labelStatus_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxIntrebari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIntrebari.SelectedItem == null || computerTargetCharacter == null)
            {
                MessageBox.Show("Vă rugăm să selectați o întrebare validă.", "Eroare");
                return;
            }

            string selectedQuestion = comboBoxIntrebari.SelectedItem.ToString();
            labelStatus.Text = $"Jucătorul a selectat întrebarea: {selectedQuestion}";

            bool isAnswerCorrect = CharacterMatchesQuestion(computerTargetCharacter, selectedQuestion);

            int charactersBefore = gameState.RemainingCharacters.Count;

            ProcessQuestion(selectedQuestion, isAnswerCorrect);

            int charactersAfter = gameState.RemainingCharacters.Count;
            int charactersEliminated = charactersBefore - charactersAfter;

            if (isAnswerCorrect)
            {
                AddToStatusQueue($"Întrebarea a fost bună, s-au eliminat {charactersEliminated} personaje din grilă.");
            }
            else
            {
                AddToStatusQueue("Întrebarea nu a fost bună, nu s-a eliminat niciun personaj.");
            }

            gameState.RemoveQuestion(selectedQuestion);
            UpdateComboBoxQuestions();

            if (CheckGameOver()) return;

            AddToStatusQueue("Calculatorul a ales întrebarea.");
            statusTimer.Tick += (s, ev) => ComputerTurn();
            statusTimer.Start();
        }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetGame();
            StartJocNou();
            labelStatus.Text = "Jocul a fost resetat și un joc nou a început!";
        }


    }
}
