using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        [Display(Name = "Yorum")]
        public string Content { get; set; }
        [Display(Name = "Makale")]
        public  int ArticleId { get; set; }       
        public virtual Article Article { get; set; }
        [Display(Name = "Kişi")]
        public int AppUserId { get; set; }
        public AppUser  AppUser { get; set; }
        
        public DateTime Date { get; set; }

       
    }
}
