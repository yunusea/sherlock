using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UILayer.ViewModel
{
    public class ReadMessageViewModel
    {
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public Message Message { get; set; }
    }
}