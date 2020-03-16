using System;
using System.Collections.Generic;

namespace MedTrack.Models
{
    public class Approvisionnement
    {
        public Approvisionnement()
        {
            Distributeurs = new HashSet<Distributeur>();
        }

        public int Id { get; set; }
        public DateTime? DateFabrication { get; set; }
        public DateTime? DateExpiration { get; set; }
        public int? ProduitId { get; set; }
        public int? FournisseurId { get; set; }
        public int? DepotId { get; set; }
        public int? Quantite { get; set; }
        public decimal? CoutTotal { get; set; }

        public virtual Depot Depot { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
        public virtual Produit Produit { get; set; }
        public virtual ICollection<Distributeur> Distributeurs { get; set; }
    }
}
