using AutoMapper;
using VacancyManagementApp.Application.DTOs.Answer;
using VacancyManagementApp.Application.DTOs.ApplicationForm;
using VacancyManagementApp.Application.DTOs.File;
using VacancyManagementApp.Application.DTOs.Question;
using VacancyManagementApp.Application.DTOs.Result;
using VacancyManagementApp.Application.DTOs.User;
using VacancyManagementApp.Application.DTOs.Vacancy;
using VacancyManagementApp.Application.Features.Commands.Answer.Create;
using VacancyManagementApp.Application.Features.Commands.Answer.Update;
using VacancyManagementApp.Application.Features.Commands.ApplicationForm.CreateApplicationForm;
using VacancyManagementApp.Application.Features.Commands.AppUser.CreateUser;
using VacancyManagementApp.Application.Features.Commands.Question.Create;
using VacancyManagementApp.Application.Features.Commands.Question.Remove;
using VacancyManagementApp.Application.Features.Commands.Question.Update;
using VacancyManagementApp.Application.Features.Commands.Result.Create;
using VacancyManagementApp.Application.Features.Commands.Result.Update;
using VacancyManagementApp.Application.Features.Commands.Vacancy.CreateVacancy;
using VacancyManagementApp.Application.Features.Commands.Vacancy.RemoveVacancy;
using VacancyManagementApp.Application.Features.Commands.Vacancy.UpdateVacancy;
using VacancyManagementApp.Application.Features.Queries.GetAllApplicationForm;
using VacancyManagementApp.Application.Features.Queries.GetAllFile;
using VacancyManagementApp.Application.Features.Queries.GetAllQuestions;
using VacancyManagementApp.Application.Features.Queries.GetAllUser;
using VacancyManagementApp.Application.Features.Queries.GetAllVacancy;
using VacancyManagementApp.Application.Features.Queries.GetByIdVacancy;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Domain.Entities.Identity;

namespace VacancyManagementApp.Application.Extensions
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<CreateUserCommandRequest, CreateUserDto>();
            CreateMap<CreateUserResponseDto, CreateUserCommandResponse>();

            CreateMap<CreateUserDto, AppUser>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(src => src.NameSurname));



            CreateMap<CreateVacancyResponseDto, CreateVacancyCommandResponse>();
            CreateMap<CreateVacancyCommandRequest, CreateVacancyDto>();
            CreateMap<CreateVacancyDto, Vacancy>();

            CreateMap<CreateAnswerResponseDto, CreateAnswerCommandResponse>();
            CreateMap<CreateAnswerCommandRequest, CreateAnswerDto>();
            CreateMap<CreateAnswerDto, Answer>();

            CreateMap<GetAllVacancyQueryRequest, ListVacancyDto>();
            CreateMap<Vacancy, ListVacancyDto>();

            CreateMap<GetAllUserQueryRequest, ListUserDto>();
            CreateMap<AppUser, ListUserDto>();

            CreateMap<GetAllApplicationFormQueryRequest, GetAllApplicationFormDto>();
            CreateMap<ApplicationForm, GetAllApplicationFormDto>();

            CreateMap<GetAllApplicationFormQueryRequest, GetAllAnswerDto>();
            CreateMap<Answer, GetAllAnswerDto>();

            CreateMap<Vacancy, SingleVacancyDto>(); 
            CreateMap<GetByIdVacancyQueryRequest, SingleVacancyDto>();
            CreateMap<SingleVacancyDto,GetByIdVacancyQueryResponse>();

            CreateMap<QuestionResponseDto, CreateQuestionCommandResponse>();
            CreateMap<CreateQuestionCommandRequest, QuestionDto>();
            CreateMap<QuestionDto, Question>();

            CreateMap<GetAllQuestionQueryRequest, GetAllQuestionDto>();
            CreateMap<Question, GetAllQuestionDto>();

            CreateMap<UpdateVacancyResponseDto, UpdateVacancyCommandResponse>();
            CreateMap<UpdateVacancyCommandRequest,UpdateVacancyDto>();
            CreateMap<UpdateVacancyDto, Vacancy>();

            CreateMap<ResultResponseDto, UpdateVacancyCommandResponse>();
            CreateMap<UpdateResultCommandRequest,UpdateResultDto>();
            CreateMap<UpdateResultDto, Result>();


            CreateMap<RemoveVacancyResponseDto, RemoveVacancyCommandResponse>();
            CreateMap<Vacancy, RemoveVacancyResponseDto>();

            CreateMap<RemoveQuestionResponseDto, RemoveQuestionCommandResponse>();
            CreateMap<Question, RemoveQuestionResponseDto>();

            CreateMap<ResultResponseDto, CreateResultCommandResponse>();
            CreateMap<CreateResultCommandRequest, ResultCreateDto>();
            CreateMap<ResultCreateDto, Result>();
            CreateMap<Result,GetAllResultDto>();

            CreateMap<CreateApplicationFormCommandRequest, CreateApplicationFormDto>();
            CreateMap<CreateApplicationFormDto, ApplicationForm>();
            CreateMap<CreateApplicationFormResponseDto, CreateApplicationFormCommandResponse>();


            CreateMap<UploadedFile, GetFileByOwnerDto>();
            CreateMap<GetFileByOwnerDto, GetFileQueryResponse>();

            CreateMap<UpdateQuestionCommandRequest, UpdateQuestionDto>();
            CreateMap<UpdateQuestionDto, UpdateQuestionCommandResponse>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Question updated successfully."));

            CreateMap<UpdateAnswerCommandRequest, UpdateAnswerDto>();
            CreateMap<UpdateAnswerDto, UpdateAnswerCommandResponse>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Answer updated successfully."));

        }
    }
}