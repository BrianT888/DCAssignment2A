namespace DCAssignment2A.Models
{
    public class BankAccount
    {
        public string accountHolderName { get; set; }
        public int accountNumber { get; set; }
        public int balance { get; set; }
        public UserProfile userProfile { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
