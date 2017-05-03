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
            myDeck.Add(bitebug);
            myDeck.Add(blobra);
            myDeck.Add(bloodsoul);
            myDeck.Add(caterchipillar);
            myDeck.Add(cokatrice);
            myDeck.Add(funguar);

        }
    }
}
