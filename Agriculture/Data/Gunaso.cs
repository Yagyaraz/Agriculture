namespace Agriculture.Data
{
    public class Gunaso
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string FilePath { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
