﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities
{
    public class User : IdentityUser
    {
        public const string Administrator = "Admin";
        public const string DefaultPassword = "AdminPassword";
    }
}
