using PrimeCRM_Api.Domain.Models.Masters;
using PrimeCRM_Api.Domain.Models.Reabastecimimento.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Reabastecimimento
{
    public class RestockOrder
    {
        public int Id { get; set; }

        // Fecha en la que realizaste la compra
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;


        // Producto comprado
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;


        //Total Paggado
        public decimal Total {  get; set; }

        // Cantidad comprada
        public int Quantity { get; set; }


        // Precio pagado por cada unidad en Amazon/distribuidor
        [NotMapped]
        public decimal StoreUnitPrice =>
            Total / StoreUnitPrice; 


        // Empresa encargada de traer el producto
        public int FreightCompanyId { get; set; }

        public FreightCompany FreightCompany { get; set; } = null!;


        // Método con el que se pagó la compra
        public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; } = null!;


        // Peso aproximado del paquete
        [Column(TypeName = "decimal(18,2)")]
        public decimal EstimatedPounds { get; set; }


        // Flete calculado inicialmente
        [Column(TypeName = "decimal(18,2)")]
        public decimal EstimatedFreight { get; set; }


        // Flete que realmente se pagó
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ActualFreight { get; set; }


        // Impuestos estimados
        [Column(TypeName = "decimal(18,2)")]
        public decimal EstimatedTaxes { get; set; }


        // Otros cobros
        [Column(TypeName = "decimal(18,2)")]
        public decimal OtherCharges { get; set; } = 0.00m;


        // Costo final por unidad ya puesta en El Salvador
        [Column(TypeName = "decimal(18,2)")]
        public decimal? LandedUnitCost { get; set; }


        // Estado financiero de la compra
        public PaymentStatus PaymentStatus { get; set; }
            = PaymentStatus.Pending;


        // Estado físico del paquete
        public PackageStatus PackageStatus { get; set; }
            = PackageStatus.InTransit;


        [MaxLength(500)]
        public string? Notes { get; set; }


    }
}
