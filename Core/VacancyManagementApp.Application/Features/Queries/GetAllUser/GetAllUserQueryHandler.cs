using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.User;

namespace VacancyManagementApp.Application.Features.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var entities = await _userService.GetAllUser();
            var response=new GetAllUserQueryResponse();
            var getAllUserDtos = _mapper.Map<List<ListUserDto>>(entities);
            response.GetAllUsers = getAllUserDtos;
            return response;
        }
    }
}
