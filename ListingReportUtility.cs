namespace mis_221_pa_5_Iveymcaleer
{
    public class ListingReportUtility
    {
        
        Transactions[] transactions;
        CustomerMemberships[] custMems;

        public ListingReportUtility(Transactions[] transactions, CustomerMemberships[] custMems)
        {
            this.transactions = transactions;
            this.custMems = custMems;
        }

        // find customer email for 1st control break report //
        public void FindCustForSessions()
        {
            Console.WriteLine("Provide the customer email address to find customer's sessions");
            string searchVal = (Console.ReadLine());
            int findCustEmail = FoundCustEmail(searchVal, transactions);
            if(findCustEmail != -1)
            {
                CustomerSessionsReport(transactions);
            }
            else
            {
                Console.WriteLine("There is no customer data for that email");
            }

        }

        // individual cust sessions report //
        public Transactions[] CustomerSessionsReport (Transactions[] transactions)
        {
            string curr = transactions[0].GetCustName();
            int sesCounts = transactions[0].GetID();
            for(int i = 1; i < Transactions.GetCount(); i++)
            {
                if(transactions[i].GetCustName() == curr)
                {
                    sesCounts += transactions[i].GetID();
                }
                else
                {
                    ProcessBreak1(ref curr, ref sesCounts, transactions[i]);
                }
            }
            return transactions;
        }

        // ProcessBreak for above //
        public void ProcessBreak1(ref string curr, ref int sesCounts, Transactions newTransaction)
        {
            Console.WriteLine($"{curr}\t{sesCounts}");
            curr = newTransaction.GetCustName();
            sesCounts = newTransaction.GetID();
            Console.WriteLine("Would you like to save this information to a file?\nEnter yes or no");
            string awnser = Console.ReadLine();
            string fileName = "HistoricalCustSess.txt";
            if(awnser == "yes")
            {
                fileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter(fileName);
            }
            else{
                GoodBye();
            }

        }

        // searchval for 1st control break report //
        public int FoundCustEmail(string searchVal, Transactions[] transactions)
        {
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                if(transactions[i].GetCustEmail() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        // search val for extra control break report //
        public int FoundCustEmail2(string searchVal, CustomerMemberships[] custMems)
        {
            for(int i = 0; i < CustomerMemberships.GetCount(); i++)
            {
                if(custMems[i].GetCustEmail() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }



        // extra that displays customers and their memberships //
        public void FindCustForMem()
        {
            Console.WriteLine("Provide the customer email address to find customer's membership");
            string searchVal = (Console.ReadLine());
            int findCustEmail = FoundCustEmail2(searchVal, custMems);
            if(findCustEmail != -1)
            {
                CustByMembership(custMems);
            }
            else
            {
                Console.WriteLine("There is no customer data for that email");
            }
        }
        public void CustByMembership(CustomerMemberships[] custMems) 
        {
            string curr = custMems[0].GetCustName();
            int memId = custMems[0].GetCustID();
            for(int i = 1; i < CustomerMemberships.GetCount(); i++) 
            {
                if(custMems[i].GetCustName() == curr)
                {
                    memId += custMems[i].GetCustID();
                }
                else 
                {
                    ProcessBreak(ref curr, ref memId, custMems[i]);
                }
            }
        }

        public void ProcessBreak(ref string curr, ref int memId, CustomerMemberships newCustMem)
        {
            Console.WriteLine($"{curr}:\t{memId}");
            curr = newCustMem.GetCustName();
            memId = newCustMem.GetCustID();
        }

        // 2nd control break report //
        public void CustomersByDate(Transactions[] transactions) 
        {
            string curr = transactions[0].GetCustName();
            string date = transactions[0].GetDate();
            //int count = 1;
            for(int i = 1; i < Transactions.GetCount(); i++)
            {
                {
                    //ProcessBreak(transactions, ref curr, ref date, ref count, newTransaction);
                }
            }
        }

        public void ProcessBreak(Transactions[] transactions, ref string curr, ref string date, ref int count, Transactions newTransaction)
        {
	        Console.WriteLine($"{curr}:\t{date}");
	        curr = newTransaction.GetCustName();
	        date = newTransaction.GetDate();
            Console.WriteLine($"total sessions for customer: {count}");
        }


        // exiting method //
        public void GoodBye() 
        {
            Console.WriteLine("Exiting...");
        }


    }
}
    
