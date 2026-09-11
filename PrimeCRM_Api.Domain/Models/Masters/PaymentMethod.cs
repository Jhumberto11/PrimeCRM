using PrimeCRM_Api.Domain.Models.Masters.Enums;
using PrimeCRM_Api.Domain.Models.Reabastecimimento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrimeCRM_Api.Domain.Models.Masters
{
    public class PaymentMethod : Base
    {
        public PaymentMethodType Type { get; set; }

        public BankName BankName { get; set; }

        [MaxLength(4)]
        public string? Last4 { get; set; }

        public ICollection<RestockOrder>? RestockOrders { get; set; }


    }
}
