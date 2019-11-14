using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KKTools.Data.Models
{
    [Table("Results")]
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

    
        public string Content { get; set; }

        public DateTime? CreatedDate { set; get; }

        public DateTime? DateGetWav { set; get; }
        [Required]
        [MaxLength(256)]
        public string Text { get; set; }
        [Required]
        [MaxLength(256)]
        public string Wav { get; set; }
        [Required]
        public int RequestID { get; set; }
        [ForeignKey("RequestID")]
        public virtual Request Request { set; get; }

    }

}