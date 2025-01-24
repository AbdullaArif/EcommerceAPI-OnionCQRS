using EcommerceAPI.Application.Interfaces.AutoMapper;
using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Details.Command.UpdateDetail
{
    public class UpdateDetailCommandHandler : IRequestHandler<UpdateDetailCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateDetailCommandRequest request, CancellationToken cancellationToken)
        {
            Detail detail = await _unitOfWork.GetReadRepository<Detail>().GetAsync(d => d.Id == request.Id && !d.IsDeleted);

            Detail map = _mapper.Map<Detail,UpdateDetailCommandRequest>(request);

            await _unitOfWork.GetWriteRepository<Detail>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();

        }
    }
}
