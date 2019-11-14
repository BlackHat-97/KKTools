using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KKTools.Data.Models
{
    [Table("Responses")]
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string async;
        public string error;
        public string message;
        public string request_id;
    }
}