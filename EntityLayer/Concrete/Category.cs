using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(200)]
        public string CategoryDescription{ get; set; }//Açıklama
        public bool CategoryStatus { get; set; }// veri tabanından silmek yerine aktif/ pasif durumları yapılır.
        public ICollection<Heading> Headings { get; set; } //heading-kategori ilişkilendirmesi

        }
}
