using EcommerceAPI.Application.Features.Brands.Rules;
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
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BrandRules _brandRules;
        public CreateBrandCommandHandler(IUnitOfWork unitOfWork, BrandRules brandRules)
        {
            _unitOfWork = unitOfWork;
            _brandRules = brandRules;
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brands = await _unitOfWork.GetReadRepository<Brand>().GetAllAsync();

            await _brandRules.BrandMustBeUnique(request.Name, brands);


            Brand brand = new(request.Name);
            await _unitOfWork.GetWriteRepository<Brand>().AddAsync(brand);

            await _unitOfWork.SaveAsync();


            return Unit.Value;
        }
    }
}
