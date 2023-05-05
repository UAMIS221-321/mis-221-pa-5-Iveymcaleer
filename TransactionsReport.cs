namespace mis_221_pa_5_Iveymcaleer
{
    public class TransactionsReport 
    {
        static private int count;


        public TransactionsReport() 
        {
        
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