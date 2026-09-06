using PrimeCRM_Api.Domain.Models.Masters.Enums;
using PrimeCRM_Api.Domain.Models.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Masters
{
    public class CourierCompany : Base
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryRate { get; set; } // COSTO DE ENVIO

        public CashHandlingType CashHandlingType { get; set; } = CashHandlingType.Percentage;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CashHandlingValue { get; set; } // Tarifa de Comision de efectivo

        public ICollection<Sale> Sales {  get; set; }
    }
}
