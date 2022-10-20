using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRest
{
    public class Table
    {
        public State State { get; private set; }

        public int SeatsCount { get; }

        public int Id { get; }

        private object _lockObj = new object();

        private bool isLock = false;

        public Table(int id)
        {
            Id = id;
            State = State.Free;
            var rand = new Random();
            SeatsCount = 2;// rand.Next(2, 5);
        }

        public bool SetState(State state)
        {
            lock (_lockObj)
            {
                if (state == State) return false;

                State = state;

                return true;
            }
            
        }

    }
}
