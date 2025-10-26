using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IDashboard
    {
        Task<DashboardViewModel> GetDashboardData();
        Task<DashboardBargraphViewModel> GetHomePageData();

    }
}
