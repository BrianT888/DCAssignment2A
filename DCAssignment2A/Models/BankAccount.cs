namespace DCAssignment2A.Models
{
    public class BankAccount
    {
        public string accountHolderName { get; set; }
        public int BankAccountId { get; set; } //PK
        public int balance { get; set; }
        public UserProfile userProfile { get; set; }
        public int UserProfileId { get; set; } //FK to UserProfile
        public List<Transaction> transactions { get; set; }
    }
}
