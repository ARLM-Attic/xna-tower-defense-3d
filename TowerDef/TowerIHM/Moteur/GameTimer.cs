using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TowerDef.moteur
{
    class GameTimer
    {
        static int tic;
        static int tic_par_sec;
        static Timer myTimer;

        public GameTimer(int ms) 
        {
            myTimer = new Timer(ms);
            myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public void Start() 
        {
            myTimer.Start();
        }

        public void Stop() 
        {
            myTimer.Stop();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            tic = (tic ++) % tic_par_sec;
        }

    }
}
