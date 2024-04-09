namespace eng.api.Model
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool? Active { get; set; }
    }
}
