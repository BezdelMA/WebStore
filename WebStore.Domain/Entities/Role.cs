using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities
{
    class Role : IdentityRole
    {
        public const string Administrator = "Administrators";
    }
}
