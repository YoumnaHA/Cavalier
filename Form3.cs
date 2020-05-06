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
    public partial class Form3 : Form
    {
        BoutonCavalier[,] plateau = new BoutonCavalier[12, 12];
        Form1 f1;
        List<BoutonCavalier> coups = new List<BoutonCavalier>();
        static int[,] grille = new int[12, 12];
        static int[] depi = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] depj = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };
        int nb_fuite = 0;
        int min_fuite = 0;
        int lmin_fuite = 0;
        int i, j, k, l, ii, jj;
        int cpt;
       

        Random random = new Random();

       

        public Form3(Form1 fjeu)
        {
            InitializeComponent();
            this.f1 = fjeu;
        }

       

        private void Form3_Load(object sender, EventArgs e)
        {
            cpt = 0;
            for (int x = 2; x < 10; x++)
            {
                for (int y = 2; y < 10; y ++)
                {
                    BoutonCavalier b = new BoutonCavalier(x, y);
                    plateau[x, y] = b;
                    plateau[x, y].Click += new EventHandler(this.Boutons_Click);
                    b.Location = new System.Drawing.Point(60 * x, 60 + 60 * y);
                    b.Size = new System.Drawing.Size(60, 60);
                    if( x % 2 == 0 && y % 2 == 0)
                    {
                        b.BackColor = Color.LightCyan;
                    }
                    else if ( x %2 == 1 && y % 2 == 1)
                    {
                        b.BackColor = Color.LightCyan;
                    }
                    else if ( x % 2 == 1 && y % 2 == 0)
                    {
                        b.BackColor = Color.IndianRed;
                    }
                    else if( x % 2 == 0 && y % 2 == 1)
                    {
                        b.BackColor = Color.IndianRed;
                    }
                    this.Controls.Add(b);
                }
            }
        }
        static int fuite(int i, int j)
        {
            int n, l;
            for (l = 0, n = 8; l < 8; l++)
            {
                if( grille [i + depi[l], j + depj[l]] != 0)
                {
                    n--;
                }
            }
            return (n == 0) ? 9 : n;
        }
        private void Boutons_Click(object sender, EventArgs e)
        {
            if( sender is BoutonCavalier)
            {
                BoutonCavalier b = (BoutonCavalier)sender;
                if (cpt == 0)
                {
                    b.BackgroundImage = Image.FromFile(@"images\cavalier.png");
                    cpt++;
                }
                else
                {
                    BoutonCavalier b1 = coups[cpt - 1];
                    b1.BackgroundImage = null;
                    b1.Text = cpt.ToString();
                    b.BackgroundImage = Image.FromFile(@"images\cavalier.png");
                    cpt++;
                }
              
                coups.Add(b);

                for( int x = 2; x < 10; x++)
                {
                    for (int y = 2; y < 10; y ++)
                    {
                        plateau[x, y].Enabled = false;
                        if(x %2 == 0 && y % 2 == 0)
                        {
                            plateau[x, y].BackColor = Color.LightCyan;
                        }
                        else if( x % 2 == 1 && y % 2 == 1)
                        {
                            plateau[x, y].BackColor = Color.LightCyan;
                        }
                        else if(x %2 == 1 && y % 2 == 0)
                        {
                            plateau[x, y].BackColor = Color.IndianRed;
                        }
                        else if (x % 2 == 0  && y % 2 == 1)
                        {
                            plateau[x, y].BackColor = Color.IndianRed;
                        }
                    }
                }
                for( int depl = 0; depl < 8; depl++)
                {
                    if(b.getX() + depi[depl] >= 2 && b.getY() + depj[depl] >= 2 && b.getX() + depi[depl] < 10 && b.getY() + depj[depl] < 10)  
                    {
                        if (plateau[b.getX() + depi[depl], b.getY() + depj[depl]].Text == "")
                        {
                            plateau[b.getX() + depi[depl], b.getY() + depj[depl]].BackColor = Color.CadetBlue;
                            plateau[b.getX() + depi[depl], b.getY() + depj[depl]].Enabled = true;
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)   // annuler coup
        {
            for (int x = 2; x < 10; x++)
            {
                for (int y = 2; y < 10; y++)
                {
                    plateau[x, y].Enabled = false;
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        plateau[x, y].BackColor = Color.LightCyan;
                    }
                    else if (x % 2 == 1 && y % 2 == 1)
                    {
                        plateau[x, y].BackColor = Color.LightCyan;
                    }
                    else if (x % 2 == 1 && y % 2 == 0)
                    {
                        plateau[x, y].BackColor = Color.IndianRed;
                    }
                    else if (x % 2 == 0 && y % 2 == 1)
                    {
                        plateau[x, y].BackColor = Color.IndianRed;
                    }
                }
            }
           
            coups[coups.Count -1].BackgroundImage = null;
            coups[coups.Count -1].Text = "";
            if( coups.Count - 2 < 0)
                {
                    MessageBox.Show("Pas de retour en arrière possible!");
                }
            else if (coups == null)
            {
                MessageBox.Show("PAS de retour en arrière possible !");
                this.Show();
                this.Dispose(false);
            }
            else
                {
                plateau[coups[coups.Count - 2].getX(), coups[coups.Count - 2].getY()].BackgroundImage = Image.FromFile(@"images\cavalier.png");
                for (int depl = 0; depl < 8; depl++)
                    {
                        if( plateau[coups[coups.Count - 2].getX(), coups[coups.Count - 2].getY()].getX() + depi[depl] >= 2 &&
                            plateau[coups[coups.Count - 2].getX(), coups[coups.Count - 2].getY()].getY() + depj[depl] >= 2 &&
                            plateau[coups[coups.Count - 2].getX(), coups[coups.Count - 2].getY()].getX() + depi[depl] < 10 &&
                            plateau[coups[coups.Count - 2].getX(), coups[coups.Count - 2].getY()].getY() + depj[depl] < 10 )
                        {   
                            if (plateau[coups[coups.Count - 2].getX() + depi[depl], coups[coups.Count - 2].getY() + depj[depl]].Text == "")
                            {
                                plateau[plateau[coups[coups.Count - 2].getX(), coups[coups.Count - 2].getY()].getX() + depi[depl],
                                plateau[coups[coups.Count - 2].getX(), coups[coups.Count - 2].getY()].getY() + depj[depl]].BackColor = Color.CadetBlue;
                                plateau[plateau[coups[coups.Count - 2].getX(), coups[coups.Count - 2].getY()].getX() + depi[depl],
                                plateau[coups[coups.Count - 2].getX(), coups[coups.Count - 2 ].getY()].getY() + depj[depl]].Enabled = true;
                            }
                        }
                    }
                }
            
                coups.RemoveAt(coups.Count -1);
            cpt--;
            
        }
        private void button1_Click(object sender, EventArgs e) // Recommencer
        {
            Form3 f3 = new Form3(f1);
            if (sender is Button)
            {
                f3.Show();
            }
            this.Dispose(false);
        }

        private void button3_Click(object sender, EventArgs e)  //Abandon
        {
            for (i = 0; i <12; i++)
            {
                for( j = 0; j < 12; j++)
                {
                    grille[i, j] = ((i < 2 | i > 9 | j < 2 | j > 9) ? -1 : 0);
                }
            }
            i = coups[0].getX(); j = coups[0].getY();
            grille[i, j] = 1;
            for ( k = 2; k < 64; k++)
            {
                for( l = 0, min_fuite = 11; l < 8; l++)
                {
                    ii = i + depi[l]; jj = j + depj[l];
                    nb_fuite = ((grille[ii, jj] != 0) ? 10 : fuite(ii, jj));
                    if( nb_fuite < min_fuite)
                    {
                        min_fuite = nb_fuite; lmin_fuite = l;
                    }
                }
                if (min_fuite == 9 & k != 64)
                {
                    MessageBox.Show("impasse !");
                }
                i += depi[lmin_fuite]; j += depj[lmin_fuite];
                grille[i, j] = k;
                plateau[i, j].Text = "" + k;

            }
        }
    }
}
