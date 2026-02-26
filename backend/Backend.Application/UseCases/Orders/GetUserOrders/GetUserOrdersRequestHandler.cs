using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Orders.GetUserOrders;

public class GetUserOrdersRequestHandler(
    ILogger<GetUserOrdersRequestHandler> logger,
    IOrderRepository orderRepository) : IRequestHandler<GetUserOrdersRequest, Result<GetUserOrdersResponse>>
{
    private const string Source = nameof(GetUserOrdersRequestHandler);
    
    public async Task<Result<GetUserOrdersResponse>> Handle(GetUserOrdersRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Getting User {UserId} orders", Source, request.UserId);
        var orders = await orderRepository.GetOrdersByUserIdAsync(request.UserId, cancellationToken);
        
        return Result<GetUserOrdersResponse>.Success(HttpStatusCode.OK, new GetUserOrdersResponse
        {
            Orders = orders.Select(order => new OrderDto
            {
                Items = order.Items.Select(item => new ItemDto
                {
                    Id = order.Id,
                    Product = new ProductDto
                    {
                        Sku = item.Product.Sku,
                        StockQuantity = item.Product.Quantity,
                        BrandName = item.Product.Brand.BrandName,
                        ModelName = item.Product.ModelName,
                        Price = item.Product.Price,
                        ImagePath = item.Product.ImagePath!
                    },
                    Quantity = item.Quantity,
                    LineTotal = item.Product.Price * item.Quantity
                }),
                TotalPrice = order.Items.Sum(item => item.Price)
            }),
        });
    }
}