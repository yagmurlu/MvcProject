using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; }//Gönderen
        [StringLength(50)]
        public string RecevierMail { get; set; }//Alıcı
        [StringLength(100)]
        public string Subject { get; set; }
        [AllowHtml]
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool IsDraft { get; set; }
        public bool Trash { get; set; }
        public bool IsRead { get; set; }
        public bool IsImportant { get; set; }
        public bool IsSpam { get; set; }
    }
}
