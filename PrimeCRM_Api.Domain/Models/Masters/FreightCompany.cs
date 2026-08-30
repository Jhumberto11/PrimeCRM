using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Masters
{
    public class FreightCompany : Base
    {
        public decimal RatePerLB { get; set; } /// Precio por Libra
        public decimal TaxPercentSV { get; set; } /// Impuestos de el salvador
        public decimal OtherCharges {  get; set; } /// Cargos Adiccionales

    }
}
