using Abp.Application.Services;
using ZOGLAB.MMMS.Dto;
using ZOGLAB.MMMS.Logging.Dto;

namespace ZOGLAB.MMMS.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
