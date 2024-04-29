using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class SystemMessage
    {
        public string message = "";
        public SystemMessage() { }

        public void SetMessage(string message)
        {
            this.message = message + "\n";
        }

        public void PrintMessage()
        {
            int currentCursor = Console.GetCursorPosition().Top;
            Console.SetCursorPosition(0, currentCursor + 4);
            Console.Write(message);
            Console.SetCursorPosition(0, currentCursor);
            message = "";
        }
    }
}
