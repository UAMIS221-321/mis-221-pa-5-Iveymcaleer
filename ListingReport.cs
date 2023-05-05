namespace mis_221_pa_5_Iveymcaleer
{
    public class ListingReport
    {
        static private int count;

        public ListingReport() 
        {

        }


        static public void SetCount(int count) 
        {
            ListingReport.count = count;
        }

        static public void IncCount() 
        {
            ListingReport.count++;
        }
        static public int GetCount() 
        {
            return ListingReport.count;
        }

    }
}