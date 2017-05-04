using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace FF7Triad
{
    public class Card
    {
        public Image cardImage;
        public string name { get; set; }
        public int attackUp { get; set; }
        public int attackDown { get; set; }
        public int attackLeft { get; set; }
        public int attackRight { get; set; }
    }
}
