using System.ComponentModel.DataAnnotations;


namespace SocialNetwork.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Необходимо заполнить имя пользователя")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z0-9]*$", ErrorMessage = "Только буквы и цифры. Первый символ - буква")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
