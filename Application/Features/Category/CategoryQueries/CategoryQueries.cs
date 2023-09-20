using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.CategoryQueries
{
    public class GetCategories:IRequest<GetCategoriesResponse>
    {
    }
    public class GetCategoriesResponse
    {
        public IEnumerable<GetCategoriesMapper> Categories { get; set; }
    }
    public class GetCategoriesMapper
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
