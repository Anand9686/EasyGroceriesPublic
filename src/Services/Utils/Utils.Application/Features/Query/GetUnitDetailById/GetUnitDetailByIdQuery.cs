using MediatR;

namespace Utils.Application.Features.Query.GetUnitDetailById
{
    public class GetUnitDetailByIdQuery:IRequest<UnitDetailById>
    {
        public int UnitDetailId { get; set; }

        public GetUnitDetailByIdQuery()
        {

        }

        public GetUnitDetailByIdQuery(int unitDetailId)
        {
            UnitDetailId = unitDetailId;
        }
    }
}
