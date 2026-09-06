using System;
using System.Collections.Generic;
using System.Text;
using PrimeCRM_Api.Domain.Models.Ventas;

namespace PrimeCRM_Api.Domain.Models.Masters
{
 
    /// <summary>
    /// Canales de Venta : Instagram, Facebook, etc...
    /// </summary>

    public class SalesChannel : Base
    {

        public ICollection<Sale> Sales { get; set; }
    }
}
