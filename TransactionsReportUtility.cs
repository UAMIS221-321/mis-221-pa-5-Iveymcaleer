namespace mis_221_pa_5_Iveymcaleer
{
    public class TransactionsReportUtility
    {
        TransactionsReport[] tReport;

        Transactions[] transactions;

        public TransactionsReportUtility(Transactions[] transactions)
        {
            this.transactions = transactions;
        }

        public void SortByYear(Transactions[] transactions) 
        {
            for(int i = 0; i < Transactions.GetCount() - 1; i++)
            {
                int max = i; 
                for(int j = i + 1; j < Transactions.GetCount(); j++)
                {
                    if(transactions[j].GetYear() > transactions[max].GetYear())
                    {
                        max = j;
                    }
                }
                if(max != i)
                {
                    Swap(max, i);
                }
            }
        }

        public void PrintAllTransactions(){
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                Console.WriteLine(transactions[i].ToString());
            }
        }

        private void Swap(int x, int y)
        {
            Transactions temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;
        }


                
    }
}

