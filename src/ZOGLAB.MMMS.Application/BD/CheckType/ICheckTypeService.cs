﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface ICheckTypeAppService : IApplicationService
    {
        //Task<PagedResultDto<UnitListDto>> GetUnits(GetUnitsInput input);
        Task<List<CheckTypeFReadDto>> GetAll();
    }
}
