using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;
using MediatR;

namespace DotnetFoundation.Application.UserUseCase.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public string UserId { get; set; }
    }
}