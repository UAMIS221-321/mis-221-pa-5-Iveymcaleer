namespace mis_221_pa_5_Iveymcaleer
{
    public class CustomerMembershipsUtility
    {
        CustomerMemberships[] custMems;
        Listing[] listings;

        SignIn[] signIn;

        Membership[] mem;


        public CustomerMembershipsUtility(CustomerMemberships[] custMems, Listing[] listings, SignIn[] signIn, Membership[] mem)
        {
            this.custMems = custMems;
            this.listings = listings;
            this.signIn = signIn;
            this.mem = mem;
        }

        public Membership[] GetAllMemberships() 
        {
            // open
            StreamReader inFile = new StreamReader("memberships.txt");
            // process 
            Membership.SetCount(0);
            string line = inFile.ReadLine(); // priming read
            while(line != null) 
            { 
                string[] temp = line.Split('#');
                int listId = int.Parse(temp[0]);
                int month = int.Parse(temp[3]);
                int day = int.Parse(temp[4]);
                int year = int.Parse(temp[5]);
                TimeOnly time = TimeOnly.Parse(temp[7]);
                int cost = int.Parse(temp[5]);
                bool statusBooked = bool.Parse(temp[10]);
                listings[Listing.GetCount()] = new Listing(listId, temp[1], temp[2], month, day, year, temp[6], time, cost, statusBooked);
                Listing.IncCount();
                line = inFile.ReadLine(); // update read
            }

            inFile.Close();
            return mem;
        }

        public CustomerMemberships[] PurchaseMembership() 
        {
            PrintAllMemberships();
            Console.WriteLine("Above is a list of memberships you can purchase. Please enter the membership ID of the membership you would like to purchase."); 
            int searchVal = int.Parse(Console.ReadLine());
            int foundMem = FindMembership(searchVal);
            if(foundMem == -1){
            Console.WriteLine("Enter your email");
            string searchVal2 = (Console.ReadLine());
            int foundCust = FindCust(searchVal2);
            if(foundCust != -1)   
            {
                    Console.WriteLine("You will now be given a customer ID");
                    Random randomCustID = new Random();
                    int number = randomCustID.Next(1000); 
                    //custMems[CustomerMemberships.GetCount()].SetCustID(Random.randomCustID());
                    Console.WriteLine("Please enter your name");
                    custMems[CustomerMemberships.GetCount()].SetCustName(Console.ReadLine());
                    Console.WriteLine("Please enter your email again");
                    custMems[CustomerMemberships.GetCount()].SetCustEmail(Console.ReadLine());
                    Console.WriteLine("Now setting cost of membership...");
                    custMems[CustomerMemberships.GetCount()].SetCost(mem[foundMem].GetCost());
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Please enter the month (MM)");
                    string month = Console.ReadLine();
                    custMems[CustomerMemberships.GetCount()].SetMonth(int.Parse(month));
                    Console.WriteLine("Enter the day (DD)");
                    string day = Console.ReadLine();
                    custMems[CustomerMemberships.GetCount()].SetDay(int.Parse(day));
                    Console.WriteLine("Enter the year (YYYY)");
                    string year = Console.ReadLine();
                    custMems[CustomerMemberships.GetCount()].SetYear(int.Parse(month));
                    string date = month + "/" + day + "/" + year;
                    //custMems[CustomerMemberships.GetCount()].SetDate(date);
                    Save(custMems);
                    SortById();
                    Console.WriteLine("You have completed this transaction!");
                }
                else
                {
                    Console.WriteLine("That customer ID does not exist. Please check for your correct ID");
                }
            } if(foundMem == -1)
            {
                Console.WriteLine("Please enter valid membership ID");
                PurchaseMembership();
            }
            return custMems;
        }
              

        public int FindCust(string searchVal2)
        {
            for(int i = 0; i < CustomerMemberships.GetCount(); i++)
            {
                if(custMems[i].GetCustEmail() == searchVal2)
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindCustID(int searchVal3)
        {
            for(int i = 0; i < CustomerMemberships.GetCount(); i++)
            {
                if(custMems[i].GetCustID() == searchVal3)
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindMembership(int searchVal) 
        {
            for(int i = 0; i < Membership.GetCount(); i++)
            {
                if(mem[i].GetMemId() == searchVal) 
                {
                    return i;
                }
            }
            return -1;
        }

        public void Save(CustomerMemberships[] custMems) 
        {
            StreamWriter outFile = new StreamWriter("customermemberships.txt");

            for(int i = 0; i < CustomerMemberships.GetCount(); i++) 
            {
                outFile.WriteLine(custMems[i].ToFile());
            }
            outFile.Close();
        }

        public void SortById()
        {
            for(int i = 0; i < CustomerMemberships.GetCount(); i++)
            {
                int min = 0;
                for(int j = i + 1; j < CustomerMemberships.GetCount(); j++)
                {
                    if(custMems[j].GetCustID().CompareTo(custMems[min].GetCustID()) < 0)
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

        public void PrintAllMemberships()
        {
            for(int i = 0; i < Membership.GetCount(); i++)
            {
                Console.WriteLine(mem[i].ToString());
            }
        }

        public void Swap(int x, int y)
        {
            CustomerMemberships temp = custMems[x];
            custMems[x] = custMems[y];
            custMems[y] = temp;
        }

        public void GoodBye()
        {
            Console.WriteLine("Exiting ...");
        }

        public CustomerMemberships[] DeleteMembership()
        {
            Console.WriteLine("What is your customer ID?");
            int searchVal3 = int.Parse(Console.ReadLine());
            int foundCust = FindCustID(searchVal3);
            if(foundCust == -1)
            {
                custMems[foundCust].SetDelete(true);
                Save(custMems);
                Console.WriteLine("Your membership has been deleted.");
            }
            else
            {
                Console.WriteLine("Membership not found");
            }
            return custMems;
        }
    }
}