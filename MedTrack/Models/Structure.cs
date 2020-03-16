using System.Collections.Generic;

namespace MedTrack.Models
{
    public class Structure
    {
        public Structure()
        {
            Structures = new HashSet<Structure>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public int? ZoneId { get; set; }
        public virtual ICollection<Structure> Structures { get; set; }
    }
}

