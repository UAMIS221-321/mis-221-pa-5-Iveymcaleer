namespace mis_221_pa_5_Iveymcaleer
{
    public class CustomerMembershipsUtility
    {
        CustomerMemberships[] custMems;
        Listing[] listing;

        SignIn[] signIn;

        Membership[] mem;

        int maxSize = 10;

        // this class gives customers the option to buy a membership, edit it, or delete it //
        public CustomerMembershipsUtility(CustomerMemberships[] custMems, Listing[] listing, SignIn[] signIn, Membership[] mem)
        {
            this.custMems = custMems;
            this.listing = listing;
            this.signIn = signIn;
            this.mem = mem;
        }

        // populates array of memberships //
        public Membership[] GetAllMemberships(Membership[] mem) 
        {
            mem = new Membership[maxSize];
            Membership.SetCount(0);
            int memId = Membership.GetCount(); 
            // open
            StreamReader inFile = new StreamReader("memberships.txt");
            // process 
            string line = inFile.ReadLine();
            while(line != null) 
            { 
                string[] temp = line.Split('#');
                mem[Membership.GetCount()] = new Membership(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4], temp[5], int.Parse(temp[6]));
                Membership.IncCount();
                line = inFile.ReadLine(); // update read
            }
            inFile.Close();
            return mem;
        }

        // lets customers purchase a membership //
        public CustomerMemberships[] PurchaseMembership() 
        {
            PrintAllMemberships();
            Console.WriteLine("Above is a list of memberships you can purchase."); 
                    Console.WriteLine("You will now be given a customer ID");
                    CustomerMemberships cust = new CustomerMemberships();
                    int cusId = Listing.GetCount();
                    cust.SetCustID(cusId);
                    Console.WriteLine("Please enter your name");
                    custMems[CustomerMemberships.GetCount()].SetCustName(Console.ReadLine());
                    Console.WriteLine("Please enter your email again");
                    custMems[CustomerMemberships.GetCount()].SetCustEmail(Console.ReadLine());
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
                    custMems[CustomerMemberships.GetCount()].SetDate(date);
                    Console.WriteLine("Please enter the number of your membership");
                    int searchVal = int.Parse(Console.ReadLine());
                    int foundMembership = FindMembership(searchVal, mem, custMems);
                    if(foundMembership !=-1)
                    {
                        int membershipCost = mem[foundMembership].GetCost();
                        custMems[CustomerMemberships.GetCount()].SetCost(membershipCost);
                        custMems[CustomerMemberships.GetCount()] = cust;
                        CustomerMemberships.IncCount();
                        Save(custMems);
                        Console.WriteLine("You have completed this transaction!");
                    }
                    else{
                        Console.WriteLine("Could not find cost of membership. Please enter valid membership ID");
                    }
            return custMems;
        }

        // lets customers update their membership //
        public CustomerMemberships[] UpdateCustMembership(CustomerMemberships[] custMems) {
                    Console.WriteLine("What is your customer ID");
                    int searchVal = int.Parse(Console.ReadLine()); 
                    int foundCustId = FindID(searchVal, custMems);
                    if(foundCustId != -1)
                    {
                        Console.Clear();
                        Console.WriteLine("Giving you a new customer ID...");
                        CustomerMemberships cust = new CustomerMemberships();
                        int cusId = Listing.GetCount();
                        cust.SetCustID(cusId);
                        Console.WriteLine("Please enter your name");
                        custMems[CustomerMemberships.GetCount()].SetCustName(Console.ReadLine());
                        Console.WriteLine("Please enter your email again");
                        custMems[CustomerMemberships.GetCount()].SetCustEmail(Console.ReadLine());
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
                        custMems[CustomerMemberships.GetCount()].SetDate(date);
                        Console.WriteLine("if you would like to edit your type of memberhsip, please delete it then purchase new one");
                        Console.WriteLine("Would you like to do this?\nEnter '1' for for yes & Enter '2' for no");
                        int awnser = int.Parse(Console.ReadLine());
                        if(awnser == 1)
                        {
                            DeleteMembership(cusId);
                            PurchaseMembership();
                        }
                        else{
                            custMems[CustomerMemberships.GetCount()] = cust;
                            CustomerMemberships.IncCount();
                            Save(custMems);
                            Console.WriteLine("Edit complete");
                        }     
                    }else
                    {
                        Console.WriteLine("Customer ID not found");
                    }
                    
            return custMems;
        }

        // deletes customer memberships //
        public void DeleteMembership(int custId)
        {
            string file = "customermemberships.txt";
            List<string> linesOfFile = File.ReadAllLines(file).ToList();

            for (int i = 0; i < linesOfFile.Count; i++)
            {
                string[] fields = linesOfFile[i].Split('#');
                if (int.Parse(fields[0]) == custId)
                {
                    linesOfFile.RemoveAt(i);
                    break;
                }
            }

            SortById(custMems);

            File.WriteAllLines(file, linesOfFile);
        }

        // finds customer id //
        public int FindID(int searchVal3, CustomerMemberships[] custMems)
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

        // finds membership entered by customer and gets cost to return it and set for customer membership //
        public int FindMembership(int searchVal2, Membership[] mem, CustomerMemberships[] custMems) 
        {
            for (int i = 0; i < Membership.GetCount(); i++)
            {          
                if (mem[i].GetMemId() == searchVal2)
                {              
                    return mem[i].GetCost();
                }
            }
            return -1;
        }

        // save methods to file //
        public void Save(CustomerMemberships[] custMems) 
        {
            StreamWriter outFile = new StreamWriter("customermemberships.txt");

            for(int i = 0; i < CustomerMemberships.GetCount(); i++) 
            {
                outFile.WriteLine(custMems[i].ToFile());
            }
            outFile.Close();
        }

        // sorts file by Cust Id //
        public CustomerMemberships[] SortById(CustomerMemberships[] custMems)
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
            return custMems;
        }

        // prints all memberships available //
        public void PrintAllMemberships()
        {
            for(int i = 0; i < Membership.GetCount(); i++)
            {
                Console.WriteLine(mem[i].ToString());
            }
        }

        // swaps ids for sortbyid method //
        public void Swap(int x, int y)
        {
            CustomerMemberships temp = custMems[x];
            custMems[x] = custMems[y];
            custMems[y] = temp;
        }


    }
}