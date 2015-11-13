using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebLogic
{

    /// <summary>
    /// Description résumée de EventsServices - ceci est un test
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class EventsServices : System.Web.Services.WebService
    {
        public const string IMAGE_PATH = "C:\\inetpub\\Master\\";

        private static EventsServices instance;
        public static EventsServices Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventsServices();
                return instance;
            }
        }

        [WebMethod]
        public ProfilS CreateProfil(string name, string tokenId = "")
        {

            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Profil profil = null;
                profil = db.Profil.SingleOrDefault(p => p.Name == name);

                if (profil == null)
                {
                    if (tokenId == "")
                    {
                        Random random = new Random();
                        tokenId = random.Next().ToString();
                    }

                    profil = new Profil();
                    profil.Name = name;
                    profil.TokenId = tokenId;
                    profil.Avatar = "";
                    profil.Rank = 0;
                    db.Profil.InsertOnSubmit(profil);

                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR CreateProfil " + ex.Message);
                        return null;
                    }
                }
                else
                {
                    profil = new Profil()
                    {
                        idProfil = -1,
                        Name = "",
                        Avatar = "",
                        Rank = 0,
                        TokenId = ""
                    };
                }

                return new ProfilS() {
                    id = profil.idProfil, 
                    name = profil.Name, 
                    avatar = profil.Avatar,
                    rank = profil.Rank,
                    tokenid = profil.TokenId
                };
            }
        }


        [WebMethod]
        public ProfilS GetProfil(string name, string tokenid = "")
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                var profil = db.Profil.SingleOrDefault(p => p.Name == name);

                if (profil == null)
                {
                    return CreateProfil(name, tokenid);
                }
                else if (tokenid == profil.TokenId)
                {
                    if (tokenid == "")
                    {
                        Random random = new Random();
                        tokenid = random.Next().ToString();
                        profil.TokenId = tokenid;
                        db.Profil.InsertOnSubmit(profil);
                        db.SubmitChanges();
                    }

                    return new ProfilS()
                    {
                        id = profil.idProfil,
                        name = profil.Name,
                        avatar = profil.Avatar,
                        rank = profil.Rank,
                        tokenid = profil.TokenId
                    };
                }
                else
                {
                    return new ProfilS()
                    {
                        id = -1,
                        name = "",
                        avatar = "",
                        rank = 0,
                        tokenid = ""
                    };
                }
            }
        }

        [WebMethod]
        public int CreateOrUpdateEvent(int id, string name, DateTime startDate, DateTime endDate, byte[] image, string description)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Event eventGame = null;
                if (id == 0)
                {
                    eventGame = new Event()
                    {
                        Name = name,
                        StartDate = startDate,
                        EndDate = endDate,
                        Image = "",
                        Description = description
                    };

                    db.Event.InsertOnSubmit(eventGame);
                }
                else
                {
                    eventGame = db.Event.SingleOrDefault(e => e.idEvent == id);
                    if (name != "")
                    {
                        eventGame.Name = name;
                    }
                    eventGame.StartDate = startDate;
                    eventGame.EndDate = endDate;
                    if (description != "")
                    {
                        eventGame.Description = description;
                    }
                }
                try
                {
                    if (image != null)
                    {
                        if (id == 0)
                            db.SubmitChanges();

                        string path = IMAGE_PATH + "events\\" + eventGame.idEvent + "-" + eventGame.Name;
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(IMAGE_PATH + "events\\" + eventGame.idEvent + "-" + eventGame.Name);

                        using (FileStream fs = new FileStream(path + "\\" + "cover", FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fs.Write(image, 0, image.Length);
                            eventGame.Image = path + "\\" + "cover";
                        }
                    }
                                       
                    db.SubmitChanges();

                    return eventGame.idEvent;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR CreateEvent " + ex.Message);
                    return -1;
                }
            }
        }
        [WebMethod]
        public bool DeleteEvent(int id)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Event eventGame = null;
                eventGame = db.Event.SingleOrDefault(e => e.idEvent == id);

                if (eventGame != null)
                {
                    if (Directory.Exists(IMAGE_PATH + "event\\" + eventGame.idEvent + "-" + eventGame.Name))
                        Directory.Delete(IMAGE_PATH + "event\\" + eventGame.idEvent + "-" + eventGame.Name);
                    
                    db.Event.DeleteOnSubmit(eventGame);

                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR Delete Event " + ex.Message);
                        
                    }
                }
                return false;
            }
        }
        [WebMethod]
        public EventS GetCurrentEvent(DateTime date)
        { 
            using(MasterDBDataContext db = new MasterDBDataContext())
            {
                Event eventGame = null;

                eventGame = db.Event.FirstOrDefault(e => e.StartDate < date && e.EndDate > date);

                if (eventGame != null)
                {
                    EventS ev = new EventS()
                    {
                        id = eventGame.idEvent,
                        startDate = eventGame.StartDate,
                        endDate = eventGame.EndDate,
                        description = eventGame.Description,
                        name = eventGame.Name
                    };
                    if (!String.IsNullOrEmpty(eventGame.Image))
                        using (FileStream fs = new FileStream(eventGame.Image, FileMode.Open, FileAccess.Read))
	                {
		                byte[] bytes = new byte[fs.Length];
                        int numBytesToRead = (int)fs.Length;
                        int numBytesRead = 0;
                        while (numBytesToRead > 0)
                        {
                            // Read may return anything from 0 to numBytesToRead.
                            int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                            if (n == 0)
                                break;

                            numBytesRead += n;
                            numBytesToRead -= n;
                        }

                        ev.image = bytes;
	                }

                    return ev;
                }
            }
            return null;
        }
        [WebMethod]
        public EventS GetEvent(int id)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Event eventGame = null;

                eventGame = db.Event.FirstOrDefault(e => e.idEvent == id);

                if (eventGame != null)
                {
                    EventS ev = new EventS()
                    {
                        id = eventGame.idEvent,
                        startDate = eventGame.StartDate,
                        endDate = eventGame.EndDate,
                        description = eventGame.Description,
                        name = eventGame.Name
                    };
                    if (!String.IsNullOrEmpty(eventGame.Image))
                        using (FileStream fs = new FileStream(eventGame.Image, FileMode.Open, FileAccess.Read))
                        {
                            byte[] bytes = new byte[fs.Length];
                            int numBytesToRead = (int)fs.Length;
                            int numBytesRead = 0;
                            while (numBytesToRead > 0)
                            {
                                // Read may return anything from 0 to numBytesToRead.
                                int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                                if (n == 0)
                                    break;

                                numBytesRead += n;
                                numBytesToRead -= n;
                            }

                            ev.image = bytes;
                        }

                    return ev;
                }
            }
            return null;
        }

        [WebMethod]
        public EventS[] GetEvents()
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                EventS[] result;

                var events = db.Event.ToArray();
                if (events != null)
                {
                    result = new EventS[events.Length];

                    for (int i = 0; i < events.Length; i++)
                    {
                        result[i] = new EventS()
                        {
                            id = events[i].idEvent,
                            startDate = events[i].StartDate,
                            endDate = events[i].EndDate,
                            description = events[i].Description,
                            name = events[i].Name
                        };

                        if(!String.IsNullOrEmpty(events[i].Image))
                            using (FileStream fs = new FileStream(events[i].Image, FileMode.Open, FileAccess.Read))
	                    {
		                    byte[] bytes = new byte[fs.Length];
                            int numBytesToRead = (int)fs.Length;
                            int numBytesRead = 0;
                            while (numBytesToRead > 0)
                            {
                                // Read may return anything from 0 to numBytesToRead.
                                int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                                if (n == 0)
                                    break;

                                numBytesRead += n;
                                numBytesToRead -= n;
                            }

                            result[i].image = bytes;
	                    }
                        
                    }
                    return result;                 
                }
            }
            return null;
        }

        

        [WebMethod]
        public bool CreateOrUpdateGroupSign(int eventId, int profilId, int score)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Event eventGame = db.Event.SingleOrDefault(e => e.idEvent == eventId);
                Profil profil = db.Profil.SingleOrDefault(p => p.idProfil == profilId);

                if (eventGame != null && profil != null)
                {
                    GroupSign groupSign = null;
                    groupSign = db.GroupSign.SingleOrDefault(gs => gs.idEvent == eventId && gs.idProfil == profilId);

                    if (groupSign == null)
                    {
                        groupSign = new GroupSign()
                        {
                            idEvent = eventId,
                            idProfil = profil.idProfil,
                            Score = score
                        };

                        db.GroupSign.InsertOnSubmit(groupSign);
                    }
                    else
                        groupSign.Score = score;

                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Create Group Sign " + ex.Message);
                        return false;
                    }
                }
            }
            return true;
        }
        [WebMethod]
        public bool CreatePricePool(int priceId, int eventId, int placeRangeMin, int placeRangeMax, float placePercent)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Event group = db.Event.SingleOrDefault(g => g.idEvent == eventId);
                if (group != null)
                {
                    PricePool pricePool = new PricePool()
                    { 
                        idPrice = priceId,
                        idEvent = eventId,
                        placeRangeMin = placeRangeMin,
                        placeRangeMax = placeRangeMax,
                        placePurcent = placePercent
                    };

                    db.PricePool.InsertOnSubmit(pricePool);

                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CREATE PRICEPOOL " + ex.Message); 
                    }
                }

                return false;
            }
        }
        [WebMethod]
        public bool CreateOrUpdatePricePool(int id, int priceId, int eventId, int placeRangeMin, int placeRangeMax, float placePercent)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Event group = db.Event.SingleOrDefault(g => g.idEvent == eventId);
                if (group != null)
                {
                    PricePool pricePool = db.PricePool.SingleOrDefault(pp => pp.idPricePool == id);

                    if (pricePool == null)
                    {
                        pricePool = new PricePool()
                        {
                            idPrice = priceId,
                            idEvent = eventId,
                            placeRangeMin = placeRangeMin,
                            placeRangeMax = placeRangeMax,
                            placePurcent = placePercent
                        };

                        db.PricePool.InsertOnSubmit(pricePool);
                    }
                    else
                    {
                        pricePool.idEvent = eventId;
                        pricePool.idPrice = priceId;
                        pricePool.placeRangeMax = placeRangeMax;
                        pricePool.placeRangeMin = placeRangeMin;
                        pricePool.placePurcent = placePercent;
                    }

                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CREATE PRICEPOOL " + ex.Message);
                    }
                }

                return false;
            }
        }

        [WebMethod]
        public PricePoolS[] GetPricePool(int eventId)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                var pricePools = db.PricePool.Where(pp => pp.idEvent == eventId);

                if (pricePools != null)
                {
                    PricePoolS[] result = new PricePoolS[pricePools.ToArray().Length];
                    PricePool[] temp = pricePools.ToArray();

                    for (int i = 0; i < temp.Length; i++)
			        {
			            result[i] = new PricePoolS()
                        {
                            id = temp[i].idPricePool,
                            eventId = (int)temp[i].idEvent,
                            priceId = (int)temp[i].idPrice,
                            placeRangeMin = temp[i].placeRangeMin,
                            placeRangeMax = temp[i].placeRangeMax,
                            placePercent = (float)temp[i].placePurcent
                        };
			        }

                    return result;
                }                    
                else
                    return null;
            }
        }

        [WebMethod]
        public bool CreatePrice(string name, string image, string description, string path)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Price price = new Price() { 
                    Name = name,
                    Image = image,
                    Description = description,
                    Path = path
                };

                db.Price.InsertOnSubmit(price);

                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR CreatePrice " + ex.Message);
                }

                return false;
            }
        }

        [WebMethod]
        public int CreateOrUpdatePrice(int id, string name, byte[] image, byte[] asset, string description)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Price price = null;
                if (id == 0)
                {
                    price = new Price()
                    {
                        Name = name,
                        Image = "",
                        Path = "",
                        Description = description
                    };

                    db.Price.InsertOnSubmit(price);
                }
                else
                {
                    price = db.Price.SingleOrDefault(e => e.idPrice == id);

                    if (name != "")
                        price.Name = name;

                    if (description != "")
                        price.Description = description;
                }
                try
                {
                    if (image != null || asset != null)
                    {
                        if (id == 0)
                            db.SubmitChanges();

                        string path = IMAGE_PATH + "prices\\" + price.idPrice + "-" + price.Name;
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(IMAGE_PATH + "prices\\" + price.idPrice + "-" + price.Name);

                        if (image != null)
                        {
                            using (FileStream fs = new FileStream(path + "\\" + "cover", FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                fs.Write(image, 0, image.Length);
                                price.Image = path + "\\" + "cover";
                            }
                        }

                        if (asset != null)
                        {
                            using (FileStream fs = new FileStream(path + "\\" + "asset", FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                fs.Write(asset, 0, asset.Length);
                                price.Path = path + "\\" + "asset";
                            }
                        }
                    }

                    db.SubmitChanges();

                    return price.idPrice;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR CreateEvent " + ex.Message);
                    return -1;
                }
            }
        }

        [WebMethod]
        public PriceS GetPrice(int id)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Price price = db.Price.SingleOrDefault(p => p.idPrice == id);
                if (price != null)
                {
                    PriceS result = new PriceS()
                    {
                        id = price.idPrice,
                        name = price.Name,
                        description = price.Description
                    };

                    if (!String.IsNullOrEmpty(price.Image))
                        using (FileStream fs = new FileStream(price.Image, FileMode.Open, FileAccess.Read))
                        {
                            byte[] image = new byte[fs.Length];
                            int numBytesToRead = (int)fs.Length;
                            int numBytesRead = 0;
                            while (numBytesToRead > 0)
                            {
                                // Read may return anything from 0 to numBytesToRead.
                                int n = fs.Read(image, numBytesRead, numBytesToRead);

                                if (n == 0)
                                    break;

                                numBytesRead += n;
                                numBytesToRead -= n;
                            }

                            result.image = image;
                        }

                    if (!String.IsNullOrEmpty(price.Path))
                        using (FileStream fs = new FileStream(price.Image, FileMode.Open, FileAccess.Read))
                        {
                            byte[] asset = new byte[fs.Length];
                            int numBytesToRead = (int)fs.Length;
                            int numBytesRead = 0;
                            while (numBytesToRead > 0)
                            {
                                // Read may return anything from 0 to numBytesToRead.
                                int n = fs.Read(asset, numBytesRead, numBytesToRead);

                                if (n == 0)
                                    break;

                                numBytesRead += n;
                                numBytesToRead -= n;
                            }

                            result.path = asset;
                        }

                    return result;
                }

                return null;
            }
        }
        [WebMethod]
        public PricePoolS[] GetPricePools()
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                var pricePools = db.PricePool.ToArray();

                if (pricePools != null)
                {
                    PricePoolS[] result = new PricePoolS[pricePools.Length];

                    for (int i = 0; i < pricePools.Length; i++)
                    {
                        result[i] = new PricePoolS()
                        {
                            id = pricePools[i].idPricePool,
                            eventId = (int) pricePools[i].idEvent,
                            priceId = (int) pricePools[i].idPrice,
                            placeRangeMax = pricePools[i].placeRangeMax,
                            placeRangeMin = pricePools[i].placeRangeMin,
                            placePercent = (float) pricePools[i].placePurcent
                        };                        
                    }          
                    return result;
                }
                return null;
            }
        }
        [WebMethod]
        public bool DeletePrice(int id)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                Price price = null;
                price = db.Price.SingleOrDefault(p => p.idPrice == id);

                if (price != null)
                {
                    if (Directory.Exists(IMAGE_PATH + "prices\\" + price.idPrice + "-" + price.Name))
                        Directory.Delete(IMAGE_PATH + "prices\\" + price.idPrice + "-" + price.Name);

                    db.Price.DeleteOnSubmit(price);

                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR Delete Price " + ex.Message);

                    }
                }
                return false;
            }
        }
        [WebMethod]
        public bool DeletePricePool(int id)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                PricePool pricePool = null;
                pricePool = db.PricePool.SingleOrDefault(p => p.idPricePool == id);

                if (pricePool != null)
                {
                    db.PricePool.DeleteOnSubmit(pricePool);

                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR Delete Price Pool " + ex.Message);

                    }
                }
                return false;
            }
        }
        [WebMethod]
        public bool DeletePricepool(int id)
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                var pricepool = db.PricePool.SingleOrDefault(e => e.idPricePool == id);
                if (pricepool != null)
                {
                    db.PricePool.DeleteOnSubmit(pricepool);

                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("delete price " + ex.Message);
                    }
                }
                return false;
            }
        }
        [WebMethod]
        public PriceS[] GetPrices()
        {
            using (MasterDBDataContext db = new MasterDBDataContext())
            {
                var price = db.Price.ToArray();

                if (price != null)
                {
                    PriceS[] result = new PriceS[price.Length];

                    for (int i = 0; i < price.Length; i++)
                    {
                        result[i] = new PriceS()
                        {
                            id = price[i].idPrice,
                            name = price[i].Name,
                            description = price[i].Description
                        };

                        if (!String.IsNullOrEmpty(price[i].Image))
                            using (FileStream fs = new FileStream(price[i].Image, FileMode.Open, FileAccess.Read))
                            {
                                byte[] bytes = new byte[fs.Length];
                                int numBytesToRead = (int)fs.Length;
                                int numBytesRead = 0;
                                while (numBytesToRead > 0)
                                {
                                    // Read may return anything from 0 to numBytesToRead.
                                    int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                                    if (n == 0)
                                        break;

                                    numBytesRead += n;
                                    numBytesToRead -= n;
                                }

                                result[i].image = bytes;
                            }

                        if (!String.IsNullOrEmpty(price[i].Path))
                            using (FileStream fs = new FileStream(price[i].Path, FileMode.Open, FileAccess.Read))
                            {
                                byte[] bytes = new byte[fs.Length];
                                int numBytesToRead = (int)fs.Length;
                                int numBytesRead = 0;
                                while (numBytesToRead > 0)
                                {
                                    // Read may return anything from 0 to numBytesToRead.
                                    int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                                    if (n == 0)
                                        break;

                                    numBytesRead += n;
                                    numBytesToRead -= n;
                                }

                                result[i].path = bytes;
                            }
                    }

                    return result;
                }

                return null;
            }

        }
    }
}
