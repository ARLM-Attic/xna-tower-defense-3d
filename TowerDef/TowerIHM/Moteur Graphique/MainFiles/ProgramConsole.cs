using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Timers;

namespace TowerIHM
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        public static Form1 f;
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f = new Form1();
            Application.Run(f);
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            // Set the Interval to 5 seconds.
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            System.Timers.Timer bTimer = new System.Timers.Timer();
            bTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
            // Set the Interval to 5 seconds.
            bTimer.Interval = 1000;
            bTimer.Enabled = true;
        }
           private static void OnTimedEvent(object source, ElapsedEventArgs e)
           {
               f.Refresh();
           }
           private static void OnTimedEvent2(object source, ElapsedEventArgs e)
           {
            
           }
        }
    }
