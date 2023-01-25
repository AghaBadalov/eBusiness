using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBusiness.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int ProfessionId { get; set; }
        public bool IsDeleted { get; set; }
        [StringLength(maximumLength: 25)]

        public string Name { get; set; }
        [StringLength(maximumLength: 101)]

        public string? ImageUrl { get; set; }
        [StringLength(maximumLength: 101)]

        public string? IGUrl { get; set; }
        [StringLength(maximumLength: 101)]

        public string? FBUrl { get; set; }
        [StringLength(maximumLength: 101)]

        public string? TTUrl { get; set; }


        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public Profession? Profession { get; set; }
    }
}
