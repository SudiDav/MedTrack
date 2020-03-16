namespace MedTrack.Models
{
    public class Ville
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int? ProvinceId { get; set; }

        public virtual Province Province { get; set; }
    }
}
