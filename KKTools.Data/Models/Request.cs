using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite.Linq;


namespace KKTools.Data.Models
{
    [Table("Requests")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Content { get; set; }

        public DateTime? CreatedDate { set; get; }

    }
}
