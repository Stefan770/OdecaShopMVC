using OdecaShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdecaShopMVC.ViewModels
{
    public class ArtikliTkaViewModel
    {
        public List<Artikal> Artikli { get; set; }
        public TipoviKategorijeArtikalViewModel Tkavm { get; set; }
    }
}