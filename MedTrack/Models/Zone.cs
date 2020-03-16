using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTrack.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string ZoneCode { get; set; }
        public string Description { get; set; }
        public string Addresse { get; set; }
        public int? VilleId { get; set; }
    }
}
