using System.ComponentModel.DataAnnotations;

namespace Agriculture.Areas.Admin.Models
{
    public class AgriCalendarViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string Variety { get; set; }

        public string TypeName { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }


        public List<AgriCalendarDetailViewModel> AgriCalendarDetailViewModelList { get; set; } = new List<AgriCalendarDetailViewModel>();
    }
    public class AgriCalendarDetailViewModel
    {
        public int Id { get; set; }
        public int AgriCalendarId { get; set; }
        public int EcologicalAreaId { get; set; }
        public decimal ElevationFrom { get; set; }
        public decimal ElevationTo { get; set; }
        public int SowingStartMonthId { get; set; }
        public int SowingEndMonthId { get; set; }
        public int SowingStartWeekId { get; set; }
        public int SowingEndWeekId { get; set; }
        public int HarvestStartMonthId { get; set; }
        public int HarvestEndMonthId { get; set; }
        public int HarvestStartWeekId { get; set; }
        public int HarvestEndWeekId { get; set; }
    }
    public class AgriCalendarTypeViewModel
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class AgriCalendarCategoryViewModel
    {
       
        public int Id { get; set; }
        public int AgriCalendarTypeId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string AgriCalendarType { get; set; }

    }
    public class AgriCalendarProductViewModel
    {

        public int Id { get; set; }
        public int AgriCalendarTypeId { get; set; }
        public int AgriCalendarCategoryId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string AgriCalendarType { get; set; }
        public string AgriCalendarCategory { get; set; }

    }
}
