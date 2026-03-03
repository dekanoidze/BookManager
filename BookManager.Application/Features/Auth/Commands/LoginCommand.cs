using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookManager.Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<String>
    {
        public string Email {  get; set; }=string.Empty;
        public string Password { get; set; }= string.Empty; 
    }
}
