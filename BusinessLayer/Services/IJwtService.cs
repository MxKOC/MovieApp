using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Services
{
    public interface IJwtService
{
    string GenerateTokenReader(Reader reader);
    string GenerateTokenWriter(Writer writer);
}

}