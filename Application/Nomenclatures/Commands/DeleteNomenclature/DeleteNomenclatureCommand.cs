using MediatR;

namespace Application.Nomenclatures.Commands.DeleteNomenclature
{
    public class DeleteNomenclatureCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
