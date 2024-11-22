using AutoMapper;
using MediatR;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.User;

namespace VacancyManagementApp.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var createUserDto = _mapper.Map<CreateUserDto>(request);

            CreateUserResponseDto response = await _userService.CreateAsync(createUserDto);

            return _mapper.Map<CreateUserCommandResponse>(response);
        }
    }
}
