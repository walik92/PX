using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PX.API.Models
{
    public class CompanyModel
    {
        [Required] public string Name { get; set; }

        [Required] public string EstablishmentYear { get; set; }

        [Required] public IEnumerable<EmployeeModel> Employees { get; set; }
    }
}