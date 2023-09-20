using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.CategoryQueries
{
    public class CategoryQueriesHandlers :
      IRequestHandler<GetCategories, GetCategoriesResponse>
    {
        readonly ICategoryRepository _categoryRepo;
        readonly IMapper _mapper;

        public CategoryQueriesHandlers(ICategoryRepository categoryRepo,IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<GetCategoriesResponse> Handle(GetCategories request, CancellationToken cancellationToken)
        {
            var categories = _categoryRepo.GetAll();
            var mapperCategories = _mapper.Map<IEnumerable<GetCategoriesMapper>>(categories);

            return new() { Categories = mapperCategories };
        }
    }
}