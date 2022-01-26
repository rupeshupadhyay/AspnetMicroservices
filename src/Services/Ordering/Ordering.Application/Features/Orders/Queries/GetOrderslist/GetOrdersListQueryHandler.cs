using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrderslist
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersDto>>
    {
        private readonly IOrderRepository _iorderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IOrderRepository iorderRepository, IMapper mapper)
        {
            _iorderRepository = iorderRepository ?? throw new ArgumentNullException(nameof(iorderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrdersDto>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orderlist = await _iorderRepository.GetOrdersByUserName(request.UserName);
            return _mapper.Map<List<OrdersDto>>(orderlist);
        }
    }
}
