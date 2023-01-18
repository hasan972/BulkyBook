using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName ("Dispaly Order")]
        [Range (1,100,ErrorMessage ="Display Order Must Be to 100 only")]
        public int CategoryOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
