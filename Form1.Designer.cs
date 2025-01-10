namespace ProiectIA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Nume = new DataGridViewTextBoxColumn();
            Gen = new DataGridViewTextBoxColumn();
            CuloarePar = new DataGridViewTextBoxColumn();
            Ochelari = new DataGridViewTextBoxColumn();
            Palarie = new DataGridViewTextBoxColumn();
            BarbaMustata = new DataGridViewTextBoxColumn();
            Varsta = new DataGridViewTextBoxColumn();
            questionLabel = new Label();
            yesButton = new Button();
            noButton = new Button();
            labelMonteCarlo = new Label();
            numericUpDown1 = new NumericUpDown();
            buttonReset = new Button();
            labelStatus = new Label();
            characterPictureBox = new PictureBox();
            labelPersonaj = new Label();
            menuStrip1 = new MenuStrip();
            fisierToolStripMenuItem = new ToolStripMenuItem();
            startJocNouToolStripMenuItem = new ToolStripMenuItem();
            iesireToolStripMenuItem = new ToolStripMenuItem();
            labelPlayerScore = new Label();
            labelComputerScore = new Label();
            comboBoxIntrebari = new ComboBox();
            labelNume = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)characterPictureBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nume, Gen, CuloarePar, Ochelari, Palarie, BarbaMustata, Varsta });
            dataGridView1.Location = new Point(66, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1115, 490);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // Nume
            // 
            Nume.HeaderText = "Nume";
            Nume.MinimumWidth = 8;
            Nume.Name = "Nume";
            Nume.Width = 150;
            // 
            // Gen
            // 
            Gen.HeaderText = "Gen";
            Gen.MinimumWidth = 8;
            Gen.Name = "Gen";
            Gen.Width = 150;
            // 
            // CuloarePar
            // 
            CuloarePar.HeaderText = "Culoarea părului";
            CuloarePar.MinimumWidth = 8;
            CuloarePar.Name = "CuloarePar";
            CuloarePar.Width = 150;
            // 
            // Ochelari
            // 
            Ochelari.HeaderText = "Are ochelari";
            Ochelari.MinimumWidth = 8;
            Ochelari.Name = "Ochelari";
            Ochelari.Width = 150;
            // 
            // Palarie
            // 
            Palarie.HeaderText = "Poarta palarie";
            Palarie.MinimumWidth = 8;
            Palarie.Name = "Palarie";
            Palarie.Width = 150;
            // 
            // BarbaMustata
            // 
            BarbaMustata.HeaderText = "Are barba sau mustata";
            BarbaMustata.MinimumWidth = 8;
            BarbaMustata.Name = "BarbaMustata";
            BarbaMustata.Width = 150;
            // 
            // Varsta
            // 
            Varsta.HeaderText = "Varsta estimata";
            Varsta.MinimumWidth = 8;
            Varsta.Name = "Varsta";
            Varsta.Width = 150;
            // 
            // questionLabel
            // 
            questionLabel.AutoSize = true;
            questionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            questionLabel.Location = new Point(66, 625);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(115, 32);
            questionLabel.TabIndex = 1;
            questionLabel.Text = "Întrebare:";
            // 
            // yesButton
            // 
            yesButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            yesButton.Location = new Point(66, 734);
            yesButton.Name = "yesButton";
            yesButton.Size = new Size(122, 51);
            yesButton.TabIndex = 2;
            yesButton.Text = "Da";
            yesButton.UseVisualStyleBackColor = true;
            yesButton.Click += yesButton_Click;
            // 
            // noButton
            // 
            noButton.Font = new Font("Segoe UI", 11F);
            noButton.Location = new Point(222, 734);
            noButton.Name = "noButton";
            noButton.Size = new Size(122, 51);
            noButton.TabIndex = 3;
            noButton.Text = "Nu";
            noButton.UseVisualStyleBackColor = true;
            noButton.Click += noButton_Click;
            // 
            // labelMonteCarlo
            // 
            labelMonteCarlo.AutoSize = true;
            labelMonteCarlo.Location = new Point(1238, 78);
            labelMonteCarlo.Name = "labelMonteCarlo";
            labelMonteCarlo.Size = new Size(239, 25);
            labelMonteCarlo.TabIndex = 4;
            labelMonteCarlo.Text = "Număr simulări Monte Carlo:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(1238, 122);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(180, 31);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(1335, 825);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(142, 46);
            buttonReset.TabIndex = 6;
            buttonReset.Text = "Resetare joc";
            buttonReset.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStatus.Location = new Point(759, 627);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(75, 30);
            labelStatus.TabIndex = 7;
            labelStatus.Text = "Status:";
            labelStatus.Click += labelStatus_Click;
            // 
            // characterPictureBox
            // 
            characterPictureBox.Location = new Point(1275, 459);
            characterPictureBox.Name = "characterPictureBox";
            characterPictureBox.Size = new Size(202, 198);
            characterPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            characterPictureBox.TabIndex = 8;
            characterPictureBox.TabStop = false;
            characterPictureBox.Click += pictureBox1_Click;
            // 
            // labelPersonaj
            // 
            labelPersonaj.AutoSize = true;
            labelPersonaj.Location = new Point(1317, 408);
            labelPersonaj.Name = "labelPersonaj";
            labelPersonaj.Size = new Size(87, 25);
            labelPersonaj.TabIndex = 9;
            labelPersonaj.Text = "Personaj: ";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fisierToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1772, 33);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // fisierToolStripMenuItem
            // 
            fisierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { startJocNouToolStripMenuItem, iesireToolStripMenuItem });
            fisierToolStripMenuItem.Name = "fisierToolStripMenuItem";
            fisierToolStripMenuItem.Size = new Size(68, 29);
            fisierToolStripMenuItem.Text = "Fisier";
            // 
            // startJocNouToolStripMenuItem
            // 
            startJocNouToolStripMenuItem.Name = "startJocNouToolStripMenuItem";
            startJocNouToolStripMenuItem.Size = new Size(219, 34);
            startJocNouToolStripMenuItem.Text = "Start Joc Nou";
            startJocNouToolStripMenuItem.Click += startJocNouToolStripMenuItem_Click;
            // 
            // iesireToolStripMenuItem
            // 
            iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            iesireToolStripMenuItem.Size = new Size(219, 34);
            iesireToolStripMenuItem.Text = "Iesire";
            // 
            // labelPlayerScore
            // 
            labelPlayerScore.AutoSize = true;
            labelPlayerScore.Location = new Point(639, 720);
            labelPlayerScore.Name = "labelPlayerScore";
            labelPlayerScore.Size = new Size(106, 25);
            labelPlayerScore.TabIndex = 11;
            labelPlayerScore.Text = "Scor jucator";
            // 
            // labelComputerScore
            // 
            labelComputerScore.AutoSize = true;
            labelComputerScore.Location = new Point(817, 720);
            labelComputerScore.Name = "labelComputerScore";
            labelComputerScore.Size = new Size(127, 25);
            labelComputerScore.TabIndex = 12;
            labelComputerScore.Text = "Scor calculator";
            // 
            // comboBoxIntrebari
            // 
            comboBoxIntrebari.FormattingEnabled = true;
            comboBoxIntrebari.Location = new Point(200, 628);
            comboBoxIntrebari.Name = "comboBoxIntrebari";
            comboBoxIntrebari.Size = new Size(220, 33);
            comboBoxIntrebari.TabIndex = 14;
            // 
            // labelNume
            // 
            labelNume.AutoSize = true;
            labelNume.Location = new Point(1312, 698);
            labelNume.Name = "labelNume";
            labelNume.Size = new Size(64, 25);
            labelNume.TabIndex = 15;
            labelNume.Text = "Nume:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1772, 1140);
            Controls.Add(labelNume);
            Controls.Add(comboBoxIntrebari);
            Controls.Add(labelComputerScore);
            Controls.Add(labelPlayerScore);
            Controls.Add(labelPersonaj);
            Controls.Add(characterPictureBox);
            Controls.Add(labelStatus);
            Controls.Add(buttonReset);
            Controls.Add(numericUpDown1);
            Controls.Add(labelMonteCarlo);
            Controls.Add(noButton);
            Controls.Add(yesButton);
            Controls.Add(questionLabel);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)characterPictureBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nume;
        private DataGridViewTextBoxColumn Gen;
        private DataGridViewTextBoxColumn CuloarePar;
        private DataGridViewTextBoxColumn Ochelari;
        private DataGridViewTextBoxColumn Palarie;
        private DataGridViewTextBoxColumn BarbaMustata;
        private DataGridViewTextBoxColumn Varsta;
        private Label questionLabel;
        private Button yesButton;
        private Button noButton;
        private Label labelMonteCarlo;
        private NumericUpDown numericUpDown1;
        private Button buttonReset;
        private Label labelStatus;
        private PictureBox characterPictureBox;
        private Label labelPersonaj;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fisierToolStripMenuItem;
        private ToolStripMenuItem startJocNouToolStripMenuItem;
        private ToolStripMenuItem iesireToolStripMenuItem;
        private Label labelPlayerScore;
        private Label labelComputerScore;
        private ComboBox comboBoxIntrebari;
        private Label labelNume;
    }
}
