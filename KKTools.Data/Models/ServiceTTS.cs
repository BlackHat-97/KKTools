
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KKTools.Data.Models
{
 [Table("ServiceTTSs")]
    public class ServiceTTS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
       
        public string Description { get; set; }
        public virtual IEnumerable<ServiceSupported> ServiceSupporteds { set; get; }
    }
}
