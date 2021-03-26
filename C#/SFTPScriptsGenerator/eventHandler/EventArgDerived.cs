using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator.eventHandler
{
    public class EventArgDerived : EventArgs
    {
        private readonly string message;

        public EventArgDerived(string msg)
        {
            this.message = msg;
        }

        public string Message
        {
            get { return this.message; }
        }
    }
}
