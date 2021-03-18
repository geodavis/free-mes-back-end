using System.ComponentModel.DataAnnotations;

namespace PartService.DataLayer.Models
{
    public class PartType
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
    }
}