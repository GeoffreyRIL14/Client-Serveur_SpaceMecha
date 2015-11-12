using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebLogic
{
    /// <summary>
    /// Description résumée de ClientServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class ClientServices : System.Web.Services.WebService
    {

        [WebMethod]
        public ProfilS CreateProfil(string name, string tokenId = "")
        {
            return EventsServices.Instance.CreateProfil(name, tokenId); ;
        }

        [WebMethod]
        public ProfilS GetProfil(string name, string tokenId = "")
        {
            return EventsServices.Instance.GetProfil(name, tokenId); ;
        }

        [WebMethod]
        public bool UpdateGroupSign(int eventId, int profilId, int score)
        {
            return EventsServices.Instance.CreateOrUpdateGroupSign(eventId, profilId, score);
        }

        [WebMethod]
        public EventGame GetEventGame()
        {
            EventGame result = new EventGame();
            EventS eventS = EventsServices.Instance.GetCurrentEvent(DateTime.Now);
            PricePoolS[] pricepools = null;

            if (eventS != null)
            {
                pricepools = EventsServices.Instance.GetPricePool(eventS.id);
                result.events = eventS;

                if (pricepools != null)
                {
                    result.pricePools = new PricePoolS[pricepools.Length];
                    result.prices = new PriceS[pricepools.Length];

                    for (int i = 0; i < pricepools.Length; i++)
                    {
                        result.pricePools[i] = pricepools[i];
                        result.prices[i] = EventsServices.Instance.GetPrice(pricepools[i].priceId);
                    }

                    return result;
                }

            }
            return null;
        }
    }
}
