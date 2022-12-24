using System.Threading;

namespace PhilosophersAndSpaghetti
{
    public class Supervisor
    {
        public ProgramUI ProgramUI { get; set; }
        private Philosopher[] Philosopher;
        private Thread[] PhilosopherThread;
        private Fork[] Fork;
 
        public Supervisor()
        {
            Fork = new Fork[6];
            Philosopher = new Philosopher[6];
            PhilosopherThread = new Thread[6];

        }

        public Thread Arise()
        {
            Thread MyLife;

            MyLife = new Thread(LetsGo);
            MyLife.IsBackground = true;
            MyLife.Priority = ThreadPriority.Normal;
            MyLife.Start();


            return MyLife;



        }


        private void LetsGo()
        {
            int i;

            for (i = 1; i < 6; i++)
            {
                Fork[i] = new Fork();
            }

            for (i = 1; i < 6; i++)
            {
                if (i == 1)
                {
                    Philosopher[i] = new Philosopher(i, this, ProgramUI.PhilosopherUI(i), Fork[i], Fork[5]);
                }
                else
                {
                    Philosopher[i] = new Philosopher(i, this, ProgramUI.PhilosopherUI(i),Fork[i], Fork[i - 1]);
                }

                PhilosopherThread[i] = Philosopher[i].Arise();


            }

            for (i = 1; i < 6; i++)
            {
                PhilosopherThread[i].Join();
            }



        }




    }
}
