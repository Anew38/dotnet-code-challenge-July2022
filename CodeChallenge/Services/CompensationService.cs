using System;
using System.Threading.Tasks;
using CodeChallenge.Data;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, IEmployeeRepository compensationRepository)
        {
            employeeRepository = compensationRepository;
            _logger = logger;
        }

        public Compensation Add(Compensation compensation)
        {
            throw new NotImplementedException();
        }

        public Compensation Create(Compensation compensation)
        {
            if (compensation != null)
            {
              //  employeeRepository.Add(compensation);
              //  employeeRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        public Compensation GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Compensation Read(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                //return employeeRepository.GetById(id);
            }

            return null;
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}

