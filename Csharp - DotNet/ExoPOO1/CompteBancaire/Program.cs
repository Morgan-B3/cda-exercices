using CompteBancaire.Classes;

Client client = new Client();

client.CreateAccount(1);
client.CreateAccount(2);
client.CreateAccount(3);

client.ShowAccounts();

client.Accounts[0].Deposit(150);
client.Accounts[0].Withdraw(40);
client.Accounts[0].ShowOperations();