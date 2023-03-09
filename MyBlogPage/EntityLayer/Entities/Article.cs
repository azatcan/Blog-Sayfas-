using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Başlık")]
        [StringLength(100, ErrorMessage = "Max 100 karakter olmalıdır.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "İçerik")]
        [StringLength(5000, ErrorMessage = "Max 5000 karakter olmalıdır.")]
        public string Content { get; set; }

        [Display(Name = "Resim")]
        public string ImagePath { get; set; }
        
        [NotMapped]
        public IFormFile Dosya { get; set; }

        public DateTime CreateDate { get; set; }
       
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Onay")]
        public bool IsActive { get; set; }
        //[Display(Name = "Yazar")]
       
        //public virtual Author Author { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }   

        public List<Comments> Comments { get; set; }
        //public List<AppUser> AppUser { get; set; }

    }
}
