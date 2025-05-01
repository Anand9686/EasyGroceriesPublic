using AutoMapper;
using Categories.Application.Persistance;
using Categories.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Categories.Application.Features.Categories.Command.CreateCategoryProducts
{
    public class CategoryProductsCommandHandler : IRequestHandler<CategoryProductsCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryProductsCommandHandler> _logger;

        public CategoryProductsCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<CategoryProductsCommandHandler> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CategoryProductsCommand request, CancellationToken cancellationToken)
        {
            // var VendorEntity = _mapper.Map<VendorProductsInfo>(request);
            string[] Products = request.ProductId.Split(",");
            List<CategoryProductsInfo> categoryProducts = new List<CategoryProductsInfo>();
            foreach (string productid in Products)
            {
                categoryProducts.Add(new CategoryProductsInfo()
                {
                    ProductId = Convert.ToInt32(productid),
                    CategoryId = request.CategoryId
                });
            }
            if (categoryProducts.Count > 0)
                await _categoryRepository.CreateCategoryProducts(categoryProducts);

            // _logger.LogInformation($"Vendor {newVendor.Id} is successfully created.");

            return (categoryProducts.ToList().Count > 0 ? 1 : 0);
        }
    }
}
