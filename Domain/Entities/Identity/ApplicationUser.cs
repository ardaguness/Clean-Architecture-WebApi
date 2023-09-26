using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Identity;



namespace Domain.Entities.Identity
{
    public class ApplicationUser:IdentityUser<string>
    {
        public string Name { get; set; }  
        public string Surname { get; set; }  
        public string UserNumber { get; set; }
    }
}