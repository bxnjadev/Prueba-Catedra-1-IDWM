using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P_Cat_1_IDWM.Model
{

    public class User
    {

        [Required]
        [Key]
        public int Id {get; set;} = 0;

        [Required]
        [MaxLength(20)]
        public string Rut {get;set;} = string.Empty;

        [Required]
        [Length(3, 100)]
        [MaxLength(100)]
        public string Name {get; set;} = string.Empty;

        [Required]
        [RegularExpression( @"^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d]+$")]
        [MaxLength(70)]
        public string email {get; set;} = string.Empty;

        [Required]
        [RegularExpression("^(masculino|femenino|otro|prefiero no decirlo)$")]
        public string gender {get; set;} = "other";

        [Required]
        public DateTime dateTime {get; set;} = DateTime.Now;

    }
    
}