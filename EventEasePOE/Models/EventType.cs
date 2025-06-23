using System.ComponentModel.DataAnnotations;

namespace EventEasePOE.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string TypeName { get; set; }

        public bool IsAvailable { get; set; }
    }
}
