using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3MessageBoxAsync
{
    public class MessageBox
    {
        public enum State
        {
            Ok,
            Cancel
        }
        Random random = new();

        public async void Open()
        {
            StateTransmit += StateTrans;

            var randomInt = random.Next(2);            
            
            Console.WriteLine("Window Open");
            Thread.Sleep(3000);
            Console.WriteLine("Window closed by user");
            if (randomInt == 0)
            {
                StateTransmit(State.Ok);
            }
            if (randomInt == 1)
            {
                StateTransmit(State.Cancel);
            }
        }

        public delegate void StateTransmitter(State state);
        public event StateTransmitter StateTransmit;
        public void StateTrans(State state)
        {
            if (state == State.Ok)
            {
                Console.WriteLine($"{state} - Operation confirmed");
            }
            if(state == State.Cancel)
            {
                Console.WriteLine($"{state} - Operation canceled");
            }
        }
    }
}
