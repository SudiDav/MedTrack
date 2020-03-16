using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTrack.Models
{
    public class Transporteur
    {
        public Transporteur()
        {
            Distributeurs = new HashSet<Distributeur>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Distributeur> Distributeurs { get; set; }
    }
}
