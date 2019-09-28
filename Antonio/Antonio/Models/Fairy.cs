

namespace Antonio.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Fairy
    {
        public enum Wishes
        {
               maleta,
               maraca,
               mesa
        }



        [Key]
        public int FairyID { get; set; }
        [Required]
        [Display(Name ="Nombre Completo")]
        [StringLength(24,MinimumLength =2)]
        public string NickName { get; set; }
        [Required]
        public Wishes wishes { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Direccion de correo no valida")]
        public string Email { get; set; }
        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime Birthday { get; set; }


    }
}