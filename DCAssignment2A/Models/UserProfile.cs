namespace DCAssignment2A.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; } //PK
        public string? name { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        public byte[]? profilePicture { get; set; }
        public string? password { get; set; }

        //public List<BankAccount> bankAccounts { get; set; } = new List<BankAccount>();//on creation, initialize to empty list //same reason in BankAccount.cs
    }
}
