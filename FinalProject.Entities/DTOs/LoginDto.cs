using FinalProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Entities.DTOs
{
    public class LoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
