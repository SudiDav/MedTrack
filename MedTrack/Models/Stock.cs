using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTrack.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime? DateStock { get; set; }
        public string Desigantion { get; set; }
        public string StockInitial { get; set; }
        public decimal? QteEntree { get; set; }
        public decimal? QteSortie { get; set; }
        public decimal? StockFinal { get; set; }
    }
}
