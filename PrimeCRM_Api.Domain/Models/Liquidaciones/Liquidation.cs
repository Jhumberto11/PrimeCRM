using PrimeCRM_Api.Domain.Models.Liquidaciones.Enum;
using PrimeCRM_Api.Domain.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Liquidaciones
{
    public class Liquidation
    {
        public int Id { get; set; }


        // ID o referencia entregada por el encomendista
        [Required]
        [MaxLength(100)]
        public string SettlementReference { get; set; } = string.Empty;


        // Fecha en que se recibió/procesó la liquidación
        public DateTime LiquidationDate { get; set; }
            = DateTime.UtcNow;


        // Empresa que realizó la liquidación
        public int CourierCompanyId { get; set; }

        public CourierCompany CourierCompany { get; set; } = null!;


        // Monto Total de Liquidacion
        public decimal SettlementTotal { get; set; }


        [MaxLength(500)]
        public string? Notes { get; set; }


        // Ventas incluidas dentro de la liquidación
        public ICollection<LiquidationItem> Trackings { get; set; }
            = new List<LiquidationItem>();
    }
}
