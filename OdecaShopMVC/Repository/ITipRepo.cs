using System.Collections.Generic;
using OdecaShopMVC.Models;

namespace OdecaShopMVC.Repository
{
    public interface ITipRepo
    {
        List<Tip> GetAll();
    }
}