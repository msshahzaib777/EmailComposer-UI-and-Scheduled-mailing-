using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163810_Q3
{
    [Serializable]
    public class EmailMessage
    {
        public string To;
        public string Subject;
        public string MessageBody;

        public EmailMessage() { }

        public EmailMessage(string to_, string subject_, string messagebody_ )
        {
            this.To = to_;
            this.Subject = subject_;
            this.MessageBody = messagebody_;
        }

        public void reset(string to_, string subject_, string messagebody_)
        {
            this.To = to_;
            this.Subject = subject_;
            this.MessageBody = messagebody_;
        }
    }
}
