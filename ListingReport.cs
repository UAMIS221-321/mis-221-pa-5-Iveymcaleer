namespace mis_221_pa_5_Iveymcaleer
{
    public class ListingReport
    {
        Transactions[] transactions;
        SignIn[] signIn;
        CustomerMemberships[] mem;

        public ListingReport(Transactions[] transactions, SignIn[] signIn, CustomerMemberships[] mem)
        {
            this.transactions = transactions;
            this.signIn = signIn;
            this.mem = mem;
        }

        public void FindCustForSessions()
        {
            Console.WriteLine("Provide the customer email address to find customer's sessions");
            string searchVal = (Console.ReadLine());
            int findCustEmail = FoundCustEmail(searchVal);
            if(findCustEmail != -1)
            {
                CustBySessions();
            }
            else
            {
                Console.WriteLine("There is no customer data for that email");
            }

        }

        public void CustBySessions()
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
        }

        public void ProcessBreak1(ref string curr, ref int sesCounts, Transactions newTransaction)
        {
            Console.WriteLine($"{curr}\t{sesCounts}");
            curr = newTransaction.GetCustName();
            sesCounts = newTransaction.GetID();
            Console.WriteLine("Would you like to save this information to a file?\nEnter yes or no");
            string awnser = Console.ReadLine();
            string fileName = "";
            if(awnser == "yes")
            {
                fileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter(fileName);
            }

        }

        // might need to sort ID's 
        public int FoundCustEmail(string searchVal)
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

        // extra that displays customers and their memberships
        public void FindCustForMem()
        {
            Console.WriteLine("Provide the customer email address to find customer's membership");
            string searchVal = (Console.ReadLine());
            int findCustEmail = FoundCustEmail(searchVal);
            if(findCustEmail != -1)
            {
                CustByMembership();
            }
            else
            {
                Console.WriteLine("There is no customer data for that email");
            }
        }
        public void CustByMembership() 
        {
            string curr = mem[0].GetCustName();
            int memId = mem[0].GetCustID();
            for(int i = 1; i < CustomerMemberships.GetCount(); i++) 
            {
                if(mem[i].GetCustName() == curr)
                {
                    memId += mem[i].GetCustID();
                }
                else 
                {
                    Swap(ref curr, ref memId, mem[i]);
                }
            }
        }

        public void Swap(ref string curr, ref int memId, CustomerMemberships newCustMem)
        {
            Console.WriteLine($"{curr}\t{memId}");
            curr = newCustMem.GetCustName();
            memId = newCustMem.GetCustID();
        }

        // a list of all sessions sorted by customer then by date 
        public void CustomersByDate() 
        {
            string curr = transactions[0].GetCustName();
            string date = transactions[0].GetDate();
            int count = 1;
            for(int i = 1; i < Transactions.GetCount(); i++)
            {
                {
                    ProcessBreak(ref curr, ref date, ref count, transactions[i]);
                }
            }
        }

        // for each customer provide total number of sessions 
        public void ProcessBreak(ref string curr, ref string date, ref int count, Transactions newTransaction)
        {
	        Console.WriteLine($"{curr}:\t{date}");
	        curr = newTransaction.GetCustName();
	        date = newTransaction.GetDate();
            Console.WriteLine($"total sessions for customer: {count}");
        }
        
        






        // extra the total count of returningCustomers and newCustomers
        



    }
}