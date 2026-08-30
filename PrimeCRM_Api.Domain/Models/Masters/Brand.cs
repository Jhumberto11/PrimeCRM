using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Masters
{

    public class Brand : Base
    {
        public ICollection<Product> Products { get; set; }

    }
}
