using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KKTools.Models
{
    [Table("Results")]
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

    
       
        public DateTime? CreatedDate { set; get; }

        public DateTime? DateGetWav { set; get; }
        [Required]
        [MaxLength(256)]
        public string Text { get; set; }

        public string SoundPath { get; set; }
        public string SoundUrl { get; set; }
        public bool Downloaded { get; set; }
        [Required]
        public int RequestID { get; set; }
        [ForeignKey("RequestID")]
        public virtual Request Request { set; get; }
        [Required]
        public int ServiceTTSID { get; set; }
        [ForeignKey("ServiceTTSID")]
        public virtual ServiceTTS ServiceTTS { set; get; }
        [Required]
        public int ResponseID { get; set; }
        [ForeignKey("ResponseID")]
        public virtual Response Response { set; get; }

    }

}