using System.Collections.Generic;
using OdecaShopMVC.Models;

namespace OdecaShopMVC.Repository
{
    public interface IArtikalRepo
    {
        int Create(Artikal artikal);
        bool DeleteLogical(int id);
        List<Artikal> GetAll();
    }
}