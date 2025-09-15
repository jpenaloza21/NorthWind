namespace NorthWind.Sales.Backend.BusinessObjects.Aggregates;

public class OrderAggregate : Order
{
    //public Order order;
    readonly List<OrderDetail> OrderDetailsField = [];
    public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;
    public void addDetail(int productId, decimal unitPrice,short quantity)
    {
        var ExistingOrderDetail = OrderDetailsField.FirstOrDefault(od => od.ProductId == productId);
        if (ExistingOrderDetail != default)
        {
            quantity += ExistingOrderDetail.Quantity;
            OrderDetailsField.Remove(ExistingOrderDetail);

        }
        OrderDetailsField.Add(new OrderDetail(productId, (double)unitPrice, quantity));
    }
    public static OrderAggregate From(CreateOrderDto orderDto) { 
        OrderAggregate OrderAggregate = new OrderAggregate
        {
            CustomerId = orderDto.CustomerId,
            ShipAddress = orderDto.ShipAddress,
            ShipCity = orderDto.ShipCity,
            ShipCountry = orderDto.ShipCountry,
        };
        foreach (var item in orderDto.OrderDetails)
        {
            OrderAggregate.addDetail(item.ProductId, item.UnitPrice, item.Quantity);
        }
        return OrderAggregate;
    }
}

