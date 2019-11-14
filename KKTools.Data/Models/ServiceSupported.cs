
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KKTools.Data.Models
{
   [Table("ServiceSupporteds")]
    public class ServiceSupported
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Selections { get;  set; }
        [Required]
        [MaxLength(10)]
        public string SeparateSymbol { get; set; }
        [Required]
        public  int ServiceTTSID { get; set; }

        [ForeignKey("ServiceTTSID")]
        public virtual ServiceTTS ServiceTTS { set; get; }

    }
}
