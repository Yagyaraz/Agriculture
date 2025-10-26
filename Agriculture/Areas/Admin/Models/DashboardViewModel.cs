using System.Reflection.Metadata.Ecma335;

namespace Agriculture.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int FarmerCount { get; set; }
        public int TotalYojanaCount { get; set; }
        public int TotalAnudanCount { get; set; }
        public int TotalTalimCount { get; set; }

        public int TotalMale {  get; set; }
        public int TotalFemale {  get; set; }
        public int TotalOther {  get; set; }
    }
    public class DashboardBargraphViewModel
    {
        public List<string> TaskTraining { get; set; }
        public List<string> TaskSubsedy { get; set; }
        public List<string> TaskService { get; set; }

    }
}
