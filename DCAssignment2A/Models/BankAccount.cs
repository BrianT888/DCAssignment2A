namespace DCAssignment2A.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; } //PK
        public int BankAccountNumber { get; set; } //for searching
        public string? BankAccountHolderName { get; set; } //additional field for assignment
        public string? BankName { get; set; } //additional field for assignment
        public decimal balance { get; set; }
        //public UserProfile? userProfile { get; set; } //imma comment it out but personally i think might not be needed as we have the FK that we can use to cycle though stuff
        public int UserProfileId { get; set; } //FK to UserProfile
        //public List<Transaction> transactions { get; set; } = new List<Transaction>();//on creation, initialize to empty list //same reason as above?
    }
}
