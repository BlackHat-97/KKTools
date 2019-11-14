using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KKTools.Models
{
    [Table("Streams")]
    public class Stream
    {
        /*Bảng chứa nội dung là cả đoạn văn người dùng muốn Text-to-speech
         * Mỗi Sentence tương ứng với một request tới server, phân tách bởi dấu chấm '.'
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Content { get; set; }

        public DateTime? CreatedDate { set; get; }

        //Tổng số câu cần thực hiện - tương ứng với số request cần thực hiện
        public int TotalSentence { get; set; }
        //Tổng số câu đã thực hiện- tương ứng với số request ĐÃ thực hiện
        public int DoneSentence { get; set; }
    }
}
