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
            PricePoolS[] pricepoolS = null;

            if (eventS != null)
            {
                pricepoolS = EventsServices.Instance.GetPricePool(eventS.id);
                result.eventS = eventS;

                if (pricepoolS != null)
                {
                    result.pricePoolS = new PricePoolS[pricepoolS.Length];
                    result.priceS = new PriceS[pricepoolS.Length];

                    for (int i = 0; i < pricepoolS.Length; i++)
                    {
                        result.pricePoolS[i] = pricepoolS[i];
                        result.priceS[i] = EventsServices.Instance.GetPrice(pricepoolS[i].priceId);
                    }

                    return result;
                }

            }
            return null;
        }
    }
}
