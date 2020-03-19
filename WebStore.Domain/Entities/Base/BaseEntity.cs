using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.Base
{
    class BaseEntity : IBaseEntity
    {
        public int Id { get; set ; }
    }
}
