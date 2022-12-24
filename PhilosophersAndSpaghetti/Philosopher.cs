using System;
using System.Threading;


namespace PhilosophersAndSpaghetti
{
    public class Philosopher
    {

        private readonly int Iam;
        private readonly Supervisor Boss;
        private readonly PhilosopherUI MyUI;
        private readonly Fork LeftFork;
        private readonly Fork RightFork;


        public Philosopher(int pIam, Supervisor pBoss, PhilosopherUI pMyUI, Fork pLeftFork, Fork pRightFork)
        {
            Iam = pIam;
            Boss = pBoss;
            MyUI = pMyUI;
            LeftFork = pLeftFork;
            RightFork = pRightFork;



        }

        public Thread Arise()
        {

            Thread MyLife;
            
            MyLife = new Thread(EatPhilosophise);
            MyLife.IsBackground = true;
            MyLife.Priority = ThreadPriority.BelowNormal;
            MyLife.Start();


            return MyLife;

        }


        private void EatPhilosophise()
        {
            Random Randomizer = new Random(Iam);              
            bool Success;
            int i = 0;

            while (i < 5)
            {

                Success = LeftFork.AcquireFork(Iam);
                if (Success)
                {
                    MyUI.GrantedLeftFork();
                    Success = RightFork.AcquireFork(Iam);
                    if (Success)
                    {
                        MyUI.GrantedRightFork();
                        MyUI.BiteTaken();
                        i++;
                        LeftFork.ReleaseFork(Iam);
                        RightFork.ReleaseFork(Iam);

                    }
                    else
                    {
                        MyUI.DeniedRightFork();
                        LeftFork.ReleaseFork(Iam);

                    }
                }
                else
                {
                    MyUI.DeniedLeftFork();
                }

                MyUI.ReleasedLeftFork();
                MyUI.ReleasedRightFork();


                System.Threading.Thread.Sleep((Randomizer.Next(1, 8) * 1000));

            }


        }







    }
}
