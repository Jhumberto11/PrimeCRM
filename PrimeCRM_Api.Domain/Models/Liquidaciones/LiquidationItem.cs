using PrimeCRM_Api.Domain.Models.Ventas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeCRM_Api.Domain.Models.Liquidaciones
{
    public class LiquidationItem
    {
        public int Id { get; set; }


        public int LiquidationId { get; set; }
        public Liquidation Liquidation { get; set; } = null!;
        // Tracking proporcionado por el encomendista
        [Required]
        [MaxLength(100)]
        public string Tracking { get; set; } = string.Empty;


        // Relación interna con nuestra venta
        public int? SaleId { get; set; }

        public Sale? Sale { get; set; }


        // Monto de venta reportado por el encomendista
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaleAmount { get; set; }


        // Comisión real cobrada por manejo de efectivo
        [Column(TypeName = "decimal(18,2)")]
        public decimal CashHandlingFee { get; set; }


        // Costo real de entrega
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCost { get; set; }


        // Monto que realmente nos liquidaron
        [Column(TypeName = "decimal(18,2)")]
        public decimal LiquidatedAmount { get; set; }


        // Estado reportado por la empresa de encomiendas
        public string? DeliveryStatus { get; set; }
    }
}