using System.ComponentModel.DataAnnotations;

namespace Items.Models
{
    public class Item
    {
        [Display(Name = "Item Id")]
        [Required(ErrorMessage = "Der skal angives et ID til Item")]
        [Range(typeof(int), minimum:"0", maximum:"10000", ErrorMessage = "Id skal være mellem {1} og {2}")]
        public int Id { get; set; }

        [Display(Name = "Navn")]
        [Required(ErrorMessage = "Der skal angives et Navn til Item"), MaxLength(20)]
        public string Name { get; set; }
       
        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Der skal angives et Pris til Item")]
        [Range(typeof(double), minimum: "0", maximum: "100000", ErrorMessage = "Prisen skal være mellem {1} og {2}")]
        public double Price { get; set; }

        public Item()
        {
        }

        public Item(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
