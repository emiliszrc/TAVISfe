namespace TravelManagerFE.Data
{
    public class User
    {
        public User(string username, string password, string organisationId)
        {
            this.Username = username;
            this.Password = password;
            this.OrganisationId = organisationId;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string OrganisationId { get; set; }
    }
}