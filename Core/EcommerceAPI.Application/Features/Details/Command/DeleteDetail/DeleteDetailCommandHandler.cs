using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Command.DeleteDetail
{
    public class DeleteDetailCommandHandler : IRequestHandler<DeleteDetailCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDetailCommandRequest request, CancellationToken cancellationToken)
        {
            Detail detail = await _unitOfWork.GetReadRepository<Detail>().GetAsync(d=>d.Id==request.Id && !d.IsDeleted);
            detail.IsDeleted = true;

            await _unitOfWork.GetWriteRepository<Detail>().UpdateAsync(detail);
            await _unitOfWork.SaveAsync();
        }
    }
}
