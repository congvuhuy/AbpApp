using Ord.AbpApp.Communes.Dtos;
using Ord.AbpApp.Districts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ord.AbpApp.Communes
{
    public interface ICommuneService:IScopedDependency
    {
        public Task<List<CommuneDto>> GetFilterAsync(int pageNumber, int pageSize);
    }
}
