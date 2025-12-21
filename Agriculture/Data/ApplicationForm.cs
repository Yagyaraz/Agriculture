namespace Agriculture.Data
{
    public class ApplicationForm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        public string Program { get; set; }
        public string Batch { get; set; }
        public string Qualification { get; set; }
        public string Institution { get; set; }
        public string Experience { get; set; }
        public string ResumePath { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
