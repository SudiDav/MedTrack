using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTrack.Models
{
    public class Categorie
    {
        public Categorie()
        {
            Produits = new HashSet<Produit>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
    }
}
