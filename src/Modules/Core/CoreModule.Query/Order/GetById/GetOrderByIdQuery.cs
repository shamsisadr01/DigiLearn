﻿using Common.L4.Query;
using CoreModule.Query.Order._DTOs;
using Microsoft.EntityFrameworkCore;
using QueryContext = CoreModule.Query._Data.QueryContext;

namespace CoreModule.Query.Order.GetById;

public record GetOrderByIdQuery(Guid Id) : IQuery<OrderDto?>;

class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly QueryContext _context;

    public GetOrderByIdQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .Include(c => c.OrderItems)
            .ThenInclude(c => c.Course)
            .Include(c => c.User)
            .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);

        return OrderMapper.MapOrder(order);
    }
}