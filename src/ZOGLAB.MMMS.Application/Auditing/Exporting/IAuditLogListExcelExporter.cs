using System.Collections.Generic;
using ZOGLAB.MMMS.Auditing.Dto;
using ZOGLAB.MMMS.Dto;

namespace ZOGLAB.MMMS.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
