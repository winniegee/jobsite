using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPlatform.Messaging
{
    public class EmailMessage
    {
        public String Subject { get; set; }
        public String From { get; set; }
        public String Recipient { get; set; }
        public String Body { get; set; }
    }
}