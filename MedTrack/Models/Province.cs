using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTrack.Models
{
    public class Province
    {
        public Province()
        {
            Villes = new HashSet<Ville>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ville> Villes { get; set; }
    }
}
