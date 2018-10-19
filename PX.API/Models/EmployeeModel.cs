using System;
using System.ComponentModel.DataAnnotations;
using PX.DAL.Enums;

namespace PX.API.Models
{
    public class EmployeeModel
    {
        [Required] [MaxLength(100)] public string FirstName { get; set; }

        [Required] [MaxLength(100)] public string LastName { get; set; }

        [Required] public DateTime DateOfBirth { get; set; }

        [Required] public JobTitleEnum JobTitle { get; set; }
    }
}