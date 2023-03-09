namespace BlogPage.Models
{
    public class UserSignInModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Kullanıcı Adınızı giriniz")]
        public string userName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifrenizi giriniz")]
        public string password { get; set; }
            
    }
}
