using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Repository
{
    public interface IAuthJWTRepository
    {
        Login AuthLogin(Login login);
    }
}
