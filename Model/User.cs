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
        public string rut {get;set;} = string.Empty;

        [Required]
        [Length(3, 100)]
        public string name {get; set;} = string.Empty;

        [Required]
        [RegularExpression( @"^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d]+$")]
        public string email {get; set;} = string.Empty;

        [Required]
        [RegularExpression("^(Rojo|Verde|Azul)$")]
        public string gender {get; set;} = "other";

        [Required]
        public DateTime dateTime {get; set;} = DateTime.Now;

    }
    
}