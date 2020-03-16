using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTrack.Models
{
    public class Commande
    {
        public Commande()
        {
            ConfirmationReceptions = new HashSet<ConfirmationReception>();
            Distributeurs = new HashSet<Distributeur>();
        }

        public int Id { get; set; }
        public string NumCommand { get; set; }
        public DateTime? Date { get; set; }
        public int? StructureId { get; set; }

        public virtual ICollection<ConfirmationReception> ConfirmationReceptions { get; set; }
        public virtual ICollection<Distributeur> Distributeurs { get; set; }
    }
}
