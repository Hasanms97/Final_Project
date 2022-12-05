using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Repository
{
    public interface IBankvisaRepository
    {
        Bankvisa CheckBankVISA(Bankvisa bankvisa);

    }
}
