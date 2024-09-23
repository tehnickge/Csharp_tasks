using System.ComponentModel.DataAnnotations;

namespace HW3_1.Models
{
    public class Contacts
    {
        [Display(Name = "id")]
        [Required(ErrorMessage = "Id не установлен")]
        public int Id { get; set; }
        [Display(Name = "название")]
        [Required(ErrorMessage = "название не установлен")]
        public string Title { get; set; }
        [Display(Name = "сообщение")]
        [Required(ErrorMessage = "сообщение не установлен")]
        public string Message { get; set; }

    }
}
