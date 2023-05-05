namespace mis_221_pa_5_Iveymcaleer
{
    public class TransactionsUtility
    {
        Transactions[] transactions;
        Listing[] listing;
        CustomerMemberships[] cust;

        public TransactionsUtility(Transactions[] transactions, Listing[] listing, CustomerMemberships[] cust)
        {
            this.transactions = transactions;
            this.listing = listing;
            this.cust = cust;
        }

        public TransactionsUtility(Transactions[] transactions)
        {
            this.transactions = transactions;
        }

        public Listing[] GetAllSessions() 
        {
            Listing[] listing = new Listing[1000];
            // open
            StreamReader inFile = new StreamReader("listings.txt");
            // process 
            Listing.SetCount(0);
            string line = inFile.ReadLine(); // priming read
            while(line != null) 
            { 
                string[] temp = line.Split('#');
                int listId = int.Parse(temp[0]);
                int month = int.Parse(temp[3]);
                int day = int.Parse(temp[4]);
                int year = int.Parse(temp[5]);
                TimeOnly time = TimeOnly.Parse(temp[7]);
                int cost = int.Parse(temp[8]);
                bool statusBooked = bool.Parse(temp[9]);
                int tID = int.Parse(temp[10]);
                listing[Listing.GetCount()] = new Listing(listId, temp[1], temp[2], month, day, year, temp[6], time, cost, statusBooked, tID);
                Listing.IncCount();
                line = inFile.ReadLine(); // update read
            }

            inFile.Close();
            return listing;
        }

        public Transactions[] GetAllTransactions() 
        {
            // open
            StreamReader inFile = new StreamReader("transactions.txt");
            // process 
            Transactions.SetCount(0);
            string line = inFile.ReadLine(); // priming read
            while(line != null) 
            { 
                string[] temp = line.Split('#');
                int sessionId = int.Parse(temp[0]);
                int month = int.Parse(temp[4]);
                int day = int.Parse(temp[5]);
                int year = int.Parse(temp[6]);
                TimeOnly time = TimeOnly.Parse(temp[7]);
                int tId = int.Parse(temp[8]);
                int cost = int.Parse(temp[11]);
                transactions[Transactions.GetCount()] = new Transactions(sessionId, temp[1], temp[2], temp[3], month, day, year, time, tId, temp[9], temp[10], cost, temp[12]);
                Transactions.IncCount();
                line = inFile.ReadLine(); // update read
            }
            inFile.Close();
            return transactions;
        }


        // I added an extra part to Book Sessions becuase since I added a memberships extra, I need to make sure the person booking a class,
        // has a membership because if not they are only granted one free class through the sign in 
        public void BookSession(Listing[] listing) 
        {
            Console.Clear();
            GetAllSessions();
            PrintAllSessions(listing);
            Console.WriteLine("Please enter the session ID of the session you are trying to book?"); 
            int searchVal = int.Parse(Console.ReadLine()); 
            int foundSession = FindSession(searchVal, listing);
            if(foundSession != -1) 
            {
                    int sessionID = searchVal;
                    Console.WriteLine("Enter your name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your email");
                    string email = Console.ReadLine();
                    int month = listing[foundSession].GetMonth();
                    int day = listing[foundSession].GetDay();
                    int year = listing[foundSession].GetYear();
                    string date = listing[foundSession].GetDate();
                    string classType = listing[foundSession].GetClassType();
                    TimeOnly time = listing[foundSession].GetTime();
                    int trainerID = listing[foundSession].GettID(); 
                    string trainerName = listing[foundSession].GetTName();
                    int cost = listing[foundSession].GetCost();
                    Console.WriteLine("Enter 'false' to mark your spot in the class");
                    string f = Console.ReadLine();
                    Transactions newTransaction = new Transactions(sessionID, name, email, date, month, day, year, time, trainerID, trainerName, classType, cost, f);
                    transactions[Transactions.GetCount()] = newTransaction;
                    Transactions.IncCount();
                    SaveSession(transactions);
                    SortById(transactions);
                    listing[foundSession].SetStatus(false); 
                    
                    Console.WriteLine("You have completed this transaction!");
            }
            if(foundSession == -1)
            {
                Console.WriteLine("Session not found");
            }
        }

        public void CancelTransaction(Listing[] listing) // same thing as deleted
        {
            PrintAllSessions(listing);
            Console.WriteLine("What is the session ID of the class you would like to delete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundSession = FindSession(searchVal, listing);
            if(foundSession !=-1)
            {

                listing[foundSession].SetStatus(true);
                SaveSession(transactions);
                GetAllSessions();
                Console.WriteLine("All done");
            }
            else
            {
                Console.WriteLine("Session ID not found");
            }
        }

        public int FindSession(int searchVal, Listing[] listing) 
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listing[i].GetListId() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public Listing[] PrintAllSessions(Listing[] listing) 
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listing[i].GetStatus() == true)
                {
                    Console.WriteLine(listing[i].ToString());
                }
                else
                {
                    Console.WriteLine("No spots are avaliable for this class\n");
                }
            }
            return listing;
        }
        public void SaveSession(Transactions[] transactions) 
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for(int i = 0; i < Transactions.GetCount(); i++) 
            {
                outFile.WriteLine(transactions[i].ToFile());
            }
            outFile.Close();
        }


        public Transactions[] NameByDate(Transactions[] transactions) 
        {
            for(int i = 0; i < Transactions.GetCount() - 1; i++)
            {
                int min = i; 
                for(int j = i + 1; j < Transactions.GetCount(); j++)
                {
                    if(transactions[j].GetCustName().CompareTo(transactions[min].GetCustName()) < 0 ||
                    (transactions[j].GetCustName() == transactions[min].GetCustName() && transactions[j].GetDate().CompareTo((transactions[min].GetDate())) < 0))
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min, i);
                }
            }
            return transactions;
        }

        public Transactions[] SortById(Transactions[] transactions)
        {
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                int min = 0;
                for(int j = i + 1; j < Transactions.GetCount(); j++)
                {
                    if(transactions[j].GetID().CompareTo(transactions[min].GetID()) < 0)
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min, i);
                }
            }
            return transactions;

        }
        private void Swap(int x, int y)
        {
            Transactions temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;
        }

    }
}