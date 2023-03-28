using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Items.Models
{
    public class Item : IComparable<Item>
    {
        [Display(Name = "Item Id")]
        [Required(ErrorMessage = "Der skal angives et ID til Item")]
        [Range(typeof(int), minimum:"0", maximum:"10000", ErrorMessage = "Id skal være mellem {1} og {2}")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Navn")]
        [Required(ErrorMessage = "Der skal angives et Navn til Item"), MaxLength(100)]
        [StringLength(100)]
        public string Name { get; set; }
       
        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Der skal angives et Pris til Item")]
        [Range(typeof(decimal), minimum: "0", maximum: "100000", ErrorMessage = "Prisen skal være mellem {1} og {2}")]
        public decimal Price { get; set; }

        public Item()
        {
        }

        public Item(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int CompareTo(Item other)
        {
            if (other == null) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}
