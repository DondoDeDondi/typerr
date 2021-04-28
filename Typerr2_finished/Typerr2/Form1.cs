using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typerr2
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


           
         /*   this.FormClosed +=
          new System.Windows.Forms.FormClosedEventHandler(this.LoadGame); */
        }



        private void LoadGame(object sender, EventArgs e)
        {
            (new GameScreen()).Show(); this.Hide(); // elrejti az első Formot és megjeleníti a másodikat


        }

        private void LeaveGame(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Biztosan ki akarsz lépni?", "Kilépés", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit(); //Environment.Exit(0);  
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                this.WindowState = FormWindowState.Maximized;
        }
    }
 }