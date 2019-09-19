using Shop.Core.Entities;
using Shop.Core.Interfaces;
using Shop.Core.Interfaces.Repositories;
using Shop.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LogService(ILogRepository logRepository, IUnitOfWork unitOfWork)
        {
            _logRepository = logRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task SaveAsync(Log log)
        {
            try
            {
                this._logRepository.Add(log);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
            }
        }
    }
}