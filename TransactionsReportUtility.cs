namespace mis_221_pa_5_Iveymcaleer
{
    public class TransactionsReportUtility
    {
        TransactionsReport[] tReport;

        Transactions[] transactions;

        CustomerMemberships[] custMems;

        public TransactionsReportUtility(Transactions[] transactions, CustomerMemberships[] custMems)
        {
            this.transactions = transactions;
            this.custMems = custMems;
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

        public void SortByMonth(Transactions[] transactions)
        {
            for(int i = 0; i < Transactions.GetCount() -1; i++)
            {
                int max = i;
                for(int j = i + 1; j < Transactions.GetCount(); j++){
                    if(transactions[j].GetMonth() > transactions[max].GetMonth())
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

        public void GetRevenue() 
        {
            StreamReader inFile = new StreamReader("transactions.txt");
            Transactions[] transactions = new Transactions[600];
            Transactions.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                transactions[Transactions.GetCount()] = new Transactions(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), int.Parse(temp[5]), int.Parse(temp[6]), TimeOnly.Parse(temp[7]), int.Parse(temp[8]), temp[9], temp[10], int.Parse(temp[11]), temp[12]);
                Transactions.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }

        public void RevenueReport(Transactions[] transactions) 
        {
            SortByYear(transactions);
            SortByMonth(transactions);
            PrintAllTransactions(transactions);

            int yearT = transactions[0].GetYear();
            int monthT = transactions[0].GetMonth();
            
            int monthRevT = transactions[0].GetCost();
            int yearRevT = transactions[0].GetCost();


            string[] monthN = {"January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                if(monthT == transactions[i].GetMonth())
                {
                    monthRevT += transactions[i].GetCost();
                }
                else{
                    Console.Clear();
                    Console.WriteLine("{0}: {1}", monthN[monthT-1], monthRevT);
                    monthRevT = 0;
                    monthT = transactions[i].GetMonth();
                }
                yearRevT += transactions[i].GetCost();
            }
            ProcessBreak(ref monthT, ref monthRevT, Transactions.GetCount()-1);
            Console.WriteLine($"\n\n{yearT} Revenue: {yearRevT}");
            Console.WriteLine("**Not including revenue from memberships, just from transactions");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("\nWould you like to save this information to a file?");
            Console.WriteLine("Enter '1' for yes, Enter '2' for no");
            int awnser = int.Parse(Console.ReadLine());
            if(awnser == 1)
            {
                using (StreamWriter revenue = new StreamWriter("historical revenue report", true))
                {
                    revenue.WriteLine("{0}: {1}", monthN[monthT-1], monthRevT);
                    revenue.WriteLine($"{yearT} Revenue: {yearRevT}");
                    revenue.WriteLine("**Not including revenue from memberships, just from transactions");
                }
            }
            if(awnser == 2)
            {
                Console.WriteLine("Okay");
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            }
            if(awnser != 1 || awnser != 2)
            {
                Console.WriteLine("Invalid choice");
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            }
            Console.WriteLine("Exiting...");
            Environment.Exit(0);

        }


        public void ProcessBreak(ref int month, ref int monthRev, int i)
        {
            string[] monthN = {"January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            Console.WriteLine("{0}: {1}", monthN[month-1], monthRev);
        
        }



        public void PrintAllTransactions(Transactions[] transactions){
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

