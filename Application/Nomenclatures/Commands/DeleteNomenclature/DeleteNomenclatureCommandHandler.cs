using Application.Shared.Exceptions;
using Application.Shared.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Nomenclatures.Commands.DeleteNomenclature
{
    public class DeleteNomenclatureCommandHandler : IRequestHandler<DeleteNomenclatureCommand, Unit>
    {
        private readonly IDbContext _context;

        public DeleteNomenclatureCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteNomenclatureCommand request, CancellationToken cancellationToken)
        {
            var nomenclature = await _context.Nomenclatures.FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Nomenclature), request.Id.ToString());

            _context.Nomenclatures.Remove(nomenclature);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
