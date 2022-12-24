using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace PhilosophersAndSpaghetti
{


    public class PhilosopherUI
    {
        private static readonly Point[] AvatarUIPoints =                  // Size is 150 x 150
        {
            new Point(0,0),
            new Point(380, 20),             // 1
            new Point(140, 80),             // 2
            new Point(200, 350),            // 3
            new Point(560, 350),            // 4
            new Point(620, 80)              // 5
         };


        private static readonly Point[] ProgressBarUIPoints =
        {
            new Point(0,0),
            new Point(380, 0),              // 1
            new Point(140, 60),             // 2
            new Point(200, 500),            // 3
            new Point(560, 500),            // 4
            new Point(620, 60)              // 5
         };

        private static readonly Point[] LeftForkRelationshipUIPoints =         //Size = 30 x 30 
        {
            new Point(0,0),
            new Point(350, 50),             // 1
            new Point(225, 240),            // 2
            new Point(375, 450),            // 3
            new Point(610, 310),            // 4
            new Point(590, 100)             // 5
         };


        private static readonly Point[] RightForkRelationshipUIPoints =        // Size = 30 x 30
        {
            new Point(0,0),
            new Point(530,50),              // 1
            new Point(300, 100),            // 2
            new Point(250, 310),            // 3
            new Point(500, 450),            // 4
            new Point(640, 240)             // 5

         };

        private readonly PictureBox Avatar;
        private readonly int Iam;
        private readonly ProgramUI ProgramUI;
        private readonly ProgressBar Progress;
        private readonly PictureBox LeftForkRelationship;
        private readonly PictureBox RightForkRelationship;

        private delegate void ProgressBarDelegate();
        private delegate void LeftForkRelationshipDelegate();
        private delegate void RightForkRelationshipDelegate();

        // https://visualstudiomagazine.com/Articles/2010/11/18/Multithreading-in-WinForms.aspx?m=1&Page=1

        public PhilosopherUI(int pPhilosopherNumber, ProgramUI pProgramUI)
        {
            string PictureFile;
            Progress = new ProgressBar();

            Iam = pPhilosopherNumber;
            ProgramUI = pProgramUI;
            PictureFile = "PhilosophersAndSpaghetti.Images.Philosopher" + Iam + ".JPG";


            Avatar = new System.Windows.Forms.PictureBox();
            Avatar.Name = "Philosopher" + Iam;
            Avatar.Size = new Size(150, 150);
            Avatar.Visible = true;
            Avatar.BackColor = Color.Black;
            Avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            Avatar.Location = AvatarUIPoints[Iam];

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(PictureFile);
            Avatar.Image = new Bitmap(stream);

            Avatar.BringToFront();
            ProgramUI.Controls.Add(Avatar);




            Progress.Location = ProgressBarUIPoints[Iam];
            Progress.Name = "ProgressBar" + Iam;
            Progress.Width = 150;
            Progress.Height = 20;
            Progress.Minimum = 0;
            Progress.Maximum = 5;
            Progress.Value = 0;

            ProgramUI.Controls.Add(Progress);



            LeftForkRelationship = new System.Windows.Forms.PictureBox();
            LeftForkRelationship.Name = "LeftForkRelationship" + Iam;
            LeftForkRelationship.Size = new Size(30, 30);
            LeftForkRelationship.Visible = true;
            LeftForkRelationship.BackColor = Color.Transparent;
            LeftForkRelationship.BorderStyle = BorderStyle.None;
            LeftForkRelationship.Location = LeftForkRelationshipUIPoints[Iam];
            LeftForkRelationship.BringToFront();
            ProgramUI.Controls.Add(LeftForkRelationship);




            RightForkRelationship = new System.Windows.Forms.PictureBox();
            RightForkRelationship.Name = "RightForkRelationship" + Iam;
            RightForkRelationship.Size = new Size(30, 30);
            RightForkRelationship.Visible = true;
            RightForkRelationship.BackColor = Color.Transparent;
            RightForkRelationship.BorderStyle = BorderStyle.None;
            RightForkRelationship.Location = RightForkRelationshipUIPoints[Iam];
            RightForkRelationship.BringToFront();
            ProgramUI.Controls.Add(RightForkRelationship);

        }
        public void BiteTaken()
        {
            Progress.Invoke(new ProgressBarDelegate(BiteTakenUI));

        }

        public void GrantedLeftFork()
        {
            LeftForkRelationship.Invoke(new LeftForkRelationshipDelegate(GrantedLeftForkUI));
            System.Threading.Thread.Sleep(1000);

        }

        public void GrantedRightFork()
        {
            RightForkRelationship.Invoke(new RightForkRelationshipDelegate(GrantedRightForkUI));
            System.Threading.Thread.Sleep(1000);

        }

        public void DeniedLeftFork()
        {
            LeftForkRelationship.Invoke(new LeftForkRelationshipDelegate(DeniedLeftForkUI));
            System.Threading.Thread.Sleep(1000);


        }

        public void DeniedRightFork()
        {
            RightForkRelationship.Invoke(new RightForkRelationshipDelegate(DeniedRightForkUI));
            System.Threading.Thread.Sleep(1000);

        }

        public void ReleasedLeftFork()
        {
            LeftForkRelationship.Invoke(new LeftForkRelationshipDelegate(ReleasedLeftForkUI));
            System.Threading.Thread.Sleep(1000);

        }

        public void ReleasedRightFork()
        {
            RightForkRelationship.Invoke(new RightForkRelationshipDelegate(ReleasedRightForkUI));
            System.Threading.Thread.Sleep(1000);

        }

        private void BiteTakenUI()
        {
            Progress.Value += 1;

        }

        private void GrantedLeftForkUI()
        {
            LeftForkRelationship.BackColor = Color.Green;
            LeftForkRelationship.Refresh();


        }

        private void GrantedRightForkUI()
        {
            RightForkRelationship.BackColor = Color.Green;
            RightForkRelationship.Refresh();

        }

        private void DeniedLeftForkUI()
        {
            LeftForkRelationship.BackColor = Color.Red;
            LeftForkRelationship.Refresh();

        }

        private void DeniedRightForkUI()
        {
            RightForkRelationship.BackColor = Color.Red;
            RightForkRelationship.Refresh();

        }

        private void ReleasedLeftForkUI()
        {
            LeftForkRelationship.BackColor = Color.Transparent;
            LeftForkRelationship.Refresh();

        }

        private void ReleasedRightForkUI()
        {

            RightForkRelationship.BackColor = Color.Transparent;
            RightForkRelationship.Refresh();

        }




    }
}
