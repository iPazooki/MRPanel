using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using MRPanel.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public class SitePageAppService : ISitePageAppService
    {
        private readonly IRepository<Page, Guid> _repository;
        private readonly IObjectMapper _objectMapper;

        public SitePageAppService(IRepository<Page, Guid> repository, IObjectMapper objectMapper)
        {
            _repository = repository;
            _objectMapper = objectMapper;
        }

        public async Task<IEnumerable<SitePageDto>> GetAll()
        {
            var items = await _repository.GetAllListAsync();

            return _objectMapper.Map<List<SitePageDto>>(items);
        }
    }
}