using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Services
{
    public interface IAuthJWTServices
    {
        string AuthLogin(Login login);
    }
}
