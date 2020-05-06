using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static Cavalier2.Form2;

namespace Cavalier2
{
   public partial class BoutonCavalier : Button
    {
        int x, y;
        public BoutonCavalier(int x, int y)
        {
            this.x = x;
            this.y = y;
            FlatAppearance.BorderSize = 0;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;

        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
    }
    
    
}
