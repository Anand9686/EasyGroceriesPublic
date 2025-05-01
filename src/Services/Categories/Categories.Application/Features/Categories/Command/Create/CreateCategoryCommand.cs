using MediatR;

namespace Categories.Application.Features.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescr { get; set; }
        public int CategoryParent { get; set; }
        public bool Flag { get; set; }
    }
}
