This work is dedicated to the memory of Professor Clifford Pelletier.  Prof. Pelletier was the
hardest instructor in my undergrad program.  He had a way of pushing students to do the best 
they could do - not the typical minimum most aspire to. Finishing his class was always something
to celebrate.  

I came to understand 10 years later how valuable his pushing me was.  I had a great career built 
on the rock established back in my undergrad days.  But - in the 30 years between this revelation
and today - I never bothered to look him up and thank him.  I learned very recently that I 
no longer have opportunity to do so. 

Prof. Pelletier also instilled in us - back in the '70s - the idea of Life Long Learning.  So - 
now retired - why not do this project in his memory.  And boy did I learn some things.... 


O.K. - NOW THE GOOD STUFF ....


You will find examples of multithreaded applications all over the internet.  You will find examples
of WinForm all over the internet.  But WinForm that are multithreaded - hard to come by.  I hope - 
having stumbled on this - it fills that gap for you. 

This is an implementation of the classic Dining Philosophers problem first identified in 1965.
(https://en.wikipedia.org/wiki/Dining_philosophers_problem)  You will find several solutions to 
this problem on the internet.  However - those I found are all console applications.  Print
"Philosopher 1 is eating" type of apps.  This one has a GUI.

I have used cooperative (a.k.a. non-pre-emptive) multitasking to address the problem.  That is - if a 
philosopher acquires her/his left fork - but is denied the right fork (The scenario that happens on
the first iteration after the start button is pressed) he/she voluntarily yields the left fork.
More on this in design below. 


BIG LEARNINGS FOR ME .....

If you do multithreaded GUI programming - all this stuff is probably old hat.  But then - why would 
you be looking for an example?  :)

The first thing I learned was the UI thread.  In a typical WinForm this is called from main() via 
the Application.Run statement.  This establishes the Message Pump for the application.  The typical
single thread WinForm app is event driven.  It responds to events that occur in the UI by calling 
event handlers.  BIG LEARNING - if the thread running the pump becomes blocked - the UI freezes.
A really good article covering this in depth is: 
https://visualstudiomagazine.com/Articles/2010/11/18/Multithreading-in-WinForms.aspx?m=1&Page=1 
The source code from that article is worth playing with. 

Second Learning - you cannot manipulate the UI on any thread other then the UI thread.  So - where you 
need to manipulate the UI from the Philosopher thread - you need to push a message to the Pump.  You 
do this by passing a delegate (code) to the UI thread via the invoke method available on classes you 
inherit from WinForms. 

Third - I learned there are two types of multitasking in Windows apps.  Threads and Tasks.  Tasks contain
at least 1 thread.  Tasks are used when you want to start some unit of work that will finish sometime in 
the future - you don't care when.  (White lie.  You have to finish before the process ends.)  Good 
example - the email send key.  You (the human user) want your email sent - but you do not want to be 
delayed while the computer is doing this.  You want to read the next message.  Two points - I use 
threads here because there are common resources in use - and the process interact.  And two - be careful
when you Google this stuff.  You will get hits involving both tasking and threading.  Understand which 
you are using and treat posts addressing the other appropriately.  

Fourth - Random number generation (specifically with the Random class in .Net) is a small challenge. 
Calls to Random must be thread safe.  A suggested way to do this is by including a random in each 
instance of a class.  (Which I have done here.)  The issue is - if you do not supply a specific seed 
for these instances - they use Environment.TicCount.  Where instances are instantiated in tight order
like in a loop - the variance in seed can be minimal.   For this reason - I pass the PhilosopherId 
as a seed to Random.  So the seeds become 1, 2, 3, 4 and 5.  Take the seed out if you want to play 
with it.   Good article:  
https://devblogs.microsoft.com/pfxteam/getting-random-numbers-in-a-thread-safe-way/


DESIGN POINTS .....

I am aware arrays are 0 based.  In many cases - I leave the 0 element void - and populate positions 
1 - 5.  The reason I did that is I have a UI with 5 philosophers numbered 1 through 5.  I did not want
Object[0] refers to Philosopher 1, Object[1] refers to Philosopher 2 etc.  I could have numbered the 
philosophers on the UI 0 - 4.  But is is a UI.  1-5 seemed more natural so ... that's the way it is.

I have been very stringent separating UI code from problem code.  There is a PhilosopherUI class and 
a Philosopher class.  The problem at hand is addressed in the nonUI classes.  The minutiae of dealing 
with the UI (including the delegate and invoke stuff) is handled in the UI class.  Important - I 
achieve separation of function (code) this way.  There are 5 philosopher threads.  Each thread executes
both problem and UI code. 


SUPERVISOR ........

Finally - there is Supervisor - both a class and a thread.  Lots of design stuff going on here ...

First - as I stated above - I wanted a good clean separation between UI and Problem code.  One issue - 
the scenario begins when the user presses the start button on the UI.  So - when that happens - the UI
must reach out to the problem code.  I wanted to keep this interaction to a minimum.  So from the UI 
code - I wake up the supervisor.  The supervisor does everything else.  (It builds non UI Philosophers, 
forks etc.)

Second - I became very aware during this project that blocking the UI thread is a bad thing.  By nature 
things that happen in the Button Click event are executed on the UI thread.  I wanted to get off the 
UI Thread (both logic and process) as quickly and as cleanly as possible.  The Supervisor class is how 
I do this.    

Third - you will notice the Supervisor thread simply spins up the business objects - launches the 5 
philosophers - and then waits for all the philosophers to finish.  That seems kind of lame.  Why not 
do that from the UI thread?  Well one - bad architecture.  Second - suppose at some future time I 
want to do something at the end of the scenario.  Say I want to make a database call to preserve the 
results of this run.  If executed on the UI thread - the Database call would block the UI.  Finally
notice the thread waits for the Philosophers.  (The Philosopher.Thread[].Join line.)  Execute that on 
the UI thread - and the UI is worthless.  (Believe me I made that mistake a few times.) 

Fourth - as I stated above - this implementation uses non-preemtive multitasking.  The next logical place 
for me to take this project is into a preemptive model.  There the philosopher would not yield the left 
fork on denial of the right fork.  A success or failure acquire implemented here would be replaced by 
an acquire and wait method.  The Supervisor will be required to resolve deadlocks that will occur.




All the best and good luck.  Please keep on learning. 

John Flannery
December 22, 2022
       






  