using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cavalier2
{
    public partial class Form2 : Form
    { 
        BoutonCavalier[,] plateau = new BoutonCavalier[12, 12];
        Form1 f1;
        int pas;

        static int[,] grille = new int[12, 12];
        static int[] depi = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] depj = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };
        int nb_fuite, min_fuite, lmin_fuite = 0;
        int i, j, k, l, ii, jj;
        
        Random random = new Random();

       

        public Form2(Form1 form)
        {
            InitializeComponent();
            this.f1 = form;
            Random random = new Random();
            ii = random.Next(1, 8);
            jj = random.Next(1, 8);

            for (i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    grille[i, j] = ((i < 2 | i > 9 | j < 2 | j > 9) ? -1  : 0);
                }
            }
            i = ii + 1; j = jj + 1;
            grille[i, j] = 1;

        }

        private void Button4_Click(object sender, EventArgs e) //démarrage aléatoire
        {
            Random random = new Random();
            ii = random.Next(1, 8);
            jj = random.Next(1, 8);

            for (i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    grille[i, j] = ((i < 2 | i > 9 | j < 2 | j > 9) ? -1 : 0);
                }
            }
            i = ii + 1; j = jj + 1;
            grille[i, j] = 1;
            plateau[i, j].BackgroundImage = Image.FromFile(@"images\cavalier.png");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int x = 2; x < 10; x++)
            {
                for( int y = 2; y < 10; y++)
                {
                    BoutonCavalier b = new BoutonCavalier(x, y);
                    plateau[x, y] = b;
                    plateau[x, y].Click += new EventHandler(this.Bouton_Click);
                    b.Location = new System.Drawing.Point(60 * x, 60 + 60 * y);
                    b.Size = new System.Drawing.Size(60, 60);

                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        b.BackColor = Color.LightCyan;
                    }
                    else if (x % 2 == 1 && y % 2 == 1)
                    {
                        b.BackColor = Color.LightCyan;
                    }
                    else if (x % 2 == 1 && y % 2 == 0)
                    {
                        b.BackColor = Color.IndianRed;
                    }
                    else if( x %2 == 0 && y %2 == 1)
                    {
                        b.BackColor = Color.IndianRed;
                    }
                    this.Controls.Add(b);
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse((String)listBox1.SelectedItem, out this.pas);
        }

        private void button1_Click_1(object sender, EventArgs e)   /// bouton Jeu par pas
        {
            int a = 0;
            while (k < 64 && a < pas)
            {
                k++; a++;
                plateau[i, j].BackgroundImage = null;
                plateau[i, j].Text = "" + k;
                plateau[i, j].BackColor = Color.CadetBlue;
                plateau[i, j].Enabled = false;
                if (sender is Button)
                {
                    
                    for (l = 0, min_fuite = 11; l < 8; l++)
                    {
                        ii = i + depi[l]; jj = j + depj[l];
                        nb_fuite = ((grille[ii, jj] != 0) ? 10 : fuite(ii, jj));
                        if (nb_fuite < min_fuite)
                        {
                            min_fuite = nb_fuite; lmin_fuite = l;
                        }
                    }
                    if (min_fuite == 9 && k != 64)
                    {
                        MessageBox.Show("FINI");
                    }
                    i += depi[lmin_fuite]; j += depj[lmin_fuite];
                    plateau[i, j].BackgroundImage = Image.FromFile(@"images\cavalier.png");
                    grille[i, j] = k + 1;
                    plateau[i, j].Text = "" + grille[i, j];
                    plateau[i, j].BackColor = Color.CadetBlue;
                    //plateau[i, j].Enabled = false;
                }
            }
            
        }

        
      
        //private BoutonCavalier getCase(int i, int j)
        //{
        //    return plateau[i, j];
        //}

        private void button2_Click(object sender, EventArgs e)      /// coup suivant
        {
            if( k < 64)
            {
                k++;
                plateau[i, j].BackgroundImage = null;
                plateau[i, j].BackColor = Color.CadetBlue;
                plateau[i, j].Enabled = false;
                if (sender is Button)
                {
                    for (l = 0, min_fuite = 11; l < 8; l++)
                    {
                        ii = i + depi[l]; jj = j + depj[l];
                        nb_fuite = ((grille[ii, jj] != 0) ? 10 : fuite(ii, jj));
                        if (nb_fuite < min_fuite)
                        {
                            min_fuite = nb_fuite; lmin_fuite = l;
                        }
                    }
                    if (min_fuite == 9 && k != 64)
                    {
                        MessageBox.Show("FINI");
                    }
                    i += depi[lmin_fuite]; j += depj[lmin_fuite];
                    plateau[i, j].BackgroundImage = Image.FromFile(@"images\cavalier.png");
                    grille[i, j] = k + 1;
                    plateau[i, j].Text = "" + grille[i, j];
                }
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(f1);
            if(sender is Button)
            {
                f2.Show();
            }
            this.Dispose(false);

        }
        private void Bouton_Click(object sender, EventArgs e)
        {
            if(sender is BoutonCavalier)
            {
                BoutonCavalier b = (BoutonCavalier)sender;
                grille[i, j] = 0;
                i = b.getX();
                j = b.getY();
                grille[i, j] = 1;
                b.BackgroundImage = Image.FromFile(@"images\cavalier.png");
                plateau[i, j].Text = "1";
                //b.BackColor = Color.DarkTurquoise;
                b.Enabled = false;
            }
        }
        static int fuite(int i, int j)
        {
            int n, l;
            for (l = 0, n = 8; l < 8; l++)
            {
                if (grille[i + depi[l], j + depj[l]] != 0)
                {
                    n--;
                }
            }
            return (n == 0) ? 9 : n;
        }
    }
   

}
