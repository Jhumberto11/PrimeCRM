using System;
using System.Collections.Generic;
using System.Text;
using PrimeCRM_Api.Domain.Models.Inventario;
using PrimeCRM_Api.Domain.Models.Reabastecimimento;
using PrimeCRM_Api.Domain.Models.Ventas;

namespace PrimeCRM_Api.Domain.Models.Masters
{
    public class Product : Base
    {
        public Brand Brand { get; set; }
        public string BrandId { get; set; }

        public ICollection<InventoryMovement> InventoryMovements { get; set; }
        public ICollection<RestockOrder> RestockOrders { get; set; }
        public ICollection<Sale> Sales { get; set; }

    }
}
