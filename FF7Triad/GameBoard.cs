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
        Card[][] playBoard;
        private int _numCards = 0;
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
            enemyCardChooseDeck.generateDeck();
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
                cards[i].Click += new EventHandler((s, e)=>cardClick(s, e, myCard));
                pCardSelect.Controls.Add(cards[i]);
                i++;
                offset = offset + 100;
            }
            foreach(Card myCard in enemyCardChooseDeck.myDeck)
            {
                enemyCards[i] = new PictureBox();
                enemyCards[i].Location = new Point(0 + offset, 0);
                enemyCards[i].Size = new Size(100, 127);
                enemyCards[i].Image = myCard.cardImage;
                enemyCards[i].Click += new EventHandler((s, e) => enemyCardClick(s, e, myCard));
            }
        }

        private void enemyCardClick(object s, EventArgs e, Card myCard)
        {
            throw new NotImplementedException();
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

                playBoard[0][0] = selectedCard;
                pbLocation1.Image = selectedCard.cardImage;
                if (selectedCard.attackRight > playBoard[0][1].attackLeft)
                {
                    //to be implemented
                }
                if (selectedCard.attackDown > playBoard[1][0].attackUp)
                {
                    //to be implemented
                }
                selectedCard = null;
            }

        }

        private void pbLocation2_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {
                playBoard[0][1] = selectedCard;
                pbLocation2.Image = selectedCard.cardImage;
                if (selectedCard.attackRight > playBoard[0][0].attackLeft)
                {
                    //to be implemented
                }
                if (selectedCard.attackDown > playBoard[1][1].attackUp)
                {
                    //to be implemented
                }
                selectedCard = null;
            }
        }

        private void pbLocation3_Click(object sender, EventArgs e)
        {
            if (!(selectedCard == null))
            {
                playBoard[0][2] = selectedCard;
                pbLocation3.Image = selectedCard.cardImage;
                if (!(playBoard[0][1] == null))
                {
                    if (selectedCard.attackLeft > playBoard[0][1].attackRight)
                    {

                    }
                }
                if (!(playBoard[1][2] == null))
                {
                    if (selectedCard.attackDown > playBoard[1][2].attackUp)
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

                playBoard[1][0] = selectedCard;
                pbLocation4.Image = selectedCard.cardImage;
                if (!(playBoard[2][0] == null))
                {
                    if (selectedCard.attackDown>playBoard[2][0].attackUp)
                    {

                    }
                }
                if (!(playBoard[1][1] == null))
                {
                    if (selectedCard.attackRight > playBoard[1][1].attackLeft)
                    {

                    }
                }
                if (!(playBoard[0][0] == null))
                {
                    if (selectedCard.attackUp > playBoard[0][0].attackDown)
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

                playBoard[1][1] = selectedCard;
                pbLocation5.Image = selectedCard.cardImage;
                if(!(playBoard[0][1]==null))
                {
                    if (selectedCard.attackUp > playBoard[0][1].attackDown)
                    {

                    }
                }
                if (!(playBoard[1][0] == null))
                {
                    if (selectedCard.attackLeft > playBoard[1][0].attackRight)
                    {

                    }
                }
                if (!(playBoard[2][1] == null))
                {
                    if (selectedCard.attackDown > playBoard[2][1].attackUp)
                    {

                    }
                }
                if (!(playBoard[1][2] == null))
                {
                    if (selectedCard.attackRight > playBoard[1][2].attackLeft)
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
                playBoard[1][2] = selectedCard;
                pbLocation6.Image = selectedCard.cardImage;
                if (!(playBoard[1][1] == null))
                {
                    if (selectedCard.attackLeft > playBoard[1][1].attackRight)
                    {

                    }
                }
                if (!(playBoard[0][2]==null))
                {
                    if (selectedCard.attackUp > playBoard[0][2].attackDown)
                    {

                    }

                }
                if (!(playBoard[2][2] == null))
                {
                    if (selectedCard.attackDown > playBoard[2][2].attackUp)
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
                playBoard[2][0] = selectedCard;
                pbLocation7.Image = selectedCard.cardImage;
                if (!(playBoard[1][0] == null)){
                    if (selectedCard.attackUp > playBoard[1][0].attackDown)
                    {

                    }
                }
                if (!(playBoard[2][1]==null))
                {
                    if (selectedCard.attackLeft > playBoard[2][1].attackRight)
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
                playBoard[2][1] = selectedCard;
                pbLocation8.Image = selectedCard.cardImage;
                if (!(playBoard[2][0] == null))
                {
                    if (selectedCard.attackLeft > playBoard[2][0].attackRight)
                    {

                    }
                }
                if (!(playBoard[2][2] == null))
                {
                    if (selectedCard.attackRight > playBoard[2][2].attackLeft)
                    {

                    }
                }

                if (!(playBoard[1][1] == null))
                {
                    if (selectedCard.attackUp > playBoard[1][1].attackDown)
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
                playBoard[2][2] = selectedCard;
                pbLocation9.Image = selectedCard.cardImage;
                if (!(playBoard[1][2]==null))
                {
                    if (selectedCard.attackUp > playBoard[1][2].attackDown)
                    {

                    }
                }
                if (!(playBoard[2][1]==null))
                {
                    if (selectedCard.attackLeft > playBoard[2][1].attackRight)
                    {

                    }
                }
                selectedCard = null;
            }
        }
    }
}
