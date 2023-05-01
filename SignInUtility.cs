namespace mis_221_pa_5_Iveymcaleer
{
    public class SignInUtility
    {
        
        SignIn[] signIn;
        Listing[] listing;

        CustomerMemberships[] cust;

        public SignInUtility(SignIn[] signIn, Listing[] listing, CustomerMemberships[] cust)
        {
            this.signIn = signIn;
            this.listing = listing;
            this.cust = cust;
        }

        public void Welcome() 
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tWe hope you are ready to train like a champion today :)\n\n");
            Console.WriteLine("\t\t\t\tAre you a new customer or are you a returning one?\n\t\t\t\t   Enter '1' for new & Enter '2' for returning");
            int userInput = int.Parse(Console.ReadLine());
            while(userInput != 3) 
            {
                if(userInput == 1)
                {
                    GetAllClasses();
                    AddCustomer();
                    GoodBye();
                }
                if(userInput == 2)
                {
                   WelcomeBack(); 
                }
                else
                {
                    Console.WriteLine("Invalid Menu Choice");
                }
            }
            
        }


        public SignIn[] AddCustomer() 
        {
            Console.Clear();
            Console.WriteLine("New customers are given 1 free regular workout class!\n\nYou may choose which one you want once the list is shown.");
            System.Threading.Thread.Sleep(4000);
            PrintAllClasses();
            Console.WriteLine("Please enter your email to earn a free class");
            string searchVal = (Console.ReadLine());
            int findCust = FoundCust(searchVal);
            if(findCust != -1)
            {
                SignIn mySignIn = new SignIn();
                Console.WriteLine("Please enter your name");
                mySignIn.SetCustName(Console.ReadLine());
                Console.WriteLine("Please enter the date");
                mySignIn.SetDate(DateOnly.Parse(Console.ReadLine()));
                Console.WriteLine("Please enter the time");
                mySignIn.SetTime(TimeOnly.Parse(Console.ReadLine()));
                Console.WriteLine("Please enter your email address again");
                mySignIn.SetCustEmail(Console.ReadLine()); 

                signIn[SignIn.GetCount()] = mySignIn;
                SignIn.IncCount();

                Save1();

            }
            else
            {
                Console.WriteLine("Your email is already regestered in a membership.\nIf you believe this is not true enter '1'\tor\t enter '2' for check in as a returning customer");
                int userInput = int.Parse(Console.ReadLine());
                if(userInput == 1)
                {
                    Console.WriteLine("To contact manager for any concerns about your membership...\nEmail: TLACmanager@tlac.com\tCell: (205) 432-5578");
                }
                if(userInput == 2)
                {
                    SignBackIn(signIn);
                }
                else
                {
                    Console.WriteLine("Please enter valid menu choice");
                }

            }
            return signIn;
        }

        public int FoundCust(string searchVal)
        {
            for(int i = 0; i < CustomerMemberships.GetCount(); i++)
            {
                if(cust[i].GetCustEmail() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }


        public Listing[] GetAllClasses() 
        {
            // open
            StreamReader inFile = new StreamReader("listing.txt");
            // process 
            Listing.SetCount(0);
            string line = inFile.ReadLine();
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
                listing[Listing.GetCount()] = new Listing(listId, temp[1], temp[2], month, day, year, temp[6], time, cost, statusBooked);
                Listing.IncCount();
                line = inFile.ReadLine(); // update read
            }

            inFile.Close();
            return listing;
        }

        private void PrintAllClasses()
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                Console.WriteLine(listing[i].ToString());
            }
        }

        public void Save1() 
        {
            StreamWriter newCust = new StreamWriter("newCustomers.txt");

            for(int i = 0; i < SignIn.GetCount(); i++) 
            {
                newCust.WriteLine(signIn[i].ToFile1());
                Console.WriteLine("Have a wonderful class!");
                GoodBye();
            }
            newCust.Close();
            
        }

        public void WelcomeBack() 
        {
            Console.WriteLine("Welcome back!\nWe hope you are ready to train like a champion today!");
            Console.WriteLine("\t\t\t\tLet's get you signed in!");
            SignBackIn(signIn);

        }

        public SignIn[] SignBackIn(SignIn[] signIn) 
        {
            Console.WriteLine("Please enter your name to sign in");
            SignIn mySignIn = new SignIn();
            mySignIn.SetCustName(Console.ReadLine());
            Console.WriteLine("Please enter your email address");
            string searchVal = (Console.ReadLine());
            mySignIn.SetCustEmail(Console.ReadLine()); 
            int findCust = FoundCust(searchVal);
            if(findCust != -1)
            {
                Console.WriteLine("Thanks for signing in! Have a wonderful class!");
            }
            else
            {
                Console.WriteLine("Our data records have not found that email regestered for membership.\n\n");
                Console.WriteLine("For further assitance, please reach out to the manager.\nEmail: TLACmanager@tlac.com\tCell: (205) 432-5578");
            }
            signIn[SignIn.GetCount()] = mySignIn;
            SignIn.IncCount();
            Save2(listing);

            return signIn;
        }

        public int FindSession(string searchVal) 
        {
            for(int i = 0; i < CustomerMemberships.GetCount(); i++)
            {
                if(cust[i].GetCustEmail() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }
         public void Save2(Listing[] listing) 
        {
            StreamWriter returnCust = new StreamWriter("returningCustomer.txt");

            for(int i = 0; i < SignIn.GetCount(); i++) 
            {
                returnCust.WriteLine(signIn[i].ToFile1());
            }
            returnCust.Close();
        }

        public void SortByDate()
        {
            for(int i = 0; i < SignIn.GetCount(); i++)
            {
                int min = 0;
                for(int j = i + 1; j < SignIn.GetCount(); j++)
                {
                    if(signIn[j].GetDate().CompareTo(signIn[min].GetMemId()) < 0)
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(ref min, ref i);
                }
            }
        }

        public void Swap(ref int x, ref int y)
        {
            SignIn temp = signIn[x];
            signIn[x] = signIn[y];
            signIn[y] = temp;
        }


        public void GoodBye()
        {
            Console.WriteLine("Exiting...");
        }
    }
}