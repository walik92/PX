using System;
using System.Collections.Generic;
using PX.DAL.Enums;

namespace PX.API.Models
{
    public class SearchModel
    {
        public string Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public IEnumerable<JobTitleEnum> EmployeeJobTitles { get; set; }
    }
}