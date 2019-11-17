using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KKTools.Models
{
    [Table("Requests")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public DateTime? CreatedDate { set; get; }

        public bool Status { get; set; }
        [Required]
        public int StreamID { get; set; }
        [ForeignKey("StreamID")]
        public virtual Stream Stream { set; get; }
    }
}
