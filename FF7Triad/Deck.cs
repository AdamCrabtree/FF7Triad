using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Triad
{
    public class Deck
    {
        public List<Card> myDeck = new List<Card>();
        public void generateDeck()
        {
            //to do with actual database
            Card bitebug = new Card();
            Card blobra = new Card();
            Card bloodsoul = new Card();
            Card caterchipillar = new Card();
            Card cokatrice = new Card();
            Card funguar = new Card();
            bitebug.cardImage = (FF7Triad.Properties.Resources.rbitebug);
            blobra.cardImage = (FF7Triad.Properties.Resources.rblobra);
            bloodsoul.cardImage = (FF7Triad.Properties.Resources.rbloodsoul);
            caterchipillar.cardImage = (FF7Triad.Properties.Resources.rcaterchipillar);
            cokatrice.cardImage = (FF7Triad.Properties.Resources.rcockatrice);
            funguar.cardImage = (FF7Triad.Properties.Resources.rfunguar);
            bitebug.enemyCardImage = (FF7Triad.Properties.Resources.rebitebug);
            blobra.enemyCardImage = (FF7Triad.Properties.Resources.reblobra);
            bloodsoul.enemyCardImage = (FF7Triad.Properties.Resources.rebloodsoul);
            bitebug.attackDown = 3;
            bitebug.attackUp = 1;
            bitebug.attackLeft = 5;
            bitebug.attackRight = 3;
            blobra.attackDown = 1;
            blobra.attackLeft = 5;
            blobra.attackRight = 3;
            blobra.attackUp = 2;
            bloodsoul.attackLeft = 1;
            bloodsoul.attackRight = 1;
            bloodsoul.attackDown = 6;
            bloodsoul.attackUp = 2;
            bitebug.isEnemyCard = false;
            blobra.isEnemyCard = false;
            bloodsoul.isEnemyCard = false;
            myDeck.Add(bitebug);
            myDeck.Add(blobra);
            myDeck.Add(bloodsoul);
            myDeck.Add(caterchipillar);
            myDeck.Add(cokatrice);
            myDeck.Add(funguar);

        }
        public void generateEnemyDeck()
        {
            Card bitebug = new Card();
            Card blobra = new Card();
            Card bloodsoul = new Card();
            Card caterchipillar = new Card();
            Card cokatrice = new Card();
            Card funguar = new Card();
            bitebug.cardImage = (FF7Triad.Properties.Resources.rbitebug);
            blobra.cardImage = (FF7Triad.Properties.Resources.rblobra);
            bloodsoul.cardImage = (FF7Triad.Properties.Resources.rbloodsoul);
            caterchipillar.cardImage = (FF7Triad.Properties.Resources.rcaterchipillar);
            cokatrice.cardImage = (FF7Triad.Properties.Resources.rcockatrice);
            funguar.cardImage = (FF7Triad.Properties.Resources.rfunguar);
            bitebug.enemyCardImage = (FF7Triad.Properties.Resources.rebitebug);
            blobra.enemyCardImage = (FF7Triad.Properties.Resources.reblobra);
            bloodsoul.enemyCardImage = (FF7Triad.Properties.Resources.rebloodsoul);
            bitebug.isEnemyCard = true;
            blobra.isEnemyCard = true;
            bloodsoul.isEnemyCard = true;
            bitebug.attackDown = 3;
            bitebug.attackUp = 1;
            bitebug.attackLeft = 5;
            bitebug.attackRight = 3;
            blobra.attackDown = 1;
            blobra.attackLeft = 5;
            blobra.attackRight = 3;
            blobra.attackUp = 2;
            bloodsoul.attackLeft = 1;
            bloodsoul.attackRight = 1;
            bloodsoul.attackDown = 6;
            bloodsoul.attackUp = 2;
            myDeck.Add(bitebug);
            myDeck.Add(blobra);
            myDeck.Add(bloodsoul);
            myDeck.Add(caterchipillar);
            myDeck.Add(cokatrice);
            myDeck.Add(funguar);
        }
    }
}
