using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Inventario.Enums
{
    public enum InventorySourceType
    {
        Restock = 1,
        Sale = 2,
        SaleReturn = 3,
        ManualAdjustment = 4,
        InitialBalance = 5
    }
}
