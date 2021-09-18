using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BlazorApp_firstProgram.Data;

namespace BlazorApp_firstProgram.ModelAccount
{
    public class EditUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Hometown { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string Password { get; set; }

        public EditUser() { }

        public EditUser(User user)
        {
            Hometown = user.hometown;
            Id = user.Id;
            Age = user.age;
            FirstName = user.firstname;
            LastName = user.lastname;
            Username = user.firstname+" "+user.lastname;
        }
    }
}
