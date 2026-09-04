namespace PrimeCRM_Api.Domain.Models.Ventas
{
    public enum FundsLocation
    {
        HeldByCourier = 1, // Aun no tengo los fondos disponibles
        Settlement = 2, // Los tengo en BAC
        AvailableCapital = 3, // ya los tengo disponibles en Cuenta BA
        Cash = 4, // Efectivo
        PaymentLink = 5 // Plataforma link de pago
    }
}