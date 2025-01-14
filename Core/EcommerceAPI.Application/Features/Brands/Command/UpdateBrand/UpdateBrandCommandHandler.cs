using EcommerceAPI.Application.Interfaces.AutoMapper;
using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Brands.Command.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand brand = await _unitOfWork.GetReadRepository<Brand>().GetAsync(b=>b.Id==request.Id && !b.IsDeleted);

            var map = _mapper.Map<Brand,UpdateBrandCommandRequest>(request);

            await _unitOfWork.GetWriteRepository<Brand>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
        }
    }
}
