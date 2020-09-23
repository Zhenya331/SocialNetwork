using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Необходимо заполнить имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
