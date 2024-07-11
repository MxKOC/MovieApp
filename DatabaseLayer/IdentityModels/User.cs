using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DatabaseLayer.IdentityModels
{
    public class User : IdentityUser
    {
    public string Name { get; set; }
    public int MyProperty { get; set; }
    }
}