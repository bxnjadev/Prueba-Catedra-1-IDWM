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
        public int Id = 0;

        [Required]
        public string rut = string.Empty;

        [Required]
        [Length(3, 100)]
        public string name = string.Empty;

        [Required]
        [RegularExpression( @"^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d]+$")]
        public string email = string.Empty;

        [Required]
        [RegularExpression("^(Rojo|Verde|Azul)$")]
        public string gender = "other";

        [Required]
        public DateTime dateTime = DateTime.Now;

    }
    
}