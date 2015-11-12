using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogic
{
    [Serializable]
    public class EventS
    {
        public int id;
        public string name;
        public byte[] image;
        public string description;
        public DateTime startDate;
        public DateTime endDate;
    }
}