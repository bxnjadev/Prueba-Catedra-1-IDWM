using System.ComponentModel.DataAnnotations;
using P_Cat_1_IDWM.Validation;

namespace P_Cat_1_IDWM.Dto;

public class UserDto
{
    
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
    public string gender {get; set;} = "otro";

    [Required]
    [PastDateValidation]
    public DateTime dateTime {get; set;} = DateTime.Now;

}