using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Queries.GetAllUser
{
    public class GetAllUserQueryRequest:IRequest<GetAllUserQueryResponse>
    {
    }
}
