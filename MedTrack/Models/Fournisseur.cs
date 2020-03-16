using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTrack.Models
{
    public class Fournisseur
    {
        public Fournisseur()
        {
            Approvisionnements = new HashSet<Approvisionnement>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Approvisionnement> Approvisionnements { get; set; }
    }
}
