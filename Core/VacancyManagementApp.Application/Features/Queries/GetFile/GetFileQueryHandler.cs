using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.File;

namespace VacancyManagementApp.Application.Features.Queries.GetAllFile
{
    public class GetFileQueryHandler : IRequestHandler<GetFileQueryRequest, GetFileQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFileUploadService _uploadService;

        public GetFileQueryHandler(IMapper mapper, IFileUploadService uploadService)
        {
            _mapper = mapper;
            _uploadService = uploadService;
        }

       async Task<GetFileQueryResponse> IRequestHandler<GetFileQueryRequest, GetFileQueryResponse>.Handle(GetFileQueryRequest request, CancellationToken cancellationToken)
        {
            var getFileDto = await _uploadService.GetByOwnerId(request.OwnerId);
            var response=_mapper.Map<GetFileQueryResponse>(getFileDto);
            return response;
        }
    }
}
