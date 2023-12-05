using System;

namespace Tlab_13
{
    internal class BankTransaction
    {
        public readonly DateTime Date;
        public readonly decimal Amount;

        public BankTransaction(decimal amount)
        {
            Date = DateTime.Now;
            Amount = amount;
        }
        public void Print()
        {
            Console.WriteLine($"Дата: {Date}, сумма: {Amount}");
        }
    }
}
