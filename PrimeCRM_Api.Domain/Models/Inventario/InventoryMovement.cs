using PrimeCRM_Api.Domain.Models.Inventario.Enums;
using PrimeCRM_Api.Domain.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Inventario
{
    public class InventoryMovement
    {
        public int Id { get; set; }

        public int ProductID { get; set; }
        // Navigation Property
        public Product Product { get; set; } = null!;


        public DateOnly Date { get; set; }
        public InventoryMovementType Type { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitCost { get; set; }
        public InventorySourceType SourceType { get; set; }

        public int? SourceId { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        // Navigation Property


    }
}
