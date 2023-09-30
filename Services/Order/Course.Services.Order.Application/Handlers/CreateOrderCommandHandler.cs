using Course.Services.Order.Application.Commands;
using Course.Services.Order.Application.Dtos;
using Course.Services.Order.Domain.OrderAggregate;
using Course.Services.Order.Infrastructure;
using Course.Share.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Course.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;
        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAdress = new Address(request.AddressDto.Province, request.AddressDto.Street, request.AddressDto.Line, request.AddressDto.District, request.AddressDto.ZipCode);
            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(newAdress, request.BuyerId);
            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.ProductUrl, x.Price);
            });
            await _context.Orders.AddAsync(newOrder);

            var result = await _context.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
        }
    }
}
