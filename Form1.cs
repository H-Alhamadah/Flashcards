using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flashcards
{
    public partial class Form1 : Form
    {
        Engine engine = new Engine();
        Graphics graphics = null;
        public static int width = 800;
        public static int height = 450;
        static int staticDeckIndex = 0;
        static Boolean questionSide = true;
        Card[] deckArray = new Card[0];
        int currentIndex = 0;
        static int startDeckIndex = 0;


        //--------start screen-------------
        Button createNewDeck = new Button();
        Button openExistingDeck = new Button();
        Label newDeckLabel = new Label();
        Label existingDeckLabel = new Label();

        //-----------new Deck screen 1------------
        TextBox deckName = new TextBox();
        Button next = new Button();
        Button cancel = new Button();
        Label deckNameLabel = new Label();
        Panel deckNameBorderTop = new Panel();
        Panel deckNameBorderBottom = new Panel();
        Panel deckNameBorderLeft = new Panel();
        Panel deckNameBorderRight = new Panel();

        //----------new Deck screen 2-------------
        TextBox questionTextbox = new TextBox();
        TextBox answerTextbox = new TextBox();
        Button addCard = new Button();
        Button done = new Button();
        Label questionBoxLabel = new Label();
        Label answerBoxLabel = new Label();
        Label cardCountLabel = new Label();

        //-------open existing Deck screen--------
        Button visableDeck1 = new Button();
        Button visableDeck2 = new Button();
        Button visableDeck3 = new Button();
        Button visableDeck4 = new Button();
        Button backToStart = new Button();
        Button prevDeck = new Button();
        Button nextDeck = new Button();
        Label visableDeck1Name = new Label();
        Label visableDeck2Name = new Label();
        Label visableDeck3Name = new Label();
        Label visableDeck4Name = new Label();
        Label DeckCountLabel = new Label();
        Panel deckSelection = new Panel();


        //-------------study screen----------------
        Button prevCard = new Button();
        Button nextCard = new Button();
        Button currentCard = new Button();
        Button shuffle = new Button();
        Button reorder = new Button();
        Button backToAllDecks = new Button();
        Button edit = new Button();
        Label currentCardNumber = new Label();
        Label currentDeckName = new Label();
        Label rotate = new Label();
        Label clickToRotate = new Label();

        //-------------edit screen----------------
        TextBox editQuestion = new TextBox();
        TextBox editAnswer = new TextBox();
        TextBox renameDeckTextBox = new TextBox();
        Button renameButton = new Button();
        Button editNext = new Button();
        Button editPrev = new Button();
        Button doneEditing = new Button();
        Button deleteDeck = new Button();
        Button deleteCard = new Button();
        Button addCardEdit = new Button();
        Label editIndex = new Label();

        //--------------------edit add cards------------------
        TextBox editAddQuestionTextbox = new TextBox();
        TextBox editAddAnswerTextbox = new TextBox();
        Button editAddAddCard = new Button();
        Button editAddDone = new Button();
        Label editAddQuestionBoxLabel = new Label();
        Label editAddAnswerBoxLabel = new Label();
        Label editAddCardCountLabel = new Label();




        public Form1()
        {
            InitializeComponent();
            startScreen();


            //--------start screen-------------
            createNewDeck.Click += new System.EventHandler(this.newDeckNaming);
            openExistingDeck.Click += new System.EventHandler(this.allDecks_Event);

            //-----------new deck screen 1------------
            cancel.Click += new System.EventHandler(this.cancelNewDeck);
            next.Click += new System.EventHandler(this.nameDeck_Next);

            //----------new deck screen 2-------------
            addCard.Click += new System.EventHandler(this.addCard_Click);
            done.Click += new System.EventHandler(this.doneAddingCard);

            //-------open existing deck screen--------
            visableDeck1.Click += new System.EventHandler(this.selectedDeck);
            visableDeck2.Click += new System.EventHandler(this.selectedDeck);
            visableDeck3.Click += new System.EventHandler(this.selectedDeck);
            visableDeck4.Click += new System.EventHandler(this.selectedDeck);
            backToStart.Click += new System.EventHandler(this.backToStartEvent);
            prevDeck.Click += new System.EventHandler(this.decrementDeck);
            nextDeck.Click += new System.EventHandler(this.incrementDeck);

            //-------------study screen----------------
            prevCard.Click += new System.EventHandler(this.prevCard_Click);
            nextCard.Click += new System.EventHandler(this.nextCard_Click);
            currentCard.Click += new System.EventHandler(this.Flip);
            shuffle.Click += new System.EventHandler(this.shuffleCards);
            reorder.Click += new System.EventHandler(this.rearrangeCards);
            backToAllDecks.Click += new System.EventHandler(this.allDecks_Event);
            edit.Click += new System.EventHandler(this.editSelectedDeck);

            //-------------edit screen----------------
            renameButton.Click += new System.EventHandler(this.renameDeck);
            editNext.Click += new System.EventHandler(this.nextCardEdit);
            editPrev.Click += new System.EventHandler(this.prevCardEdit);
            doneEditing.Click += new System.EventHandler(this.doneEditing_Click);
            deleteCard.Click += new System.EventHandler(this.deleteCard_Click);
            deleteDeck.Click += new System.EventHandler(this.deleteDeck_Click);
            addCardEdit.Click += new System.EventHandler(this.addCardEdit_Click);

            //--------------------edit add cards------------------
            editAddDone.Click += new System.EventHandler(this.editAddDone_Click);
            editAddAddCard.Click += new System.EventHandler(this.editAddCard_Click);

            this.FormClosing += closing;

            graphics = Graphics.FromHwnd(Handle);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
           
           
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            graphics.Clear(Color.FromArgb(226, 240, 217));
        }

        private void closeAllContols()
        {


            //--------start screen-------------
            Controls.Remove(createNewDeck);
            Controls.Remove(openExistingDeck);
            Controls.Remove(newDeckLabel);
            Controls.Remove(existingDeckLabel);

            //-----------new deck screen 1------------
            Controls.Remove(deckName);
            Controls.Remove(next);
            Controls.Remove(cancel);
            Controls.Remove(deckNameLabel);
            Controls.Remove(deckNameBorderTop);
            Controls.Remove(deckNameBorderBottom);
            Controls.Remove(deckNameBorderLeft);
            Controls.Remove(deckNameBorderRight);

            //----------new deck screen 2-------------
            Controls.Remove(questionTextbox);
            Controls.Remove(answerTextbox);
            Controls.Remove(done);
            Controls.Remove(addCard);
            Controls.Remove(cardCountLabel);
            Controls.Remove(questionBoxLabel);
            Controls.Remove(answerBoxLabel);

            //-------open existing deck screen--------
            Controls.Remove(visableDeck1);
            Controls.Remove(visableDeck2);
            Controls.Remove(visableDeck3);
            Controls.Remove(visableDeck4);
            Controls.Remove(visableDeck1Name);
            Controls.Remove(visableDeck2Name);
            Controls.Remove(visableDeck3Name);
            Controls.Remove(visableDeck4Name);
            Controls.Remove(prevDeck);
            Controls.Remove(nextDeck);
            Controls.Remove(backToStart);
            Controls.Remove(DeckCountLabel);
            Controls.Remove(deckSelection);

            //-------------study screen----------------
            Controls.Remove(prevCard);
            Controls.Remove(nextCard);
            Controls.Remove(currentCard);
            Controls.Remove(shuffle);
            Controls.Remove(reorder);
            Controls.Remove(backToAllDecks);
            Controls.Remove(edit);
            Controls.Remove(currentDeckName);
            Controls.Remove(rotate);
            Controls.Remove(clickToRotate);
            Controls.Remove(currentCardNumber);

            //-------------edit screen----------------
            Controls.Remove(doneEditing);
            Controls.Remove(renameButton);
            Controls.Remove(editPrev);
            Controls.Remove(editNext);
            Controls.Remove(deleteCard);
            Controls.Remove(deleteDeck);
            Controls.Remove(editQuestion);
            Controls.Remove(editAnswer);
            Controls.Remove(renameDeckTextBox);
            Controls.Remove(editIndex);

            //--------------------edit add cards------------------
            Controls.Remove(editAddDone);
            Controls.Remove(editAddAddCard);
            Controls.Remove(addCardEdit);
            Controls.Remove(editAddCardCountLabel);
            Controls.Remove(editAddQuestionBoxLabel);
            Controls.Remove(editAddAnswerBoxLabel);
            Controls.Remove(editAddQuestionTextbox);
            Controls.Remove(editAddAnswerTextbox);











        }

        private void startScreen()
        {
            closeAllContols();

            createNewDeck.Size = new Size(125, 125);
            createNewDeck.Location = new System.Drawing.Point((width / 2) - createNewDeck.Width - 75, (height / 2) - (createNewDeck.Height / 2));
            createNewDeck.BackColor = Color.FromArgb(226, 240, 217);
            createNewDeck.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\PlusSignIcon.png"}");
            createNewDeck.BackgroundImageLayout = ImageLayout.Stretch;
            createNewDeck.FlatStyle = FlatStyle.Flat;
            createNewDeck.FlatAppearance.BorderSize = 0;
            createNewDeck.Cursor = Cursors.Hand;
            createNewDeck.FlatAppearance.MouseOverBackColor = createNewDeck.BackColor;


            newDeckLabel.Text = "Create New Deck";
            newDeckLabel.BackColor = Color.FromArgb(226, 240, 217);
            newDeckLabel.Location = new System.Drawing.Point((width / 2) - createNewDeck.Width - 75, createNewDeck.Location.Y + createNewDeck.Height);
            newDeckLabel.Size = new Size(125, 30);
            newDeckLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            newDeckLabel.TextAlign = ContentAlignment.MiddleCenter;

            openExistingDeck.Size = new Size(150, 110);
            openExistingDeck.Location = new System.Drawing.Point((width / 2) + 75, (height / 2) - (openExistingDeck.Height / 2));
            openExistingDeck.BackColor = Color.FromArgb(226, 240, 217);
            openExistingDeck.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\DarkDeckIcon.png"}");
            openExistingDeck.BackgroundImageLayout = ImageLayout.Stretch;
            openExistingDeck.FlatStyle = FlatStyle.Flat;
            openExistingDeck.FlatAppearance.BorderSize = 0;
            openExistingDeck.Cursor = Cursors.Hand;
            openExistingDeck.FlatAppearance.MouseOverBackColor = openExistingDeck.BackColor;

            existingDeckLabel.Text = "Open Existing Deck";
            existingDeckLabel.BackColor = Color.FromArgb(226, 240, 217);
            existingDeckLabel.Location = new System.Drawing.Point((width / 2) + 75, openExistingDeck.Location.Y + openExistingDeck.Height);
            existingDeckLabel.Size = new Size(150, 30);
            existingDeckLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            existingDeckLabel.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Add(createNewDeck);
            Controls.Add(newDeckLabel);
            Controls.Add(openExistingDeck);
            Controls.Add(existingDeckLabel);



        }
        private void newDeckNaming(object sender, EventArgs e)
        {
            closeAllContols();


            deckName.Size = new Size(400, 35);
            deckName.Location = new System.Drawing.Point((width / 2) - (deckName.Width / 2), (height / 2) - deckName.Height - 15);
            deckName.AutoSize = false;
            deckName.Font = new Font(deckName.Font.FontFamily, 16);
            deckName.BorderStyle = BorderStyle.None;


            deckNameLabel.Text = "Deck Name:";
            deckNameLabel.BackColor = Color.FromArgb(226, 240, 217);
            deckNameLabel.Location = new System.Drawing.Point(deckName.Location.X, deckName.Location.Y - deckNameLabel.Height - 5);
            deckNameLabel.Size = new Size(170, 20);
            deckNameLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            deckNameLabel.TextAlign = ContentAlignment.MiddleLeft;

            next.Text = "Next";
            next.Cursor = Cursors.Hand;
            next.BackColor = Color.FromArgb(169, 209, 142);
            next.FlatStyle = FlatStyle.Flat;
            next.FlatAppearance.BorderColor = Color.FromArgb(47, 82, 143);
            next.FlatAppearance.BorderSize = 2;
            next.Size = new Size(100, 40);
            next.Font = new Font("Arial", 10, FontStyle.Regular);
            next.Location = new System.Drawing.Point((width / 2) - (next.Width / 2), deckName.Location.Y + next.Height);


            deckNameBorderTop.Size = new Size(deckName.Width + 2, 2);
            deckNameBorderTop.Location = new System.Drawing.Point(deckName.Location.X - 2, deckName.Location.Y - 2);
            deckNameBorderTop.BackColor = Color.FromArgb(112, 173, 71);

            deckNameBorderBottom.Size = new Size(deckName.Width + 2, 2);
            deckNameBorderBottom.Location = new System.Drawing.Point(deckName.Location.X - 2, deckName.Location.Y + deckName.Height - deckNameBorderBottom.Size.Height + 2);
            deckNameBorderBottom.BackColor = Color.FromArgb(112, 173, 71);

            deckNameBorderLeft.Size = new Size(2, deckName.Height);
            deckNameBorderLeft.Location = new System.Drawing.Point(deckName.Location.X - 2, deckName.Location.Y);
            deckNameBorderLeft.BackColor = Color.FromArgb(112, 173, 71);

            deckNameBorderRight.Size = new Size(2, deckName.Height + 4);
            deckNameBorderRight.Location = new System.Drawing.Point(deckName.Location.X + deckName.Width - deckNameBorderRight.Width + 2, deckName.Location.Y - 2);
            deckNameBorderRight.BackColor = Color.FromArgb(112, 173, 71);


            cancel.Text = "Cancel";
            cancel.BackColor = Color.FromArgb(226, 240, 217);
            cancel.Size = new Size(75, 30);
            cancel.Location = new System.Drawing.Point(width - cancel.Width, height - cancel.Height);
            cancel.TextAlign = ContentAlignment.MiddleRight;
            cancel.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\cancel.png"}");
            cancel.BackgroundImageLayout = ImageLayout.Stretch;
            cancel.FlatStyle = FlatStyle.Flat;
            cancel.FlatAppearance.BorderSize = 0;
            cancel.Cursor = Cursors.Hand;
            cancel.FlatAppearance.MouseOverBackColor = cancel.BackColor;


            Controls.Add(deckNameLabel);
            Controls.Add(deckName);
            Controls.Add(next);
            Controls.Add(cancel);
            Controls.Add(deckNameBorderTop);
            Controls.Add(deckNameBorderBottom);
            Controls.Add(deckNameBorderLeft);
            Controls.Add(deckNameBorderRight);



        }
        private void newDeckAddingCards()
        {
            closeAllContols();


            questionTextbox.Size = new Size(width / 3, width / 3 + 50);
            questionTextbox.Location = new System.Drawing.Point(50, 65);
            questionTextbox.AutoSize = false;
            questionTextbox.Multiline = true;
            questionTextbox.BorderStyle = BorderStyle.None;

            answerTextbox.Size = new Size(width / 3, width / 3 + 50);
            answerTextbox.Location = new System.Drawing.Point(questionTextbox.Right + 20, 65);
            answerTextbox.AutoSize = false;
            answerTextbox.Multiline = true;
            answerTextbox.BorderStyle = BorderStyle.None;

            questionBoxLabel.Location = new System.Drawing.Point(questionTextbox.Location.X, questionTextbox.Location.Y - questionBoxLabel.Height);
            questionBoxLabel.Text = "Question:";
            questionBoxLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            questionBoxLabel.BackColor = Color.FromArgb(226, 240, 217);

            answerBoxLabel.Location = new System.Drawing.Point(answerTextbox.Location.X, answerTextbox.Location.Y - answerBoxLabel.Height);
            answerBoxLabel.Text = "Answer:";
            answerBoxLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            answerBoxLabel.BackColor = Color.FromArgb(226, 240, 217);

            cardCountLabel.Text = "Cards In Current Deck: " + Engine.newDeck.deck.Count;
            cardCountLabel.Size = new Size(200, cardCountLabel.Height);
            cardCountLabel.Location = new System.Drawing.Point(((questionTextbox.Left + answerTextbox.Right) / 2) - ((cardCountLabel.Width) / 2), questionTextbox.Location.Y + questionTextbox.Height + 10);
            cardCountLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            cardCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            cardCountLabel.BackColor = Color.FromArgb(226, 240, 217);

            addCard.Text = "Add Card";
            addCard.Cursor = Cursors.Hand;
            addCard.BackColor = Color.FromArgb(169, 209, 142);
            addCard.FlatStyle = FlatStyle.Flat;
            addCard.FlatAppearance.BorderColor = Color.FromArgb(47, 82, 143);
            addCard.FlatAppearance.BorderSize = 2;
            addCard.Size = new Size(100, 40);
            addCard.Font = new Font("Arial", 10, FontStyle.Regular);
            addCard.Location = new System.Drawing.Point(answerTextbox.Right + 20, ((questionTextbox.Bottom - questionTextbox.Top) / 2) - 2 * addCard.Height + questionTextbox.Location.Y);

            done.Text = "Done";
            done.Cursor = Cursors.Hand;
            done.BackColor = Color.FromArgb(169, 209, 142);
            done.FlatStyle = FlatStyle.Flat;
            done.FlatAppearance.BorderColor = Color.FromArgb(47, 82, 143);
            done.FlatAppearance.BorderSize = 2;
            done.Size = new Size(100, 40);
            done.Font = new Font("Arial", 10, FontStyle.Regular);
            done.Location = new System.Drawing.Point(answerTextbox.Right + 20, ((questionTextbox.Bottom - questionTextbox.Top) / 2) + done.Height + questionTextbox.Location.Y);

            Controls.Add(cancel);
            Controls.Add(done);
            Controls.Add(addCard);
            Controls.Add(cardCountLabel);
            Controls.Add(questionBoxLabel);
            Controls.Add(answerBoxLabel);
            Controls.Add(questionTextbox);
            Controls.Add(answerTextbox);
        }
        private void allDecks()
        {
            closeAllContols();

            backToStart.Text = "Back";
            backToStart.BackColor = Color.FromArgb(226, 240, 217);
            backToStart.Size = new Size(75, 30);
            backToStart.Location = new System.Drawing.Point(width - backToStart.Width, height - backToStart.Height - 2);
            backToStart.TextAlign = ContentAlignment.MiddleRight;
            backToStart.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\back.png"}");
            backToStart.BackgroundImageLayout = ImageLayout.Stretch;
            backToStart.FlatStyle = FlatStyle.Flat;
            backToStart.FlatAppearance.BorderSize = 0;
            backToStart.Cursor = Cursors.Hand;
            backToStart.FlatAppearance.MouseOverBackColor = backToStart.BackColor;

            if (Engine.decksList.Count > 3)
            {
                DeckCountLabel.Text = "Deck:" + (startDeckIndex + 1) + "-" + (startDeckIndex + 4) + "/" + (Engine.decksList.Count);
            }
            else if (Engine.decksList.Count == 0)
            {
                DeckCountLabel.Text = "Deck:" + 0 + "-" + (Engine.decksList.Count) + "/" + (Engine.decksList.Count);

            }
            else
            {
                DeckCountLabel.Text = "Deck:" + (startDeckIndex + 1) + "-" + (Engine.decksList.Count) + "/" + (Engine.decksList.Count);
            }
            DeckCountLabel.Size = new Size(200, DeckCountLabel.Height);
            DeckCountLabel.Location = new System.Drawing.Point((width / 2) - ((DeckCountLabel.Width) / 2), height - DeckCountLabel.Height - 2);
            DeckCountLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            DeckCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            DeckCountLabel.BackColor = Color.FromArgb(226, 240, 217);

            deckSelection.Size = new Size(width - 150, height - 150);
            deckSelection.Location = new System.Drawing.Point(80, 75);

            prevDeck.Size = new Size(60, 60);
            prevDeck.Location = new System.Drawing.Point(10, (height / 2) - (prevDeck.Height / 2));
            prevDeck.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\prevDeck.png"}");
            prevDeck.BackgroundImageLayout = ImageLayout.Stretch;
            prevDeck.BackColor = Color.FromArgb(226, 240, 217);
            prevDeck.FlatStyle = FlatStyle.Flat;
            prevDeck.FlatAppearance.BorderSize = 0;
            prevDeck.Cursor = Cursors.Hand;
            prevDeck.FlatAppearance.MouseOverBackColor = prevDeck.BackColor;


            nextDeck.Size = new Size(60, 60);
            nextDeck.Location = new System.Drawing.Point(width - nextDeck.Width - 10, (height / 2) - (nextDeck.Height / 2));
            nextDeck.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\nextDeck.png"}");
            nextDeck.BackgroundImageLayout = ImageLayout.Stretch;
            nextDeck.BackColor = Color.FromArgb(226, 240, 217);
            nextDeck.FlatStyle = FlatStyle.Flat;
            nextDeck.FlatAppearance.BorderSize = 0;
            nextDeck.Cursor = Cursors.Hand;
            nextDeck.FlatAppearance.MouseOverBackColor = nextDeck.BackColor;

            backToAllDecks.Text = "Back";
            backToAllDecks.BackColor = Color.FromArgb(226, 240, 217);
            backToAllDecks.Size = new Size(75, 30);
            backToAllDecks.Location = new System.Drawing.Point(width - backToAllDecks.Width, height - backToAllDecks.Height - 2);
            backToAllDecks.TextAlign = ContentAlignment.MiddleRight;
            backToAllDecks.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\back.png"}");
            backToAllDecks.BackgroundImageLayout = ImageLayout.Stretch;
            backToAllDecks.FlatStyle = FlatStyle.Flat;
            backToAllDecks.FlatAppearance.BorderSize = 0;
            backToAllDecks.Cursor = Cursors.Hand;
            backToAllDecks.FlatAppearance.MouseOverBackColor = backToAllDecks.BackColor;

            String[] deckNames = new String[Engine.decksList.Count];
            int i = 0;
            foreach (Deck d in Engine.decksList)
            {
                deckNames[i++] = d.Name;
            }


            if (Engine.decksList.Count > 0)
            {
                visableDeck1.Size = new Size(deckSelection.Width / 4 - 5, 140);
                visableDeck1.Location = new System.Drawing.Point(deckSelection.Left, height / 2 - visableDeck1.Height / 2);
                visableDeck1.BackColor = Color.FromArgb(180, 199, 231);
                visableDeck1.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\lightDeckIcon.png"}");
                visableDeck1.BackgroundImageLayout = ImageLayout.Stretch;
                visableDeck1.FlatStyle = FlatStyle.Flat;
                visableDeck1.FlatAppearance.BorderSize = 2;
                visableDeck1.Cursor = Cursors.Hand;
                visableDeck1.FlatAppearance.MouseOverBackColor = Color.FromArgb(116, 152, 210);
                Controls.Add(visableDeck1);


                visableDeck1Name.Text = deckNames[startDeckIndex];
                visableDeck1Name.BackColor = Color.FromArgb(226, 240, 217);
                visableDeck1Name.Font = new Font("Arial", 10, FontStyle.Regular);
                visableDeck1Name.TextAlign = ContentAlignment.MiddleCenter;
                visableDeck1Name.Width = visableDeck1.Width;
                visableDeck1Name.Location = new System.Drawing.Point(visableDeck1.Left, visableDeck1.Bottom + 2);
                Controls.Add(visableDeck1Name);
            }
            if (Engine.decksList.Count > 1)
            {
                visableDeck2.Size = new Size(deckSelection.Width / 4 - 5, 140);
                visableDeck2.Location = new System.Drawing.Point(deckSelection.Width / 4 + deckSelection.Left, height / 2 - visableDeck2.Height / 2);
                visableDeck2.BackColor = Color.FromArgb(180, 199, 231);
                visableDeck2.Padding = new Padding(50);
                visableDeck2.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\lightDeckIcon.png"}");
                visableDeck2.BackgroundImageLayout = ImageLayout.Stretch;
                visableDeck2.FlatStyle = FlatStyle.Flat;
                visableDeck2.FlatAppearance.BorderSize = 2;
                visableDeck2.Cursor = Cursors.Hand;
                visableDeck2.FlatAppearance.MouseOverBackColor = Color.FromArgb(116, 152, 210);
                Controls.Add(visableDeck2);


                visableDeck2Name.Text = deckNames[startDeckIndex + 1];
                visableDeck2Name.BackColor = Color.FromArgb(226, 240, 217);
                visableDeck2Name.Font = new Font("Arial", 10, FontStyle.Regular);
                visableDeck2Name.TextAlign = ContentAlignment.MiddleCenter;
                visableDeck2Name.Width = visableDeck2.Width;
                visableDeck2Name.Location = new System.Drawing.Point(visableDeck2.Left, visableDeck2.Bottom + 2);
                Controls.Add(visableDeck2Name);
            }
            if (Engine.decksList.Count > 2)
            {

                visableDeck3.Size = new Size(deckSelection.Width / 4 - 5, 140);
                visableDeck3.Location = new System.Drawing.Point(deckSelection.Width / 2 + deckSelection.Left, height / 2 - visableDeck2.Height / 2);
                visableDeck3.BackColor = Color.FromArgb(180, 199, 231);
                visableDeck3.Padding = new Padding(50);
                visableDeck3.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\lightDeckIcon.png"}");
                visableDeck3.BackgroundImageLayout = ImageLayout.Stretch;
                visableDeck3.FlatStyle = FlatStyle.Flat;
                visableDeck3.FlatAppearance.BorderSize = 2;
                visableDeck3.Cursor = Cursors.Hand;
                visableDeck3.FlatAppearance.MouseOverBackColor = Color.FromArgb(116, 152, 210);
                Controls.Add(visableDeck3);


                visableDeck3Name.Text = deckNames[startDeckIndex + 2];
                visableDeck3Name.BackColor = Color.FromArgb(226, 240, 217);
                visableDeck3Name.Font = new Font("Arial", 10, FontStyle.Regular);
                visableDeck3Name.TextAlign = ContentAlignment.MiddleCenter;
                visableDeck3Name.Width = visableDeck3.Width;
                visableDeck3Name.Location = new System.Drawing.Point(visableDeck3.Left, visableDeck3.Bottom + 2);
                Controls.Add(visableDeck3Name);

            }
            if (Engine.decksList.Count > 3)
            {
                visableDeck4.Size = new Size(deckSelection.Width / 4 - 5, 140);
                visableDeck4.Location = new System.Drawing.Point(3 * deckSelection.Width / 4 + deckSelection.Left, height / 2 - visableDeck2.Height / 2);
                visableDeck4.BackColor = Color.FromArgb(180, 199, 231);
                visableDeck4.Padding = new Padding(50);
                visableDeck4.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\lightDeckIcon.png"}");
                visableDeck4.BackgroundImageLayout = ImageLayout.Stretch;
                visableDeck4.FlatStyle = FlatStyle.Flat;
                visableDeck4.FlatAppearance.BorderSize = 2;
                visableDeck4.Cursor = Cursors.Hand;
                visableDeck4.FlatAppearance.MouseOverBackColor = Color.FromArgb(116, 152, 210);
                Controls.Add(visableDeck4);


                visableDeck4Name.Text = deckNames[startDeckIndex + 3];
                visableDeck4Name.BackColor = Color.FromArgb(226, 240, 217);
                visableDeck4Name.Font = new Font("Arial", 10, FontStyle.Regular);
                visableDeck4Name.TextAlign = ContentAlignment.MiddleCenter;
                visableDeck4Name.Width = visableDeck4.Width;
                visableDeck4Name.Location = new System.Drawing.Point(visableDeck4.Left, visableDeck4.Bottom + 2);
                Controls.Add(visableDeck4Name);
            }

            if (Engine.decksList.Count > 4)
            {

                if (startDeckIndex > 0)
                {
                    Controls.Add(prevDeck);
                }
                else
                {
                    Controls.Remove(prevDeck);
                }

                if (startDeckIndex < Engine.decksList.Count - 4)
                {
                    Controls.Add(nextDeck);
                }
                else
                {
                    Controls.Remove(nextDeck);
                }
            }

            Controls.Add(backToStart);
            Controls.Add(DeckCountLabel);



        }
        private void studyScreen(int deckIndex)
        {
            staticDeckIndex = deckIndex;
            closeAllContols();
            String currentDeckNameString = Engine.decksList[deckIndex].Name;
            if (Engine.decksList[deckIndex].isShuffled)
            {
                deckArray = engine.generateShuffledArray(Engine.decksList[deckIndex]);

            }
            else
            {
                deckArray = engine.generateOrderedArray(Engine.decksList[deckIndex]);
            }


            if (!questionSide)
            {
                currentCard.Text = deckArray[currentIndex].answer;
            }
            else
            {
                currentCard.Text = deckArray[currentIndex].question;
            }

            currentCard.BackColor = Color.White;
            currentCard.Size = new Size(500, 200);
            currentCard.FlatStyle = FlatStyle.Flat;
            currentCard.Location = new System.Drawing.Point((width / 2) - (currentCard.Width / 2), (height / 2) - (currentCard.Height / 2));
            currentCard.FlatAppearance.BorderColor = Color.FromArgb(143, 170, 220);
            currentCard.FlatAppearance.BorderSize = 2;
            currentCard.FlatAppearance.MouseOverBackColor = currentCard.BackColor;
            currentCard.FlatAppearance.MouseDownBackColor = Color.White;




            rotate.Text = char.ConvertFromUtf32(0x21ba);
            rotate.Font = new Font("Arial", 16, FontStyle.Regular);
            rotate.Size = new Size(25, 20);
            rotate.AutoSize = true;
            rotate.Location = new System.Drawing.Point(currentCard.Right - rotate.Width - 5, currentCard.Bottom - rotate.Height - 8);
            rotate.BringToFront();
            rotate.TextAlign = ContentAlignment.MiddleLeft;
            rotate.BackColor = Color.White;
            rotate.ForeColor = Color.Gray;

            clickToRotate.Text = "Click To Rotate";
            clickToRotate.Size = new Size(200, 15); ;
            clickToRotate.Location = new System.Drawing.Point(rotate.Left - clickToRotate.Width, rotate.Top + rotate.Height / 2 - (clickToRotate.Height / 4));
            clickToRotate.BringToFront();
            clickToRotate.TextAlign = ContentAlignment.MiddleRight;
            clickToRotate.BackColor = Color.White;
            clickToRotate.ForeColor = Color.Gray;




            prevCard.Size = new Size(75, 75);
            prevCard.Location = new System.Drawing.Point(50, (height / 2) - (prevCard.Height / 2));
            prevCard.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\prevCard.png"}");
            prevCard.BackgroundImageLayout = ImageLayout.Stretch;
            prevCard.BackColor = Color.FromArgb(226, 240, 217);
            prevCard.FlatStyle = FlatStyle.Flat;
            prevCard.FlatAppearance.BorderSize = 0;
            prevCard.Cursor = Cursors.Hand;
            prevCard.FlatAppearance.MouseOverBackColor = prevCard.BackColor;


            nextCard.Size = new Size(75, 75);
            nextCard.Location = new System.Drawing.Point(width - 50 - nextCard.Width, (height / 2) - (nextCard.Height / 2));
            nextCard.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\nextCard.png"}");
            nextCard.BackgroundImageLayout = ImageLayout.Stretch;
            nextCard.BackColor = Color.FromArgb(226, 240, 217);
            nextCard.FlatStyle = FlatStyle.Flat;
            nextCard.FlatAppearance.BorderSize = 0;
            nextCard.Cursor = Cursors.Hand;
            nextCard.FlatAppearance.MouseOverBackColor = prevCard.BackColor;

            edit.Text = "Edit Deck";
            edit.Size = new Size(90, 30);
            edit.BackColor = Color.FromArgb(180, 199, 231);
            edit.Font = new Font("Arial", 10, FontStyle.Regular);
            edit.Location = new System.Drawing.Point(width - edit.Width - 5, 5);
            edit.TextAlign = ContentAlignment.MiddleCenter;
            edit.FlatStyle = FlatStyle.Flat;
            edit.FlatAppearance.BorderSize = 0;
            edit.Cursor = Cursors.Hand;
            edit.FlatAppearance.MouseOverBackColor = shuffle.BackColor;



            shuffle.Text = "Shuffle";
            shuffle.BackColor = Color.FromArgb(226, 240, 217);
            shuffle.Size = new Size(75, 30);
            shuffle.Location = new System.Drawing.Point(5, height - shuffle.Height - 2);
            shuffle.TextAlign = ContentAlignment.MiddleRight;
            shuffle.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\shuffle.png"}");
            shuffle.BackgroundImageLayout = ImageLayout.Stretch;
            shuffle.FlatStyle = FlatStyle.Flat;
            shuffle.FlatAppearance.BorderSize = 0;
            shuffle.Cursor = Cursors.Hand;
            shuffle.FlatAppearance.MouseOverBackColor = shuffle.BackColor;

            reorder.Text = "Reorder";
            reorder.BackColor = Color.FromArgb(226, 240, 217);
            reorder.Size = new Size(75, 30);
            reorder.Location = new System.Drawing.Point(5, height - reorder.Height - 2);
            reorder.TextAlign = ContentAlignment.MiddleRight;
            reorder.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\reorder.png"}");
            reorder.BackgroundImageLayout = ImageLayout.Stretch;
            reorder.FlatStyle = FlatStyle.Flat;
            reorder.FlatAppearance.BorderSize = 0;
            reorder.Cursor = Cursors.Hand;
            reorder.FlatAppearance.MouseOverBackColor = reorder.BackColor;

            cardCountLabel.Text = (currentIndex + 1) + "/" + deckArray.Length;
            cardCountLabel.Size = new Size(currentCard.Width, cardCountLabel.Height);
            cardCountLabel.Location = new System.Drawing.Point(currentCard.Left, currentCard.Bottom + 5);
            cardCountLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            cardCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            cardCountLabel.BackColor = Color.FromArgb(226, 240, 217);

            currentDeckName.Text = currentDeckNameString;
            currentDeckName.Size = new Size(currentCard.Width, currentDeckName.Height);
            currentDeckName.Location = new System.Drawing.Point(currentCard.Left, currentCard.Top - currentDeckName.Height - 10);
            currentDeckName.Font = new Font("Arial", 10, FontStyle.Regular);
            currentDeckName.TextAlign = ContentAlignment.MiddleCenter;
            currentDeckName.BackColor = Color.FromArgb(226, 240, 217);

            if (Engine.decksList[deckIndex].isShuffled)
            {
                Controls.Add(reorder);
            }
            else
            {
                Controls.Add(shuffle);
            }
            Controls.Add(rotate);
            Controls.Add(clickToRotate);
            Controls.Add(currentCard);
            Controls.Add(prevCard);
            Controls.Add(nextCard);
            Controls.Add(backToAllDecks);
            Controls.Add(cardCountLabel);
            Controls.Add(currentDeckName);
            Controls.Add(edit);





        }
        private void editScreen(int deckIndex)
        {
            closeAllContols();

            editQuestion.Text = currentCard.Text = deckArray[currentIndex].question;
            editQuestion.Size = new Size(width / 3, width / 3 + 50);
            editQuestion.Location = new System.Drawing.Point(50, 75);
            editQuestion.AutoSize = false;
            editQuestion.Multiline = true;
            editQuestion.BorderStyle = BorderStyle.None;

            editAnswer.Text = currentCard.Text = deckArray[currentIndex].answer;
            editAnswer.Size = new Size(width / 3, width / 3 + 50);
            editAnswer.Location = new System.Drawing.Point(editQuestion.Right + 20, 75);
            editAnswer.AutoSize = false;
            editAnswer.Multiline = true;
            editAnswer.BorderStyle = BorderStyle.None;

            editPrev.Text = "<<";
            editPrev.Size = new Size(30, 30);
            editPrev.Font = new Font("Consolas", 8, FontStyle.Regular);
            editPrev.Location = new System.Drawing.Point(editQuestion.Left - editPrev.Width - 10, (editQuestion.Top + editQuestion.Height / 2) - (editPrev.Height / 2));
            editPrev.ForeColor = Color.FromArgb(47, 82, 143);
            editPrev.BackColor = Color.White;
            editPrev.FlatStyle = FlatStyle.Flat;

            editNext.Text = ">>";
            editNext.Size = new Size(30, 30);
            editNext.Font = new Font("Consolas", 8, FontStyle.Regular);
            editNext.Location = new System.Drawing.Point(editAnswer.Right + 10, (editAnswer.Top + editAnswer.Height / 2) - (editNext.Height / 2));
            editNext.ForeColor = Color.FromArgb(47, 82, 143);
            editNext.BackColor = Color.White;
            editNext.FlatStyle = FlatStyle.Flat;



            renameDeckTextBox.Text = Engine.decksList[deckIndex].Name;
            renameDeckTextBox.ReadOnly = true;
            renameDeckTextBox.Size = new Size(editAnswer.Width + editQuestion.Width, 10);
            renameDeckTextBox.Location = new System.Drawing.Point(((editQuestion.Left + editAnswer.Right) / 2) - ((renameDeckTextBox.Width) / 2), editQuestion.Top - renameDeckTextBox.Height - 40);
            renameDeckTextBox.Font = new Font("Arial", 15, FontStyle.Regular);
            renameDeckTextBox.BackColor = Color.FromArgb(226, 240, 217);
            renameDeckTextBox.TextAlign = HorizontalAlignment.Center;
            renameDeckTextBox.BorderStyle = BorderStyle.None;

            renameButton.Text = "Rename Deck";
            renameButton.AutoSize = true;
            renameButton.Location = new System.Drawing.Point(((editQuestion.Left + editAnswer.Right) / 2) - ((renameButton.Width) / 2), editQuestion.Top - renameButton.Height - 5);
            renameButton.BackColor = Color.FromArgb(226, 240, 217);
            renameButton.ForeColor = Color.FromArgb(47, 82, 143);
            renameButton.FlatAppearance.BorderSize = 0;
            renameButton.FlatStyle = FlatStyle.Flat;
            renameButton.TextAlign = ContentAlignment.MiddleCenter;


            editIndex.Text = (currentIndex + 1) + "/" + deckArray.Length;
            editIndex.Size = new Size(200, editIndex.Height);
            editIndex.Location = new System.Drawing.Point(((editQuestion.Left + editAnswer.Right) / 2) - ((editIndex.Width) / 2), editQuestion.Location.Y + editQuestion.Height + 10);
            editIndex.Font = new Font("Arial", 10, FontStyle.Regular);
            editIndex.TextAlign = ContentAlignment.MiddleCenter;
            editIndex.BackColor = Color.FromArgb(226, 240, 217);

            


            addCardEdit.Text = "New Card";
            addCardEdit.Size = new Size(100, 40);
            addCardEdit.Location = new System.Drawing.Point(editAnswer.Right + 50, editAnswer.Top+20);
            addCardEdit.BackColor = Color.FromArgb(47, 82, 143);
            addCardEdit.FlatStyle = FlatStyle.Flat;
            addCardEdit.FlatAppearance.BorderColor = Color.White;
            addCardEdit.FlatAppearance.BorderSize = 2;
            addCardEdit.ForeColor = Color.White;
            addCardEdit.Font = new Font("Arial", 10, FontStyle.Regular);

            deleteCard.Text = "Delete Card";
            deleteCard.Size = new Size(100, 40);
            deleteCard.Location = new System.Drawing.Point(editAnswer.Right + 50, editAnswer.Top + (editAnswer.Height / 4) + 20);
            deleteCard.BackColor = Color.FromArgb(47, 82, 143);
            deleteCard.FlatStyle = FlatStyle.Flat;
            deleteCard.FlatAppearance.BorderColor = Color.White;
            deleteCard.FlatAppearance.BorderSize = 2;
            deleteCard.ForeColor = Color.White;
            deleteCard.Font = new Font("Arial", 10, FontStyle.Regular);




            deleteDeck.Text = "Delete Deck";
            deleteDeck.Size = new Size(100, 40);
            deleteDeck.Location = new System.Drawing.Point(editAnswer.Right + 50, editAnswer.Top + (editAnswer.Height / 2) + 20);
            deleteDeck.BackColor = Color.FromArgb(47, 82, 143);
            deleteDeck.FlatStyle = FlatStyle.Flat;
            deleteDeck.FlatAppearance.BorderColor = Color.White;
            deleteDeck.FlatAppearance.BorderSize = 2;
            deleteDeck.ForeColor = Color.White;
            deleteDeck.Font = new Font("Arial", 10, FontStyle.Regular);

            doneEditing.Text = "Done";
            doneEditing.Size = new Size(100, 40);
            doneEditing.Location = new System.Drawing.Point(editAnswer.Right + 50, editAnswer.Top + 3 * (editAnswer.Height / 4) + 20);
            doneEditing.Cursor = Cursors.Hand;
            doneEditing.BackColor = Color.FromArgb(47, 82, 143);
            doneEditing.FlatStyle = FlatStyle.Flat;
            doneEditing.FlatAppearance.BorderColor = Color.White;
            doneEditing.FlatAppearance.BorderSize = 2;
            doneEditing.ForeColor = Color.White;
            doneEditing.Font = new Font("Arial", 10, FontStyle.Regular);








            Controls.Add(doneEditing);
            Controls.Add(renameButton);
            Controls.Add(editPrev);
            Controls.Add(editNext);
            Controls.Add(deleteCard);
            Controls.Add(deleteDeck);
            Controls.Add(editQuestion);
            Controls.Add(editAnswer);
            Controls.Add(renameDeckTextBox);
            Controls.Add(editIndex);
            Controls.Add(addCardEdit);


        }
        private void editAddCard(int deckIndex)
        {
            closeAllContols();


            editAddQuestionTextbox.Size = new Size(width / 3, width / 3 + 50);
            editAddQuestionTextbox.Location = new System.Drawing.Point(50, 65);
            editAddQuestionTextbox.AutoSize = false;
            editAddQuestionTextbox.Multiline = true;
            editAddQuestionTextbox.BorderStyle = BorderStyle.None;

            editAddAnswerTextbox.Size = new Size(width / 3, width / 3 + 50);
            editAddAnswerTextbox.Location = new System.Drawing.Point(editAddQuestionTextbox.Right + 20, 65);
            editAddAnswerTextbox.AutoSize = false;
            editAddAnswerTextbox.Multiline = true;
            editAddAnswerTextbox.BorderStyle = BorderStyle.None;

            editAddQuestionBoxLabel.Location = new System.Drawing.Point(editAddQuestionTextbox.Location.X, editAddQuestionTextbox.Location.Y - editAddQuestionBoxLabel.Height);
            editAddQuestionBoxLabel.Text = "Question:";
            editAddQuestionBoxLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            editAddQuestionBoxLabel.BackColor = Color.FromArgb(226, 240, 217);

            editAddAnswerBoxLabel.Location = new System.Drawing.Point(editAddAnswerTextbox.Location.X, editAddAnswerTextbox.Location.Y - editAddAnswerBoxLabel.Height);
            editAddAnswerBoxLabel.Text = "Answer:";
            editAddAnswerBoxLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            editAddAnswerBoxLabel.BackColor = Color.FromArgb(226, 240, 217);

            editAddCardCountLabel.Text = "Cards In Current Deck: " + Engine.decksList[staticDeckIndex].deck.Count;
            editAddCardCountLabel.Size = new Size(200, editAddCardCountLabel.Height);
            editAddCardCountLabel.Location = new System.Drawing.Point(((editAddQuestionTextbox.Left + editAddAnswerTextbox.Right) / 2) - ((editAddCardCountLabel.Width) / 2), editAddQuestionTextbox.Location.Y + editAddQuestionTextbox.Height + 10);
            editAddCardCountLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            editAddCardCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            editAddCardCountLabel.BackColor = Color.FromArgb(226, 240, 217);

            editAddAddCard.Text = "Add Card";
            editAddAddCard.Cursor = Cursors.Hand;
            editAddAddCard.BackColor = Color.FromArgb(169, 209, 142);
            editAddAddCard.FlatStyle = FlatStyle.Flat;
            editAddAddCard.FlatAppearance.BorderColor = Color.FromArgb(47, 82, 143);
            editAddAddCard.FlatAppearance.BorderSize = 2;
            editAddAddCard.Size = new Size(100, 40);
            editAddAddCard.Font = new Font("Arial", 10, FontStyle.Regular);
            editAddAddCard.Location = new System.Drawing.Point(editAddAnswerTextbox.Right + 20, ((editAddQuestionTextbox.Bottom - editAddQuestionTextbox.Top) / 2) - 2 * addCard.Height + editAddQuestionTextbox.Location.Y);

            editAddDone.Text = "Done";
            editAddDone.Cursor = Cursors.Hand;
            editAddDone.BackColor = Color.FromArgb(169, 209, 142);
            editAddDone.FlatStyle = FlatStyle.Flat;
            editAddDone.FlatAppearance.BorderColor = Color.FromArgb(47, 82, 143);
            editAddDone.FlatAppearance.BorderSize = 2;
            editAddDone.Size = new Size(100, 40);
            editAddDone.Font = new Font("Arial", 10, FontStyle.Regular);
            editAddDone.Location = new System.Drawing.Point(editAddAnswerTextbox.Right + 20, ((editAddQuestionTextbox.Bottom - editAddQuestionTextbox.Top) / 2) + done.Height + editAddQuestionTextbox.Location.Y);

            Controls.Add(editAddDone);
            Controls.Add(editAddAddCard);
            Controls.Add(editAddCardCountLabel);
            Controls.Add(editAddQuestionBoxLabel);
            Controls.Add(editAddAnswerBoxLabel);
            Controls.Add(editAddQuestionTextbox);
            Controls.Add(editAddAnswerTextbox);
        }


        private void allDecks_Event(object sender, EventArgs e)
        {
            allDecks();
        }

        private void nameDeck_Next(object sender, EventArgs e)
        {
            if ((String.IsNullOrWhiteSpace(deckName.Text)))
            {
                MessageBox.Show("Name can't be blank");

            }
            else if (deckName.Text.Length > 18)
            {
                MessageBox.Show("Name can't be more than 18 characters long");
            }
            else
            {
                if (!engine.uniqueDeckName(deckName.Text))
                {
                    MessageBox.Show("A deck with that name already exists, \n Please choose another name");
                }
                else
                {
                    Engine.newDeck.Name = deckName.Text; ;
                    deckName.Text = "";
                    newDeckAddingCards();
                }
            }
        }
        private void cancelNewDeck(object sender, EventArgs e)
        {
            Engine.newDeck = new Deck("");
            questionTextbox.Text = "";
            answerTextbox.Text = "";
            deckName.Text = "";
            startScreen();

        }

        private void addCard_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(questionTextbox.Text))
            {
                MessageBox.Show("Question side can't be blank");
            }
            else if (String.IsNullOrWhiteSpace(answerTextbox.Text))
            {
                MessageBox.Show("Answer side can't be left blank");
            }
            else
            {
                Engine.newDeck.addCard(questionTextbox.Text, answerTextbox.Text);
                cardCountLabel.Text = "Cards In Current Deck: " + Engine.newDeck.deck.Count;

                questionTextbox.Text = "";
                answerTextbox.Text = "";
            }
        }
        private void doneAddingCard(object sender, EventArgs e)
        {
            if (Engine.newDeck.deck.Count > 0)
            {
                Deck tempDeck = Engine.newDeck;

                if (String.IsNullOrWhiteSpace(questionTextbox.Text) || String.IsNullOrWhiteSpace(answerTextbox.Text))
                {
                    questionTextbox.Text = "";
                    answerTextbox.Text = "";
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Do you want to add the current card you're working on before saving deck?",
                      "Add Card?", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            Engine.newDeck.addCard(questionTextbox.Text, answerTextbox.Text);
                            cardCountLabel.Text = "Cards In Current Deck: " + Engine.newDeck.deck.Count;

                            questionTextbox.Text = "";
                            answerTextbox.Text = "";
                            break;
                        case DialogResult.No:
                            questionTextbox.Text = "";
                            answerTextbox.Text = "";
                            break;
                    }
                }
                Engine.decksList.Add(tempDeck);
                Engine.newDeck = new Deck("");
                allDecks();
            }
            else
            {
                MessageBox.Show("Add at least one card to the deck");
            }
        }

        private void backToStartEvent(object sender, EventArgs e)
        {
            startScreen();
        }
        private void selectedDeck(object sender, EventArgs e)
        {
            currentIndex = 0;
            Button SelectedDeck = (sender as Button);
            if (SelectedDeck == visableDeck1)
            {
                studyScreen(startDeckIndex);
            }
            if (SelectedDeck == visableDeck2)
            {
                studyScreen(startDeckIndex + 1);
            }
            if (SelectedDeck == visableDeck3)
            {
                studyScreen(startDeckIndex + 2);
            }
            if (SelectedDeck == visableDeck4)
            {
                studyScreen(startDeckIndex + 3);
            }

        }
        private void incrementDeck(object sender, EventArgs e)
        {
            if (startDeckIndex < Engine.decksList.Count - 4)
            {
                startDeckIndex++;
            }
            else
            {
                startDeckIndex = Engine.decksList.Count - 4;
            }
            allDecks();
        }
        private void decrementDeck(object sender, EventArgs e)
        {
            if (startDeckIndex > 0)
            {
                startDeckIndex--;
            }
            else
            {
                startDeckIndex = 0;
            }
            allDecks();
        }

        private void prevCard_Click(object sender, EventArgs e)
        {
            if (currentIndex == 0)
            {
                currentIndex = deckArray.Length - 1;

            }
            else
            {
                currentIndex--;

            }
            currentCard.Text = deckArray[currentIndex].question;
            cardCountLabel.Text = (currentIndex + 1) + "/" + deckArray.Length;
            editQuestion.Text = deckArray[currentIndex].question;
            editAnswer.Text = deckArray[currentIndex].answer;

        }
        private void nextCard_Click(object sender, EventArgs e)
        {
            if (currentIndex == deckArray.Length - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            currentCard.Text = deckArray[currentIndex].question;
            cardCountLabel.Text = (currentIndex + 1) + "/" + deckArray.Length;
        }
        private void shuffleCards(object sender, EventArgs e)
        {
            Engine.decksList[staticDeckIndex].isShuffled = true;
            studyScreen(staticDeckIndex);
            Controls.Remove(shuffle);
            Controls.Add(reorder);
        }
        private void rearrangeCards(object sender, EventArgs e)
        {
            Engine.decksList[staticDeckIndex].isShuffled = false;
            studyScreen(staticDeckIndex);
            Controls.Remove(reorder);
        }
        private void Flip(object sender, EventArgs e)
        {
            Button indexCard = (sender as Button);
            if (questionSide)
            {
                currentCard.Text = deckArray[currentIndex].answer;
                questionSide = false;
            }
            else
            {
                currentCard.Text = deckArray[currentIndex].question;
                questionSide = true;
            }

        }
        private void editSelectedDeck(object sender, EventArgs e)
        {

            editScreen(staticDeckIndex);


        }


        private void renameDeck(object sender, EventArgs e)
        {
            if (renameDeckTextBox.ReadOnly)
            {
                renameDeckTextBox.ReadOnly = false;
                renameDeckTextBox.BackColor = Color.White;
                renameDeckTextBox.BorderStyle = BorderStyle.Fixed3D;
                renameButton.Text = "Save Name";
            }
            else
            {
                renameDeckTextBox.ReadOnly = true;
                renameDeckTextBox.BackColor = Color.FromArgb(226, 240, 217);
                renameButton.Text = "Rename Deck";
                renameDeckTextBox.BorderStyle = BorderStyle.None;
                if (!(String.IsNullOrWhiteSpace(renameDeckTextBox.Text)) && (renameDeckTextBox.Text.Length < 18))
                {
                    Engine.decksList[staticDeckIndex].Name = renameDeckTextBox.Text;
                }
                else
                {
                    renameDeckTextBox.Text = Engine.decksList[staticDeckIndex].Name;
                }

            }
        }
        private void nextCardEdit(object sender, EventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(editQuestion.Text)))
            {
                Engine.decksList[staticDeckIndex].deck[currentIndex].question = editQuestion.Text;
            }
            else
            {
                editQuestion.Text = Engine.decksList[staticDeckIndex].deck[currentIndex].question;
            }
            if (!(String.IsNullOrWhiteSpace(editAnswer.Text)))
            {
                Engine.decksList[staticDeckIndex].deck[currentIndex].answer = editAnswer.Text;
            }
            else
            {
                editAnswer.Text = Engine.decksList[staticDeckIndex].deck[currentIndex].answer;
            }
            if (currentIndex == deckArray.Length - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            editIndex.Text = (currentIndex + 1) + "/" + deckArray.Length;
            editQuestion.Text = deckArray[currentIndex].question;
            editAnswer.Text = deckArray[currentIndex].answer;
        }
        private void prevCardEdit(object sender, EventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(editQuestion.Text)))
            {
                Engine.decksList[staticDeckIndex].deck[currentIndex].question = editQuestion.Text;
            }
            else
            {
                editQuestion.Text = Engine.decksList[staticDeckIndex].deck[currentIndex].question;
            }
            if (!(String.IsNullOrWhiteSpace(editAnswer.Text)))
            {
                Engine.decksList[staticDeckIndex].deck[currentIndex].answer = editAnswer.Text;
            }
            else
            {
                editAnswer.Text = Engine.decksList[staticDeckIndex].deck[currentIndex].answer;
            }
            if (currentIndex == 0)
            {
                currentIndex = deckArray.Length - 1;

            }
            else
            {
                currentIndex--;

            }

            editIndex.Text = (currentIndex + 1) + "/" + deckArray.Length;
            editQuestion.Text = deckArray[currentIndex].question;
            editAnswer.Text = deckArray[currentIndex].answer;
        }
        private void doneEditing_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(editQuestion.Text)))
            {
                Engine.decksList[staticDeckIndex].deck[currentIndex].question = editQuestion.Text;
            }
            else
            {
                editQuestion.Text = Engine.decksList[staticDeckIndex].deck[currentIndex].question;
            }
            if (!(String.IsNullOrWhiteSpace(editAnswer.Text)))
            {
                Engine.decksList[staticDeckIndex].deck[currentIndex].answer = editAnswer.Text;
            }
            else
            {
                editAnswer.Text = Engine.decksList[staticDeckIndex].deck[currentIndex].answer;
            }
            editIndex.Text = (currentIndex + 1) + "/" + deckArray.Length;
            editQuestion.Text = deckArray[currentIndex].question;
            editAnswer.Text = deckArray[currentIndex].answer;

            allDecks();
        }
        private void deleteCard_Click(object sender, EventArgs e)
        {
            if (Engine.decksList[staticDeckIndex].deck.Count == 1)
            {
                MessageBox.Show("you can't delete the only card in this deck. you can:\n -Add a new card in this deck and then delete this card \n or\n -Delete the deck ");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete the current card?",
                       "Delete Card?", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:

                        Engine.decksList[staticDeckIndex].deck.RemoveAt(currentIndex);
                        deckArray = engine.generateOrderedArray(Engine.decksList[staticDeckIndex]);
                        if (currentIndex >= deckArray.Length)
                        {
                            currentIndex = 0;
                        }

                        editScreen(staticDeckIndex);

                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
        private void deleteDeck_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to perminently delete the current deck?",
                    "Delete Deck?", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    Engine.decksList.RemoveAt(staticDeckIndex);
                    allDecks();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        private void addCardEdit_Click(object sender, EventArgs e)
        {
            editAddCard(staticDeckIndex);
        }

        private void editAddCard_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(editAddQuestionTextbox.Text))
            {
                MessageBox.Show("Question side can't be blank");
            }
            else if (String.IsNullOrWhiteSpace(editAddAnswerTextbox.Text))
            {
                MessageBox.Show("Answer side can't be left blank");
            }
            else
            {
                Engine.decksList[staticDeckIndex].addCard(editAddQuestionTextbox.Text, editAddAnswerTextbox.Text);
                editAddCardCountLabel.Text = "Cards In Current Deck: " + Engine.decksList[staticDeckIndex].deck.Count;

                editAddQuestionTextbox.Text = "";
                editAddAnswerTextbox.Text = "";
            }
        }
        private void editAddDone_Click(object sender, EventArgs e)
        {


            Deck tempDeck = Engine.newDeck;

            if (String.IsNullOrWhiteSpace(editAddQuestionTextbox.Text) || String.IsNullOrWhiteSpace(editAddAnswerTextbox.Text))
            {
                editAddQuestionTextbox.Text = "";
                editAddAnswerTextbox.Text = "";
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want to add the current card you're working on before saving deck?",
                  "Add Card?", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        Engine.decksList[staticDeckIndex].addCard(editAddQuestionTextbox.Text, editAddAnswerTextbox.Text);
                        editAddCardCountLabel.Text = "Cards In Current Deck: " + Engine.decksList[staticDeckIndex].deck.Count;

                        editAddQuestionTextbox.Text = "";
                        editAddAnswerTextbox.Text = "";
                        break;
                    case DialogResult.No:
                        editAddQuestionTextbox.Text = "";
                        editAddAnswerTextbox.Text = "";
                        break;
                }
            }
            deckArray = engine.generateOrderedArray(Engine.decksList[staticDeckIndex]);

            editScreen(staticDeckIndex);
        }
        private void closing(object sender, FormClosingEventArgs e)
        {
            engine.saveData();
        }

    }

}
