using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Inventario.Enums
{
    public enum InventoryMovementType
    {
        RestockIn = 1,
        SaleOut = 2,
        SaleReturn = 3,
        AdjustmentIn = 4,
        AdjustmentOut = 5,
        InitialStock = 6
    }
}
