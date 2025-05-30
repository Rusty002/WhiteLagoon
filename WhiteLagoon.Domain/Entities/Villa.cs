using System.ComponentModel.DataAnnotations;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        public Guid VillaId { get; set; }

        [Display(Name = "Villa Name")]
        [MaxLength(50)]
        public required string VillaName { get; set; }

        [Display(Name = "Description")]
        public string? VillaDescription { get; set; }

        [Display(Name = "Price Per Night")]
        [Range(1, 1000)]
        public double VillaPrice { get; set; }

        [Display(Name = "Size In Square Feet")]
        public int VillaSizeInSquareFeet { get; set; }

        [Display(Name = "Number Of Peoples")]
        [Range (1, 10)]
        public int VillaOccupancy { get; set; }

        [Display(Name = "Image Url")]
        public string? VillaImageUrl { get; set; }
        public DateTime? VillaCreatedDate { get; set; }
        public DateTime? VillaUpdatedDate { get; set; }
    }
}
