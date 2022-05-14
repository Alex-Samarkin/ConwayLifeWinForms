using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayLibrary
{
    public class TCell
    {
        public enum KindOfState
        {
            Dead = 0,
            Live = 1
        }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public KindOfState State { get; set; } = KindOfState.Dead;

        public KindOfState RandomState(int percent = 50)
        {
            percent = (percent % 100 + 100) % 100;
            Random r = new Random();
            if (r.Next(100)<percent)
            {
                return State=KindOfState.Live;
            }

            return State = KindOfState.Dead;
        }

        private int Random(int from = 0, int to = 250) => (new Random()).Next(from,to);

        public TCell RandomXY(int from = 0, int to = 250, KindOfState state = KindOfState.Live)
        {
            X = Random(from,to);
            Y = Random(from,to);
            State = state;
            return this;
        }
    }
}
