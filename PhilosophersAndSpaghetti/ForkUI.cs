using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PhilosophersAndSpaghetti
{
    internal class ForkUI
    {

        private static Point[] ForkUIPoints =
        {
            new Point(0,0),
            new Point(325, 20),          // 1
            new Point(125, 280),         // 2
            new Point(450, 400),         // 3
            new Point(600, 280),         // 4
            new Point(555, 20)           // 5
         };

        private PictureBox PictureBox;
        private int Iam;
        private ProgramUI ProgramUI;

        public ForkUI(int pForkNumber, ProgramUI pProgramUI)
        {
            Bitmap ForkBitMap; 

            Iam = pForkNumber;
            ProgramUI = pProgramUI;
            


            PictureBox = new System.Windows.Forms.PictureBox();
            PictureBox.Name = "Fork" + Iam;
            PictureBox.Visible = true;
            PictureBox.BackColor = Color.Black;
            PictureBox.Location = ForkUIPoints[Iam];

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("PhilosophersAndSpaghetti.Images.Fork.JPG");
            ForkBitMap = new Bitmap(stream);

            switch (Iam)
            {
                case 2:
                    PictureBox.Size = new Size(182,32);
                    ForkBitMap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 4:
                    PictureBox.Size = new Size(182, 32);
                    ForkBitMap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                default:
                    PictureBox.Size = new Size(32, 182);
                    break;
            }

            PictureBox.Image = ForkBitMap;
            PictureBox.SendToBack();

            ProgramUI.Controls.Add(PictureBox);

        }
    }

}
