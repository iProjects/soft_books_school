using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace DAL
{

    public partial class GSMMessage
    {
        public int Id { get; set; }

        public string MessageBody { get; set; }

        public string Storage { get; set; }

        public string Status { get; set; }

        public string UserDataText { get; set; }

        public string SmscAddressType { get; set; }

        public string SmscAddress { get; set; }

        public string SCTimestamp { get; set; }

        public string OriginatingAddressType { get; set; }

        public string OriginatingAddress { get; set; }

        public string MessageType { get; set; }

        public string MessageIndex { get; set; }

        public string MessageStatus { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? Processed { get; set; }


    }
}