using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDashboardService
    {
        Task<string> GetStadiumManagerDashboardDataAsync(string accessToken);

        Task<string> GetAdminDashboardDataAsync();
    }
}
