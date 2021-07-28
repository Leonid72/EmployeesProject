using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmployeeWebClient.Models
{
    [Serializable]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }


        [Required]
        [StringLength(20,ErrorMessage = "Length must be 20", MinimumLength = 1)]
        [Display(Name ="First Name")]
        [DataMember(Name = "employee.FirstName")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        [DataMember(Name = "employee.LastName")]
        [StringLength(20,ErrorMessage = "Length must be 20",MinimumLength = 1)]
        public string LastName { get; set; }


        public string Gender { get; set; }

        public int Salary { get; set; }
    }
}