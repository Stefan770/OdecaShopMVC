using System.Collections.Generic;
using OdecaShopMVC.Models;

namespace OdecaShopMVC.Repository
{
    public interface IKategorijaRepo
    {
        List<Kategorija> GetAll();
    }
}