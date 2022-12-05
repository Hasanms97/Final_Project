using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class BankvisaServices : IBankvisaServices
    {
        private readonly IBankvisaRepository _bankvisaRepository;

        public BankvisaServices(IBankvisaRepository bankvisaRepository)
        {
            _bankvisaRepository = bankvisaRepository;
        }


        public Bankvisa CheckBankVISA(Bankvisa bankvisa)
        {
            return _bankvisaRepository.CheckBankVISA(bankvisa);
        }
    }
}
