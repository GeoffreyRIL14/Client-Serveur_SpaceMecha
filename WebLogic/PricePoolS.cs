using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogic
{
    [Serializable]
    public class PricePoolS
    {
        public int id;
        public int eventId;
        public int priceId;
        public float placePercent;
        public int placeRangeMin;
        public int placeRangeMax;
    }
}