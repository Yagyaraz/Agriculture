using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Areas.Admin.Repositories
{
    public class DashboardRepository : IDashboard
    {
        private readonly AgricultureDbContext _context;

        public DashboardRepository(AgricultureDbContext context)
        {
            _context = context;
        }
        public async Task<DashboardViewModel> GetDashboardData()
        {
            var data = new DashboardViewModel()
            {
                FarmerCount  = await _context.Farmer.CountAsync(),
                TotalAnudanCount = await _context.Subsidy.CountAsync(),
                TotalTalimCount = await _context.Training.CountAsync(),
                TotalYojanaCount = await _context.AgricultureService.CountAsync(),

                TotalMale = await _context.Farmer.Where(x => x.GenderId == 1).CountAsync(),
                TotalFemale = await _context.Farmer.Where(x => x.GenderId == 2).CountAsync(),
                TotalOther = await _context.Farmer.Where(x => x.GenderId == 3).CountAsync(),

            };

            return data;
        }
        public async Task<DashboardBargraphViewModel> GetHomePageData()
        {
            var data = new DashboardBargraphViewModel()
            {
                TaskTraining = await _context.Training.Where(x => x.StartDateEng == DateTime.Now.Date).Select(x => x.Title).ToListAsync(),
                TaskSubsedy = await _context.Subsidy.Where(x => x.StartDateEng == DateTime.Now.Date).Select(x => x.AgricultureProgram.Title).ToListAsync(),
                TaskService = await _context.AgricultureService.Where(x => x.ValidTillDateEng == DateTime.Now.Date).Select(x => x.ServiceName).ToListAsync(),
            };
            return data;
        }
    }
}
