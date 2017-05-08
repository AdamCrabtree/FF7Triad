using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FF7Triad
{

    public partial class GameBoard : Form
    {
        Card selectedCard;
        Deck playerDeck = new Deck();
        Deck enemyDeck = new Deck();
        Card[,] playBoard = new Card[3, 3];
        private int _numCards = 0;
        private int _numEnemyCards = 0;
        public int numEnemyCards
        {
            get { return _numEnemyCards; }
            set
            {
                _numEnemyCards = value;
                if (_numEnemyCards == 5)
                {
                    pEnemyCardSelect.Hide();
                }
            }
        }
        public int numCards
        {
            get { return _numCards; }
            set
            {
                _numCards = value;
                if(_numCards == 5)
                {
                    pCardSelect.Hide();
                }
            }
        }
        public GameBoard()
        {
            WindowState = FormWindowState.Maximized;
            Bitmap bmGameBoard = new Bitmap(FF7Triad.Properties.Resources.gameboard);
            InitializeComponent();

            pbGameBoard.Image = bmGameBoard;
            cardSelect();
            
        }
        public void cardSelect()
        {
            Deck cardChooseDeck = new FF7Triad.Deck();
            Deck enemyCardChooseDeck = new FF7Triad.Deck();
            cardChooseDeck.generateDeck();
            enemyCardChooseDeck.generateEnemyDeck();
            PictureBox[] enemyCards = new PictureBox[cardChooseDeck.myDeck.Count];
            PictureBox[] cards = new PictureBox[cardChooseDeck.myDeck.Count];
            int i = 0;
            int j = 0;
            int offset2 = 0;
            int offset = 0;



            foreach (Card myCard in cardChooseDeck.myDeck)
            {
                cards[i] = new PictureBox();
                cards[i].Location = new Point(0 + offset, 0);
                cards[i].Size = new Size(100, 127);
                cards[i].Image = myCard.cardImage;
                cards[i].Click += new EventHandler((s, e) => cardClick(s, e, myCard));
                pCardSelect.Controls.Add(cards[i]);
                i++;
                offset = offset + 100;
            }

            foreach (Card myCard in enemyCardChooseDeck.myDeck)
            {
                enemyCards[j] = new PictureBox();
                enemyCards[j].Location = new Point(0 + offset2, 0);
                enemyCards[j].Size = new Size(100, 127);
                enemyCards[j].Image = myCard.cardImage;
                enemyCards[j].Click += new EventHandler((s, e) => enemyCardClick(s, e, myCard));
                pEnemyCardSelect.Controls.Add(enemyCards[j]);
                j++;
                offset2 = offset2 + 100;
            }
        }


        private void enemyCardClick(object s, EventArgs e, Card myCard)
        {
            enemyDeck.myDeck.Add(myCard);
            if (numEnemyCards == 0)
            {
                pbEnemyCard.Image = myCard.cardImage;
            }
            else if(numEnemyCards == 1)
            {
                pbEnemyCard2.Image = myCard.cardImage;
            }
            else if(numEnemyCards == 2)
            {
                pbEnemyCard3.Image = myCard.cardImage;
            }
            else if (numEnemyCards == 3)
            {
                pbEnemyCard4.Image = myCard.cardImage;
            }
            else if (numEnemyCards == 4)
            {
                pbEnemyCard5.Image = myCard.cardImage;
            }
            numEnemyCards++;
        }

        private void cardClick(object sender, EventArgs e, Card myCard)
        {
            playerDeck.myDeck.Add(myCard);
            if (numCards == 0)
            {
                pbPlayerCard1.Image = myCard.cardImage;
            }
            else if (numCards == 1)
            {
                pbPlayerCard2.Image = myCard.cardImage;
            }
            else if (numCards == 2)
            {
                pbPlayerCard3.Image = myCard.cardImage;
            }
            else if (numCards == 3)
            {
                pbPlayerCard4.Image = myCard.cardImage;
            }
            else if (numCards == 4)
            {
                pbPlayerCard5.Image = myCard.cardImage;
            }
            numCards++;
        }

        private void pbPlayerCard1_Click(object sender, EventArgs e)
        {
            selectedCard = playerDeck.myDeck.ElementAt(0);
        }

        private void pbPlayerCard2_Click(object sender, EventArgs e)
        {
            selectedCard = playerDeck.myDeck.ElementAt(1);
        }

        private void pbPlayerCard3_Click(object sender, EventArgs e)
        {
            selectedCard = playerDeck.myDeck.ElementAt(2);
        }

        private void pbPlayerCard4_Click(object sender, EventArgs e)
        {
            selectedCard = playerDeck.myDeck.ElementAt(3);
        }

        private void pbPlayerCard5_Click(object sender, EventArgs e)
        {
            selectedCard = playerDeck.myDeck.ElementAt(4);
        }


  
        private void pbLocation1_Click(object sender, EventArgs e)
        {

            if (!(selectedCard == null))
            {

                playBoard[0,0] = selectedCard;
                if (selectedCard.isEnemyCard == false)
                {
                    pbLocation1.Image = selectedCard.cardImage;
                }
                else
                    pbLocation1.Image = selectedCard.enemyCardImage;
                if (!(playBoard[0, 1] == null))
                {
                    if (selectedCard.attackRight > playBoard[0, 1].attackLeft && !(selectedCard.isEnemyCard == playBoard[0, 1].isEnemyCard))
                    {
                        if (playBoard[0, 1].isEnemyCard == true)
                        {
                            pbLocation2.Image = playBoard[0, 1].cardImage;
                            playBoard[0, 1].isEnemyCard = false;
                        }
                        else
                        {
                            pbLocation2.Image = playBoard[0, 1].enemyCardImage;
                            playBoard[0, 1].isEnemyCard = true;
                        }
                    }
                }
                if (!(playBoard[1, 0] == null))
                {


                    if (selectedCard.attackDown > playBoard[1, 0].attackUp && !(selectedCard.isEnemyCard == playBoard[1, 0].isEnemyCard))
                    {
                        if (playBoard[1, 0].isEnemyCard == true)
                        {
                            pbLocation4.Image = playBoard[1, 0].cardImage;
                            playBoard[1, 0].isEnemyCard = false;
                        }
                        else
                        {
                            pbLocation4.Image = playBoard[1, 0].enemyCardImage;
                            playBoard[1, 0].isEnemyCard = true;
                        }
                    }
                }
                selectedCard = null;
            }

        }

        private void pbLocation2_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {
                playBoard[0, 1] = selectedCard;
                if (selectedCard.isEnemyCard == false)
                {
                    pbLocation2.Image = selectedCard.cardImage;
                }
                else
                    pbLocation2.Image = selectedCard.enemyCardImage;
                if (!(playBoard[0, 0] == null))
                {

                    if (selectedCard.attackLeft > playBoard[0, 0].attackRight && !(selectedCard.isEnemyCard == playBoard[0, 0].isEnemyCard))
                    {
                        if (playBoard[0, 0].isEnemyCard == true)
                        {
                            pbLocation1.Image = playBoard[0, 0].cardImage;
                            playBoard[0, 0].isEnemyCard = false;
                        }
                        else
                        {
                            pbLocation1.Image = playBoard[0, 0].enemyCardImage;
                            playBoard[0, 0].isEnemyCard = true;
                        }
                    }
                }
                if (!(playBoard[1, 1] == null))
                {

                    if (selectedCard.attackDown > playBoard[1, 1].attackUp && !(selectedCard.isEnemyCard == playBoard[1, 1].isEnemyCard))
                    {
                        //to be implemented
                    }
                }
                selectedCard = null;
            }
        }

        private void pbLocation3_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {
                playBoard[0,2] = selectedCard;
                pbLocation3.Image = selectedCard.cardImage;
                if (!(playBoard[0,1] == null))
                {
                    if (selectedCard.attackLeft > playBoard[0,1].attackRight && !(selectedCard.isEnemyCard == playBoard[0,1].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[1,2] == null))
                {
                    if (selectedCard.attackDown > playBoard[1,2].attackUp && !(selectedCard.isEnemyCard == playBoard[1,2].isEnemyCard))
                    {

                    }
                }
                    selectedCard = null;
            }
        }

        private void pbLocation4_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {

                playBoard[1,0] = selectedCard;
                pbLocation4.Image = selectedCard.cardImage;
                if (!(playBoard[2,0] == null))
                {
                    if (selectedCard.attackDown>playBoard[2, 0].attackUp && !(selectedCard.isEnemyCard == playBoard[2, 0].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[1, 1] == null))
                {
                    if (selectedCard.attackRight > playBoard[1, 1].attackLeft && !(selectedCard.isEnemyCard == playBoard[1, 1].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[0, 0] == null))
                {
                    if (selectedCard.attackUp > playBoard[0, 0].attackDown && !(selectedCard.isEnemyCard == playBoard[0, 0].isEnemyCard))
                    {

                    }
                }
                selectedCard = null;
            }
        }

        private void pbLocation5_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {

                playBoard[1, 1] = selectedCard;
                pbLocation5.Image = selectedCard.cardImage;
                if(!(playBoard[0,1]==null))
                {
                    if (selectedCard.attackUp > playBoard[0, 1].attackDown && !(selectedCard.isEnemyCard == playBoard[0, 1].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[1, 0] == null))
                {
                    if (selectedCard.attackLeft > playBoard[1, 0].attackRight && !(selectedCard.isEnemyCard == playBoard[1, 0].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[2, 1] == null))
                {
                    if (selectedCard.attackDown > playBoard[2, 1].attackUp && !(selectedCard.isEnemyCard == playBoard[2, 1].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[1, 2] == null))
                {
                    if (selectedCard.attackRight > playBoard[1, 2].attackLeft && !(selectedCard.isEnemyCard == playBoard[1, 2].isEnemyCard))
                    {

                    }
                }
                selectedCard = null;
            }

        }

        private void pbLocation6_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {
                playBoard[1, 2] = selectedCard;
                pbLocation6.Image = selectedCard.cardImage;
                if (!(playBoard[1, 1] == null))
                {
                    if (selectedCard.attackLeft > playBoard[1, 1].attackRight && !(selectedCard.isEnemyCard == playBoard[1, 1].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[0,2]==null))
                {
                    if (selectedCard.attackUp > playBoard[0, 2].attackDown && !(selectedCard.isEnemyCard == playBoard[0,2].isEnemyCard))
                    {

                    }

                }
                if (!(playBoard[2, 2] == null))
                {
                    if (selectedCard.attackDown > playBoard[2, 2].attackUp && !(selectedCard.isEnemyCard == playBoard[2, 2].isEnemyCard))
                    {

                    }

                }
                selectedCard = null;
            }

        }

        private void pbLocation7_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {
                playBoard[2, 0] = selectedCard;
                pbLocation7.Image = selectedCard.cardImage;
                if (!(playBoard[1, 0] == null)){
                    if (selectedCard.attackUp > playBoard[1, 0].attackDown && !(selectedCard.isEnemyCard == playBoard[1,0].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[2, 1]==null))
                {
                    if (selectedCard.attackLeft > playBoard[2, 1].attackRight && !(selectedCard.isEnemyCard == playBoard[2, 1].isEnemyCard))
                    {

                    }
                }
                selectedCard = null;
            }
        }

        private void pbLocation8_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {
                playBoard[2, 1] = selectedCard;
                pbLocation8.Image = selectedCard.cardImage;
                if (!(playBoard[2, 0] == null))
                {
                    if (selectedCard.attackLeft > playBoard[2, 0].attackRight && !(selectedCard.isEnemyCard == playBoard[2, 0].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[2, 2] == null))
                {
                    if (selectedCard.attackRight > playBoard[2, 2].attackLeft && !(selectedCard.isEnemyCard == playBoard[2, 2].isEnemyCard))
                    {

                    }
                }

                if (!(playBoard[1, 1] == null))
                {
                    if (selectedCard.attackUp > playBoard[1, 1].attackDown && !(selectedCard.isEnemyCard == playBoard[1, 1].isEnemyCard))
                    {

                    }   
                }
                selectedCard = null;
            }


        }

        private void pbLocation9_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {
                playBoard[2, 2] = selectedCard;
                pbLocation9.Image = selectedCard.cardImage;
                if (!(playBoard[1, 2]==null))
                {
                    if (selectedCard.attackUp > playBoard[1,2].attackDown && !(selectedCard.isEnemyCard == playBoard[1, 2].isEnemyCard))
                    {

                    }
                }
                if (!(playBoard[2, 1]==null))
                {
                    if (selectedCard.attackLeft > playBoard[2, 1].attackRight && !(selectedCard.isEnemyCard == playBoard[2,1].isEnemyCard))
                    {

                    }
                }
                selectedCard = null;
            }
        }

        private void pbEnemyCard_Click(object sender, EventArgs e)
        {
            selectedCard = enemyDeck.myDeck.ElementAt(0);
        }

        private void pbEnemyCard2_Click(object sender, EventArgs e)
        {
            selectedCard = enemyDeck.myDeck.ElementAt(1);

        }

        private void pbEnemyCard3_Click(object sender, EventArgs e)
        {
            selectedCard = enemyDeck.myDeck.ElementAt(2);

        }

        private void pbEnemyCard4_Click(object sender, EventArgs e)
        {
            selectedCard = enemyDeck.myDeck.ElementAt(3);

        }

        private void pbEnemyCard5_Click(object sender, EventArgs e)
        {
            selectedCard = enemyDeck.myDeck.ElementAt(4);

        }
    }
}
