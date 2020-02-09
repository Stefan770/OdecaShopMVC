using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdecaShopMVC.Models
{
    public class Artikal
    {
        public int Id { get; set; }
        public Tip Tip { get; set; }
        public Kategorija Kategorija { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(350, MinimumLength = 10)]
        public string Opis { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Marka { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public double Cena { get; set; }
        public bool Akcija { get; set; }
    }
}