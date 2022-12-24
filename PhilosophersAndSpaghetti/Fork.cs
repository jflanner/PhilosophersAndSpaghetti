using System;

namespace PhilosophersAndSpaghetti
{
    public class Fork
    {
        private readonly object ForkLock = new object();
        private int Owner;

        public Fork()
        {
            Owner = 0;
        }

        public bool AcquireFork(int RequestedOwner)
        {
            bool Success = false;

            lock (ForkLock) 
            { 
                 if (Owner == 0)
                 {
                     Owner = RequestedOwner;
                     Success = true;
                 }   
            }

            return (Success);

        }

        public void ReleaseFork(int AssertedOwner)
        {

            lock (ForkLock)
            {
                if (Owner == AssertedOwner)
                {
                    Owner = 0;
                }
                else
                {
                    throw new ArgumentException("Attempt to release fork came from philosopher who is not the owner.");
                }
            }


        }











    }
}
