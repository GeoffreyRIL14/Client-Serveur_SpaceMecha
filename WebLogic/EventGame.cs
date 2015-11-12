using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLogic
{
    [Serializable]
    public class EventGame
    {
        public EventS events;
        public PricePoolS[] pricePools;
        public PriceS[] prices;
    }
}
