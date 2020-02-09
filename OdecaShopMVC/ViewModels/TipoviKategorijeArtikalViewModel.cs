using OdecaShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdecaShopMVC.ViewModels
{
    public class TipoviKategorijeArtikalViewModel
    {
        public Artikal Artikal { get; set; }
        public List<Tip> Tipovi { get; set; }
        public List<Kategorija> Kategorije { get; set; }
    }
}