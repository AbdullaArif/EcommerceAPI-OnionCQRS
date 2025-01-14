using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Brands.Command.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand brand = new(request.Name);
            await _unitOfWork.GetWriteRepository<Brand>().AddAsync(brand);

            await _unitOfWork.SaveAsync();
        }
    }
}
