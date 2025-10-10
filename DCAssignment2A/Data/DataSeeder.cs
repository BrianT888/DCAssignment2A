using DCAssignment2A.Models;
using System.Runtime.InteropServices;

namespace DCAssignment2A.Data
{
    // Generates random data into the database
    public static class DataSeeder
    {
        private static readonly int numUsers = 10;     // Determines how many UserProfiles and BankAccounts to make
        public static void Seed(DBManager context)
        {
            // Only seed if empty
            if (context.UserProfiles.Any()) return;

            var random = new Random();

            // Generate random UserProfiles
            var firstNames = new[] { "Sarah", "Bob", "Tim", "James", "Jack", "Chris", "John", "Ethan", "Sophie", "Mike"};
            var lastNames = new[] { "Smith", "Johnson", "Brown", "Wilson", "White", "Lee", "Thompson", "Williams", "Miller", "Jones" };
            var streets = new[] { "Main Street", "High Street", "Willow Grove", "King Street", "Park Avenue", "Green Lane", "Maple Road", "South Grove", "William Street", "Birch Road" };
            var userProfiles = new List<UserProfile>();

            for (int i = 1; i <= numUsers; i++)
            {
                var firstName = firstNames[random.Next(firstNames.Length)];
                var lastName = lastNames[random.Next(lastNames.Length)];
                var fullName = $"{firstName} {lastName}";
                var email = $"{firstName.ToLower()}{i}@gmail.com";
                var address = $"{random.Next(1, 999)} {streets[random.Next(streets.Length)]}, Perth WA";
                var phone = $"04{random.Next(10000000, 99999999)}";
                var password = "password{i}";

                var userProfile = new UserProfile
                {
                    UserProfileId = i,
                    name = fullName,
                    email = email,
                    address = address,
                    phoneNumber = phone,
                    password = password
                };

                userProfiles.Add(userProfile);
            }

            context.UserProfiles.AddRange(userProfiles);
            context.SaveChanges();


            // Generate random BankAccounts
            var banks = new[] { "Commonwealth Bank", "ANZ", "Westpac", "NAB", "Bankwest" };
            var bankAccounts = new List<BankAccount>();

            for (int i = 1; i <= numUsers; i++)
            {
                var user = userProfiles[i - 1]; // zero-based index
                var bankAccount = new BankAccount
                {
                    BankAccountId = i,
                    BankAccountNumber = random.Next(100000, 999999),
                    BankAccountHolderName = user.name,
                    BankName = banks[random.Next(banks.Length)],
                    balance = Math.Round((decimal)(random.NextDouble() * 10000), 2),   // Random balance 0-9999
                    UserProfileId = user.UserProfileId
                };

                bankAccounts.Add(bankAccount);
            }

            context.BankAccounts.AddRange(bankAccounts);
            context.SaveChanges();


            // Generate random Transactions
            var transactions = new List<Transaction>();
            for (int i = 1; i <= random.Next(numUsers, numUsers*3); i++)
            {
                var account = bankAccounts[random.Next(bankAccounts.Count)];   // Pick random account
                var isWithdrawal = random.Next(2) == 0;    // 50/50 change of withdrawal or deposit
                var amount = Math.Round((decimal)(random.NextDouble() * 1000), 2);

                var transaction = new Transaction
                {
                    TransactionId = i,
                    BankAccountId = account.BankAccountId,
                    Date = DateTime.Now.AddDays(-random.Next(1, 30)),
                    Amount = isWithdrawal ? -amount : amount,   // Negative if withdrawal
                    Description = isWithdrawal ? "Withdrawal" : "Deposit"
                };

                transactions.Add(transaction);
            }

            context.Transactions.AddRange(transactions);
            context.SaveChanges();
        }
    }
}
