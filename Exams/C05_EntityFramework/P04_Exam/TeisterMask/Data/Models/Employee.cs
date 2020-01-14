﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3),MaxLength(40)]
        [RegularExpression(@"^(?<username>)([\w]+)$")]
        public string Username { get; set; }

        [Required]
        // [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?<phoneNumber>)([0-9]{3}-[0-9]{3}-[0-9]{4})$")]
        public string Phone { get; set; }

        public ICollection<EmployeeTask> EmployeesTasks { get; set; } = new HashSet<EmployeeTask>();
    }
}