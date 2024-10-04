using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using P_Cat_1_IDWM.Validation;

namespace P_Cat_1_IDWM.Model
{

    public class User
    {

        [Required]
        [Key]
        public int Id {get; set;} = 0;

        [Required]
        [MaxLength(20)]
        public string rut {get;set;} = string.Empty;

        [Required]
        [Length(3, 100)]
        [MaxLength(100)]
        public string name {get; set;} = string.Empty;

        [Required]
        [RegularExpression( @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        [MaxLength(70)]
        public string email {get; set;} = string.Empty;

        [Required]
        [RegularExpression("^(masculino|femenino|otro|prefiero no decirlo)$")]
        public string gender {get; set;} = "other";

        [Required]
        [PastDateValidation]
        public DateTime dateTime {get; set;} = DateTime.Now;

    }
    
}