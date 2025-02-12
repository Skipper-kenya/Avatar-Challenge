namespace Avatar_Challenge.Dtos
{
    public class AvatarDto
    {

        public int Id { get; set; }

        public string FullNames { get; set; }

        public string Email { get; set; }

        public string RegistrationNumber { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
