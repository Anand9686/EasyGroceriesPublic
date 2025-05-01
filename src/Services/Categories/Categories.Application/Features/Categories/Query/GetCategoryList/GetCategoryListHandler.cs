using AutoMapper;
using MediatR;
using Categories.Application.Persistance;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Categories.Application.Features.Categories.Query.GetCategoryList
{
    public class GetCategoryListHandler : IRequestHandler<GetCategoryListQuery, List<CategoryList>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CategoryList>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryRepository.GetCategories();
            return _mapper.Map<List<CategoryList>>(categoryList);
        }
    }
}
