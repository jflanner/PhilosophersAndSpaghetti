using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhilosophersAndSpaghetti
{
    public partial class ProgramUI : Form
    {



        public PhilosopherUI[] Philosopher;
        private ForkUI[] Fork;
        private Supervisor Boss;

        public ProgramUI(Supervisor pBoss)
        {
            Boss = pBoss;
            Boss.ProgramUI = this;
            InitializeComponent();
        }

        private void ProgramUI_Load(object sender, System.EventArgs e)
        {
            int i;
            PhilosopherUI p;
            ForkUI f;
            Philosopher = new PhilosopherUI[6];
            Fork = new ForkUI[6];

            // Create the Table
            Table.Dock = DockStyle.None;
            Table.BackColor = Color.LightBlue;
            Table.Paint += new System.Windows.Forms.PaintEventHandler(this.Table_Paint);
            this.Controls.Add(Table);

            //Create the Philosopher and Fork UI elements
            for (i = 1; i < 6; i++)
            {
                p = new PhilosopherUI(i, this);
                f = new ForkUI(i, this);
                Philosopher[i] = p;
                Fork[i] = f;
            }

            Table.SendToBack();

        }



        private void ButtonStart_Click(object sender, EventArgs e)
        {

            Boss.Arise();
            // TestUI();

        }

        private void Table_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.

            SolidBrush BeigeBrush = new SolidBrush(Color.Beige);

            Point[] HexigonPoints =
            {
               new Point(60, 20),
               new Point(20, 100),
               new Point(110, 175),
               new Point(200, 100),
               new Point(160, 20)
            };

            e.Graphics.FillPolygon(BeigeBrush, HexigonPoints);

        }

        public PhilosopherUI PhilosopherUI(int  i)
        {
            return (Philosopher[i]);
        }


        private void TestUI()
        {
            // This method is a debug time utility.  It is not intended for use in the program itself.  What this will do is exercise all the UI points - 
            // one philosopher at a time - in a single thread.  Note: it will take a minute to completely get through the progression.
            // 
            // Call this method from ButtonStart_Click.

            int i;

            for (i = 1; i < 6; i++)
            {
                Philosopher[i].GrantedLeftFork();
                Philosopher[i].GrantedRightFork();
                Philosopher[i].ReleasedLeftFork();
                Philosopher[i].ReleasedRightFork(); 
                Philosopher[i].DeniedLeftFork();
                Philosopher[i].DeniedRightFork();
                Philosopher[i].BiteTaken();

            }


        }

    }
}
