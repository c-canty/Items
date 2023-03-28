using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Items.Models
{
    public class Order
    {
        
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int OrderId { get; set; }
        public DateTime dateTime { get; set; }
        [Required] public int UserId { get; set; }
        [Required] public User User { get; set; }
        [Required] public int ItemId { get; set; }
        [Required] public Item Item { get; set; }
        [Required] public int Count { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }

        public Order()
        {
            dateTime = DateTime.Now;
        }

        public Order(int userId, User user, int itemId, Item item, int count)
        {
            dateTime = DateTime.Now;
            UserId = userId;
            User = user;
            ItemId = itemId;
            Item = item;
            Count = count;
        }
    }
}
