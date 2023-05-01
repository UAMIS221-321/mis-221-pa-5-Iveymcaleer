namespace mis_221_pa_5_Iveymcaleer
{
    public class TransactionsReport 
    {
        Transactions[] transactions;

        public int cost;
        public DateOnly dtMonth;
        public DateOnly dtYear;
        static private int count;


        public TransactionsReport(Transactions[] transactions) 
        {
            // this.cost = cost;
            // this.dtMonth = dtMonth;
            // this.dtYear = dtYear;
            this.transactions = transactions;
        }

        public void SetCost(int cost)
        {
            this.cost = cost;
        }

        public int GetCost()
        {
            return cost; 
        }

        public void SetMonth(DateOnly dtMonth) 
        {
            this.dtMonth = dtMonth;
        }

        public DateOnly GetMonth()
        {
            return dtMonth;
        }

        public void SetYear(DateOnly dtYear) 
        {
            this.dtYear = dtYear;
        }

        public DateOnly GetYear()
        {
            return dtYear;
        }
        static public void SetCount(int count) 
        {
            TransactionsReport.count = count;
        }

        static public void IncCount() 
        {
            TransactionsReport.count++;
        }

        static public int GetCount() 
        {
            return TransactionsReport.count;
        }



        




    }
}