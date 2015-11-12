using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogic
{
    [Serializable]
    public class PriceS
    {
        public int id;
        public string name;
        public string description;
        public byte[] image;
        public byte[] path;

    }
}