namespace Domain.Model

{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}