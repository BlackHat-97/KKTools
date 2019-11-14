using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KKTools.Models
{
    [Table("Responses")]
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string async { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public string request_id { get; set; }
    }
}