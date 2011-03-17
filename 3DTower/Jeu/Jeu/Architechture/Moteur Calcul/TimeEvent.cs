using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class TimeEvent
    {
        List<IAction> ls;
        private int i;

        public TimeEvent()
        {
            i = 0;
            ls = new List<IAction>();
        }

        public void AjouterEvents(IAction action) 
        {
            ls.Add(action);
        }

        public void SupprimerEvents(IAction action) 
        {
            ls.Remove(action);
        }

        public void Action() 
        {
            foreach (IAction a in ls)
            {
                a.Action();
            }
        }
    }
}
