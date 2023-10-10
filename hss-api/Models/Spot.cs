using System.ComponentModel.DataAnnotations;

namespace hss_api.Models
{
    public class Spot
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Range(0, 5)]
        public int PriceRating { get; set; }

        [Range(0, 5)]
        public int HealthRating { get; set; }
    }
}
