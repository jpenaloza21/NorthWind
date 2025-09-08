namespace NorthWind.Sales.Entities.Dtos.CreateOrder;

#region Primary Constructors c# 12
public class CreateOrderDto(string customerId, string shipAddress
    ,string shipCity, string shipCountry, string shipPostalCode, IEnumerable<CreateOrderDetailDtos> orderDetails)
{
    public string CustomerId => customerId;
    public string ShipAddress => shipAddress;
    public string ShipCity => shipCity;
    public string ShipCountry => shipCountry;
    public string ShipPostalCode => shipPostalCode;
    public IEnumerable<CreateOrderDetailDtos> OrderDetails => orderDetails;
}
#endregion