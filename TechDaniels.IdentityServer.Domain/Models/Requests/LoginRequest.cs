﻿using System.ComponentModel.DataAnnotations;

namespace TechDaniels.IdentityServer.Domain.Requests
{
    public class LoginRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
