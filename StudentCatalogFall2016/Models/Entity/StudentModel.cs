using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCatalogFall2016.Models.Entity
{
    public class StudentModel
    {
        public int StudentModelId { get; set; }

        [Required(ErrorMessage = "Oh no, you forgot something. Firstname!")]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        //Url Phone StringLength CreditCard Range(1,100)

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string MobilePhone { get; set; }

    }
}