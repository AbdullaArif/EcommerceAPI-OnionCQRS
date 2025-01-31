using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Command.CreateDetail
{
    public class CreateDetailCommandHandler : IRequestHandler<CreateDetailCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateDetailCommandRequest request, CancellationToken cancellationToken)
        {


            Detail detail = new(request.Tittle, request.Description, request.CategoryId);
            await _unitOfWork.GetWriteRepository<Detail>().AddAsync(detail);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
