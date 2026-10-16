using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework_Assignment.Models
{
    //Event class and properties
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EventTitle { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; }   = string.Empty;

        public decimal TicketPrice { get; set; }
    }
}
