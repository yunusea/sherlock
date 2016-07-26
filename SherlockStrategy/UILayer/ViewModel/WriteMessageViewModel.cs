using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UILayer.ViewModel
{
    public class WriteMessageViewModel
    {
        public User SenderName { get; set; }
        public User ReceiverName { get; set; }
    }
}