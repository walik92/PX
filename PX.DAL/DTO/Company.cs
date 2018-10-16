using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PX.DAL.DTO
{
    [Table("Companies")]
    public class Company
    {
        [Key] public long Id { get; set; }

        [Required] [MaxLength(100)] public string Name { get; set; }

        [Required] public int EstablishmentYear { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}