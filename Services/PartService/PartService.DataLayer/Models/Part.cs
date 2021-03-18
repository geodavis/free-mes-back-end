using System.ComponentModel.DataAnnotations;

namespace PartService.DataLayer.Models
{
    public class Part
    {
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string PartNumber { get; set; }
        [Required, StringLength(255)]
        public string PartDescription { get; set; }
        public int PartTypeId { get; set; }
        public PartType PartType { get; set; }
    }
}
