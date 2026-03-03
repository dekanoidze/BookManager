using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.Domain.Entities;

namespace BookManager.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);

    }
}
