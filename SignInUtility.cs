namespace mis_221_pa_5_Iveymcaleer
{
    public class SignInUtility
    {
        
        SignIn[] signIn;
        Listing[] listing;
        CustomerMemberships[] custMems;

        public SignInUtility(SignIn[] signIn, Listing[] listing, CustomerMemberships[] custMems)
        {
            this.signIn = signIn;
            this.listing = listing;
            this.custMems = custMems;
        }


        // add customer //
        public SignIn[] AddCustomer(SignIn[] signIn) 
        {
            Console.Clear();
            Console.WriteLine("Are you a new or returning customer?\nEnter '1' for new or Enter '2' for returning");
            int awnser = int.Parse(Console.ReadLine());
            if(awnser == 1){
                SignIn mySignIn = new SignIn();
                int signId = SignIn.GetCount();
                mySignIn.SetSignId(signId);
                Console.Clear();
                Console.WriteLine("Please enter your name");
                mySignIn.SetCustName(Console.ReadLine());
                Console.WriteLine("Please enter the date (00/00/0000)");
                mySignIn.SetDate(DateOnly.Parse(Console.ReadLine()));
                Console.WriteLine("Please enter your email address");
                mySignIn.SetCustEmail(Console.ReadLine()); 

                signIn[SignIn.GetCount()] = mySignIn;
                SignIn.IncCount();

                Save1(signIn);
                Console.WriteLine("New customers are given 1 free regular workout class!\n\nYou may choose which one you want once the list is shown.");
                System.Threading.Thread.Sleep(3000);
                GetAllSessions();
                PrintAllClasses(listing);
                System.Threading.Thread.Sleep(3000);
                
            }
            if(awnser == 2){
                SignBackIn(signIn);
            }
            GoodBye();
            return signIn;
        }


        // for add customer //
        public Listing[] GetAllSessions() 
        {
            // open
            StreamReader inFile = new StreamReader("listings.txt");
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
                int cost = int.Parse(temp[8]);
                int tID = int.Parse(temp[10]);
                listing[Listing.GetCount()] = new Listing(listId, temp[1], temp[2], month, day, year, temp[6], time, cost, bool.Parse(temp[9]), tID);
                Listing.IncCount();
                line = inFile.ReadLine(); // update read
            }

            inFile.Close();
            return listing;
        }

        // prints classes //
        private void PrintAllClasses(Listing[] listing)
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listing[i].GetStatus() == true)
                {
                    Console.WriteLine(listing[i].ToString());
                }
                else{
                    Console.WriteLine("No classes available");
                }
                
            }
        }


    // saves new customers to a file //
    public void Save1(SignIn[] signIn) 
    {
        StreamWriter newCust = new StreamWriter("newCustomers.txt"); 
        
        for (int i = 0; i < SignIn.GetCount(); i++) 
        {
            newCust.WriteLine(signIn[i].ToFile());
        }
        
        newCust.Close();   
    }


        // sign in for returning cutomers //
        public SignIn[] SignBackIn(SignIn[] signIn) 
        {
            Console.Clear();
            SignIn mySignIn = new SignIn();
            int signId = SignIn.GetCount();
            mySignIn.SetSignId(signId);
            Console.WriteLine("Please enter your email address");
            mySignIn.SetCustEmail(Console.ReadLine());
            Console.WriteLine("Enter your name");
            mySignIn.SetCustName(Console.ReadLine());
            Console.WriteLine("Enter the date (00/00/0000)");
            mySignIn.SetDate(DateOnly.Parse(Console.ReadLine()));
            Console.WriteLine("Thanks for signing in! Have a wonderful class!");
            signIn[SignIn.GetCount()] = mySignIn;
            SignIn.IncCount();
            Save2(signIn);

            return signIn;
        }


        // saves a file of returning cutomers //
        public void Save2(SignIn[] signIns) 
        {
            StreamWriter returnCust = new StreamWriter("returningCustomer.txt");

            for(int i = 0; i < SignIn.GetCount(); i++) 
            {
                returnCust.WriteLine(signIn[i].ToFile());
            }
            returnCust.Close();
        }

        // exiting method //
        public void GoodBye() 
        {
            Console.WriteLine("Exiting...");
        }

    }
}