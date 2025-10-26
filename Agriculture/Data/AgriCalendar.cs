using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class AgriCalendar
    {
        [Key]
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string Variety { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }


        [ForeignKey(nameof(TypeId))]
        public AgriCalendarType AgriCalendarType { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public AgriCalendarCategory AgriCalendarCategory { get; set; }
        [ForeignKey(nameof(ProductId))]
        public AgriCalendarProduct AgriCalendarProduct { get; set; }

    }
    public class AgriCalendarDetail
    {
        [Key]
        public int Id { get; set; }
        public int AgriCalendarId { get; set; }

        public int EcologicalAreaId { get; set; }
        public decimal ElevationFrom { get; set; }
        public decimal ElevationTo{ get; set; }
        public int SowingStartMonthId { get; set; }
        public int SowingEndMonthId { get; set; }
        public int SowingStartWeekId { get; set; }
        public int SowingEndWeekId { get; set; }
        public int HarvestStartMonthId { get; set; }
        public int HarvestEndMonthId { get; set; }
        public int HarvestStartWeekId { get; set; }
        public int HarvestEndWeekId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }


        [ForeignKey(nameof(AgriCalendarId))]
        public AgriCalendar AgriCalendar {  get; set; }
        [ForeignKey(nameof(EcologicalAreaId))]
        public EcologicalArea EcologicalArea {  get; set; }
        [ForeignKey(nameof(SowingStartMonthId))]
        public Month SowingStartMonth {  get; set; }
        [ForeignKey(nameof(SowingEndMonthId))]
        public Month SowingEndMonth {  get; set; }
        [ForeignKey(nameof(HarvestStartMonthId))]
        public Month HarvestStartMonth {  get; set; }
        [ForeignKey(nameof(HarvestEndMonthId))]
        public Month SowingHarvestEndMonth {  get; set; }
        [ForeignKey(nameof(SowingStartWeekId))]
        public Week SowingStartWeek {  get; set; }
        [ForeignKey(nameof(SowingEndWeekId))]
        public Week SowingEndWeek {  get; set; }
        [ForeignKey(nameof(HarvestStartWeekId))]
        public Week HarvestStartWeek {  get; set; }
        [ForeignKey(nameof(HarvestEndWeekId))]
        public Week SowingHarvestEndWeek {  get; set; }
        
    }

    public class AgriCalendarType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class AgriCalendarCategory
    {
        [Key]
        public int Id { get; set; }
        public int AgriCalendarTypeId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        [ForeignKey(nameof(AgriCalendarTypeId))]
        public AgriCalendarType AgriCalendarType { get; set; }
    }
    public class AgriCalendarProduct
    {
        [Key]
        public int Id { get; set; }
        public int AgriCalendarTypeId { get; set; }
        public int AgriCalendarCategoryId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }

        [ForeignKey(nameof(AgriCalendarTypeId))]
        public AgriCalendarType AgriCalendarType { get; set; }
        [ForeignKey(nameof(AgriCalendarCategoryId))]
        public AgriCalendarCategory AgriCalendarCategory { get; set; }
    }
    public class EcologicalArea
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class Month
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class Week
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
}
