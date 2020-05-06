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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void règlesDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Le Bouton Simulation vous permet d'entrer en mode simulation, vous pouvez choisir le nombre de pas de simulation, choisr la case de départ en cliquant dessus, ou laisser le programme choisir aléatoirement\n" +
                "Le bouton jouer vous permet de jouer vous même, avec une indication des cases de déplacement accessilbles.");
        }

        private void auteursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Youmna Halifa\n" + "Carole Lecarpentier");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this);
            f3.Show();
        }
    }
}
