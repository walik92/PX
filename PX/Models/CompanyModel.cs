using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PX.API.Models
{
    public class CompanyModel
    {
        [Required] [MaxLength(100)] public string Name { get; set; }

        [Required] public int EstablishmentYear { get; set; }

        [Required] public IEnumerable<EmployeeModel> Employees { get; set; }
    }
}