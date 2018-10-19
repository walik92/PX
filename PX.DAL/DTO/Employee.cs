using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PX.DAL.Enums;

namespace PX.DAL.DTO
{
    [Table("Employees")]
    public class Employee
    {
        [Key] public long Id { get; set; }

        [Required] [MaxLength(100)] public string FirstName { get; set; }

        [Required] [MaxLength(100)] public string LastName { get; set; }

        [Required] public DateTime DateOfBirth { get; set; }

        [Required] public JobTitleEnum JobTitle { get; set; }

        [ForeignKey("CompanyId")] public long CompanyId { get; set; }

        [Required] public Company Company { get; set; }
    }
}