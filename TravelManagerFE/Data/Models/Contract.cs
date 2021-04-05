namespace TravelManagerFE.Data.Models
{
    public class Contract
    {
        public string Id { get; set; }
        public User User { get; set; }
        public Organisation Organisation { get; set; }
        public ContractType ContractType { get; set; }
    }

    public enum ContractType
    {
        Owner,
        Specialist
    }
}