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

        public Listing[] GetAllSessions(Listing[] listing) 
        {
            // open
            StreamReader inFile = new StreamReader("listing.txt");
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
                TimeOnly time = TimeOnly.Parse(temp[8]);
                int cost = int.Parse(temp[7]);
                bool statusBooked = bool.Parse(temp[9]);
                listing[Listing.GetCount()] = new Listing(listId, temp[1], temp[2], month, day, year, temp[6], time, cost, statusBooked);
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
                transactions[Transactions.GetCount()] = new Transactions(sessionId, temp[1], temp[2], temp[3], month, day, year, time, tId, temp[9], temp[10], cost);
                Transactions.IncCount();
                line = inFile.ReadLine(); // update read
            }
            inFile.Close();
            return transactions;
        }


        // I added an extra part to Book Sessions becuase since I added a memberships extra, I need to make sure the person booking a class,
        // has a membership because if not they are only granted one free class through the sign in 
        public Transactions[] BookSession() 
        {
            PrintAllSessions();
            Console.WriteLine("Please enter the session ID of the session you are trying to book?"); 
            int searchVal = int.Parse(Console.ReadLine()); 
            int foundSession = FindSession(searchVal);

            if(foundSession != -1) 
            {
                Console.WriteLine("Enter your email");
                string searchVal2 = (Console.ReadLine());
                int foundCust = FindCust(searchVal2);
                if(foundCust != -1)
                {
                    Console.WriteLine("We have found your membership to book a session.\nTo complete the transaction:");
                    Console.WriteLine("Please enter the session ID again");
                    //transactions[Transactions.GetCount()].SetID(Console.)
                    Console.WriteLine("Enter your name");
                    transactions[Transactions.GetCount()].SetCustName(Console.ReadLine());
                    Console.WriteLine("Please enter your email again");
                    transactions[Transactions.GetCount()].SetCustEmail(Console.ReadLine());
                    Console.WriteLine("Please enter the month (MM)");
                    transactions[Transactions.GetCount()].SetMonth(listing[foundSession].GetMonth());
                    Console.WriteLine("Please enter the day (DD)");
                    transactions[Transactions.GetCount()].SetDay(listing[foundSession].GetDay());
                    Console.WriteLine("Please enter the year (YYYY)");
                    transactions[Transactions.GetCount()].SetYear(listing[foundSession].GetYear());
                    Console.WriteLine("Please enter the time (00:00 AM/PM)");
                    transactions[Transactions.GetCount()].SetTime(listing[foundSession].GetTime());
                    Console.WriteLine("Please enter trainer ID");
                    transactions[Transactions.GetCount()].SetTId(listing[foundSession].GetListId());
                    Console.WriteLine("Please enter the trainer name");
                    transactions[Transactions.GetCount()].SetTName(listing[foundSession].GetTName());
                    listing[foundSession].SetStatus(false);
                    Save(transactions);
                    SortById(transactions);
                    Console.WriteLine("You have completed this transaction!");
                }
                else
                {
                    Console.WriteLine("Unable to book session because there is no membership linked to your email");
                }
            }
            if(foundSession == -1)
            {
                Console.WriteLine("Session is booked :(");
            }
            else
            {
                Console.WriteLine("Session not found :(");
            }
            return transactions;

        }

        // public Transactions[] CancelTransaction()
        // {
        //     Console.WriteLine("What is the listing ID of the class you would like to delete?");
        //     int searchVal = int.Parse(Console.ReadLine());
        //     int foundClass = FindClass(searchVal);
        //     if(foundClass !=-1)
        //     {
        //         listings[foundClass].SetDelete(true);
        //         Save(listings);
        //         listings = GetAllClasses();
        //         Console.WriteLine("Trainer was deleted");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Listing not found");
        //     }
        //     return listings;
        // }

        public int FindCust(string searchVal2)
        {
            for(int i = 0; i < CustomerMemberships.GetCount(); i++)
            {
                if(cust[i].GetCustEmail() == searchVal2)
                {
                    return i;
                }
            }
            return -1;
        }
        public int FindSession(int searchVal) 
        {
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                if(transactions[i].GetID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public void PrintAllSessions() 
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listing[i].GetStatus() == false)
                {
                    Console.WriteLine(transactions[i].ToString());
                }
            }
        }
        public void Save(Transactions[] transactions) 
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Transactions.GetCount(); i++) 
            {
                outFile.WriteLine(transactions[i].ToFile());
            }
            outFile.Close();
        }

        public void Sort() 
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
        }

        public void SortById(Transactions[] transactions)
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

        }
        private void Swap(int x, int y)
        {
            Transactions temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;
        }
    }
}