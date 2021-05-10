using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;


namespace Typerr2
{
    public partial class GameScreen : Form
    {


        private SoundPlayer hangeffekt;
        string[] szavak = File.ReadAllLines("szavak2.txt"); // Beolvassa a txt fájlt a szavak stringbe

        Random rnd = new Random();

        ToolTip figyelmeztet = new ToolTip();

        int helyes = 0;
        int helytelen = 0;
        public GameScreen()
        {

            InitializeComponent();

            //this.Load += new System.EventHandler(this.GameScreen_Load);  Jelenleg nincs szükség rá
            hangeffekt = new SoundPlayer("keysfx.wav");
            labelszo.Text = szavak[rnd.Next(0, szavak.Length)]; // Kiválaszt egy szót véletlenszerűen a txt fájlból


        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)                                // Enter leütéskor ellenőrzi, hogy a begépelt szó helyes-e.
            {

                if (textBox1.Text == labelszo.Text)
                {
                    helyes++;                                           // Ha helyes megnöveli a változót
                    labelszo.Text = szavak[rnd.Next(0, szavak.Length)]; // új szót választ véletlenszerűen a tömbből
                    textBox1.Text = null;                               // letörli az előzőleg beírt szót
                }
                else
                {
                    helytelen++;                                        // Ugyanaz csak helytelenül beírt szó esetén
                    labelszo.Text = szavak[rnd.Next(0, szavak.Length)];
                    textBox1.Text = null;

                }
                labelhelyes.Text = "Helyes: " + helyes;
                labelhelytelen.Text = "Helytelen: " + helytelen;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new Form1()).Show(); this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelhelyes.Text = "Helyes: 0";
            labelhelytelen.Text = "Helytelen: 0";
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            
        }

   
        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (Control.IsKeyLocked(Keys.CapsLock)) // Hibaüzenet CAPS LOCK bekapcsolva
            {

                figyelmeztet.ToolTipTitle = "CAPS LOCK bekapcsolva!!!";
                figyelmeztet.ToolTipIcon = ToolTipIcon.Warning;
                figyelmeztet.IsBalloon = true;
                figyelmeztet.SetToolTip(textBox1, "CAPS LOCK-kal írott szavak helytelennek számítanak \n\nNyomd le ismét a CAPS LOCK billentyűt a kikapcsolásához!");
                figyelmeztet.Show("CAPS LOCK-kal írott szavak helytelennek számítanak \n\nNyomd le ismét a CAPS LOCK billentyűt a kikapcsolásához!", textBox1, 5, textBox1.Height - 5);
            }
            else
            {
                figyelmeztet.Hide(textBox1);
            }



        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            hangeffekt.Play();
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Eltünteti a beep hangot ENTER leütésekor
                hangeffekt.Stop();
            }
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;                              // Eltünteti a beep hangot ENTER leütésekor
                hangeffekt.Stop();
            }
        }
       
    }
}
