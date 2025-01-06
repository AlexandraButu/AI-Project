namespace ProiectIA
{
    public partial class Form1 : Form
    {
        private int playerScore = 0;
        private int computerScore = 0;
        private Character? computerTargetCharacter;
        private Character? playerTargetCharacter;

        private GameState? gameState; // Permite null
        private Character? targetCharacter; // Permite null

        private List<Character> characters = new List<Character>();
        public Form1()
        {
            InitializeComponent(); 
            gameState = new GameState(new List<Character>(), new List<string>());


        }

        //https://www.printablee.com/postpic/2013/12/hasbro-guess-who-character-sheets_214355.jpg - personaje

   
        private void StartJocNou()
        {
            //Lista de personaje
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
                new Character("Sarah", "F", "Castaniu", false, false, false, "TâTanarnăr", "Images/sarah.png")
            };

            //Lista de intrebari disponibile
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

           
            gameState = new GameState(characters, questions);

            //Selecteaza un personaj random pentru jucator
            Random random = new Random();
            targetCharacter = characters[random.Next(characters.Count)];

        
            LoadCharactersIntoGrid();

      
            if (targetCharacter != null && System.IO.File.Exists(targetCharacter.ImagePath))
            {
                characterPictureBox.Image = Image.FromFile(targetCharacter.ImagePath);
            }
            else
            {
                characterPictureBox.Image = null;
            }

         
            labelStatus.Text = "Joc nou inceput! Raspundeti la intrebari";
        }



        private void LoadCharactersIntoGrid()
        {
           
            dataGridView1.Rows.Clear();

            //Se adauga personajele in grila
            foreach (var character in characters)
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
            //DataGridView este gol la inceput
            dataGridView1.Rows.Clear();

            //PictureBox-ul este gol la inceput
            characterPictureBox.Image = null;

            //Setare status initial
            labelStatus.Text = "Apasa 'Start Joc Nou' pentru a incepe!";
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
        private void yesButton_Click(object sender, EventArgs e)
        {
        }

        private void noButton_Click(object sender, EventArgs e)
        {
          
        }


        private void startJocNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartJocNou();
        }


        private void labelStatus_Click(object sender, EventArgs e)
        {

        }


    }
}
