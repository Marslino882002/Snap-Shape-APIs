using AutoMapper;
using MediatR;
using Snap.Core.DTOs;
using Snap.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.ScrapedProducts.Queries
{
    public class GetScrapedProductsQueryHandler : IRequestHandler<GetScrapedProductsQuery, List<ScrapedProductDto>>
    {
        private readonly IScrapedProductRepository _repo;
        private readonly IMapper _mapper;

        public GetScrapedProductsQueryHandler(IScrapedProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ScrapedProductDto>> Handle(GetScrapedProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<List<ScrapedProductDto>>(products);
        }
    }
}
