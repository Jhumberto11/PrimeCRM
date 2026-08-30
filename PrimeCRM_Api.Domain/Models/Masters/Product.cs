using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Masters
{
    public class Product : Base
    {
        public Brand Brand { get; set; }
        public string BrandId { get; set; }


    }
}
