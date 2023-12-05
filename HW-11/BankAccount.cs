using System;
using System.Collections.Generic;
using System.IO;

namespace Tlab_13
{
    public enum AccountType
    {
        Текущий,
        Сберегательный
    }
    internal class BankAccount
    {
        public static int unique_id = 1;
        public int id { get; private set; }
        protected decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение баланса не может быть отрицательным");
                }

                balance = value;
                transactions.Add(new BankTransaction(value));
            }
        }

        public AccountType AccountType { get; }

        public string Holder { get; set; }

        public List<BankTransaction> transactions = new List<BankTransaction>();

        public BankAccount()
        {
            id = unique_id;
            transactions = new List<BankTransaction>();
            unique_id++;
        }

        public BankAccount(decimal balance)
        {
            id = unique_id;
            Balance = balance;
            transactions = new List<BankTransaction>();
            unique_id++;
        }

        public BankAccount(AccountType AccountType)
        {
            id = unique_id;
            this.AccountType = AccountType;
            transactions = new List<BankTransaction>();
            unique_id++;
        }

        public BankAccount(decimal balance, AccountType AccountType, string Holder)
        {
            id = unique_id;
            Balance = balance;
            this.AccountType = AccountType;
            this.Holder = Holder;
            transactions = new List<BankTransaction>();
            unique_id++;
        }




        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("Сумма снятия превышает баланс");
            }

            Balance -= amount;
            transactions.Add(new BankTransaction(-amount));
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            transactions.Add(new BankTransaction(amount));
        }

        public void Transfer(BankAccount otherAccount, decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("Сумма перевода превышает баланс");
            }

            Withdraw(amount);
            otherAccount.Deposit(amount);
        }

        public void Print()
        {
            Console.WriteLine($"Номер счета: {id}, баланс: {Balance}, тип счета: {AccountType}, держатель: {Holder}");
        }

        public List<BankTransaction> Transactions
        {
            get { return transactions; }
        }
        public void Dispose()
        {
            string filename = $"{id}.txt";
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (BankTransaction transaction in transactions)
                {
                    writer.WriteLine(transaction.ToString());
                }
            }
            GC.SuppressFinalize(this);
        }
        public BankTransaction this[int index]
        {
            get
            {
                if (index >= 0 && index < transactions.Count)
                {
                    return transactions[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }
        }

    }
}
