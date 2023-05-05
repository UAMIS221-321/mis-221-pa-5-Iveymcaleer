using mis_221_pa_5_Iveymcaleer;

Listing[] listing = new Listing[100];
Listing.SetCount(0);
ListingUtility listingUtility = new ListingUtility(listing);

Transactions[] transactions = new Transactions[100];
Transactions.SetCount(0);
TransactionsUtility TransactionsUtility = new TransactionsUtility(transactions);

CustomerMemberships[] custMems = new CustomerMemberships[200];
Membership[] mem = new Membership[15];
SignIn[] signIn = new SignIn[1000];
CustomerMemberships.SetCount(0);
CustomerMembershipsUtility custMemsU = new CustomerMembershipsUtility(custMems, listing, signIn, mem);

TransactionsReport[] tReport = new TransactionsReport[100];
TransactionsReport.SetCount(0);
TransactionsReportUtility transactionsReportUtility = new TransactionsReportUtility(transactions, custMems);

Membership.SetCount(0);
MembershipUtility memU = new MembershipUtility(mem);


SignIn.SetCount(0);
SignInUtility signInUtility = new SignInUtility(signIn, listing, custMems);

ListingReport[] listingReports = new ListingReport[100];
ListingReport.SetCount(0);
ListingReportUtility listUtility = new ListingReportUtility(transactions, custMems);

Trainer[] trainer = new Trainer[50];
//Trainer.SetCount(0);
TrainerUtility train = new TrainerUtility(trainer);


Menu();


void Menu(){
    Console.WriteLine("\t\t\t\tWelcome to TLAC!\n\nAre you a ...");
    Console.WriteLine("Customer:\tEnter '1'\nTrainer:\tEnter '2'\nManager:\tEnter '3'\nExit:\t\tEnter '4'");
    int menuChoice = 0;
    while(menuChoice !=4)
    {
        try{
            menuChoice = int.Parse(Console.ReadLine());
            if(menuChoice < 1 || menuChoice > 4)
            {
                throw new Exception("Please enter a valid menu choice");
            }
        }
        catch(Exception e) 
        {
            Console.WriteLine(e.Message);
            menuChoice = 0;
        }
        finally
        {
            if(menuChoice == 1)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\tWould you like to...\n\nSign in:\t\tEnter '1'\n\nBook or cancel a session:\t\tEnter '2'\n\nSign up for or delete a membership:\tEnter '3'\n\nExit:\tEnter '4'");
                Console.WriteLine("\nNote: If you are a new customer, please sign in to get a free class instead of booking a session");
                int awnser = int.Parse(Console.ReadLine());
                if(awnser == 1)
                {
                    signInUtility.AddCustomer(signIn);
                    Menu();

                }
                if(awnser == 2)
                {
                    Console.WriteLine("Would you like to book or cancel a session?\nEnter '1' for book & Enter '2' for cancel");
                    int chooseS = int.Parse(Console.ReadLine());
                    if(chooseS == 1){  
                        listingUtility.GetAllClasses();
                        TransactionsUtility.BookSession(listing);
                        Menu();
                    }
                    if(chooseS == 2)
                    {
                        TransactionsUtility.CancelTransaction(listing);
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid menu choice");
                        Menu();
                    }
                }
                if(awnser == 3)
                {
                    custMemsU.PurchaseMembership();
                    Menu();
                }
                if(awnser == 4)
                {
                    listingUtility.GoodBye();
                    Menu();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid menu choice");
                    Menu();
                }
                
            }
            if(menuChoice == 2)
            {
                Console.Clear();
                Console.WriteLine("Would you like to manage the trainer data or the listing data as a trainer?\n\nTrainer data:\tEnter '1'\nListing data:\tEnter '2'\nExit:\tEnter '3'");
                int whichOne = int.Parse(Console.ReadLine());
                if(whichOne == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Add yourself as a trainer:\tEnter '1'\n\nEdit yourself as a trainer:\tEnter '2'\n\nDelete yourself as a trainer:\tEnter '3'\n\nExit:\tEnter '4'");
                    int choose = int.Parse(Console.ReadLine());
                    if(choose == 1)
                    {
                        Console.Clear();
                        Trainer trainerNew = train.AddTrainer();
                        train.Save(trainer);
                        Menu();
                    }
                    if(choose == 2)
                    {
                        Console.Clear();
                        trainer = train.GetAllTrainers();
                        train.PrintAllTrainers();
                        train.UpdateTrainer(trainer);
                        train.Save(trainer);
                        Menu();
                    }
                    if(choose == 3)
                    {
                        Console.Clear();
                        train.GetAllTrainers();
                        train.PrintAllTrainers();
                        Console.WriteLine();
                        Console.WriteLine("What is the ID of the trainer you would like to remove?");
                        int tId = int.Parse(Console.ReadLine());
                        train.DeleteTrainer(tId);
                        trainer = train.GetAllTrainers();
                        Console.Clear();
                        Menu();
                    }
                    if(choose == 4)
                    {
                        listingUtility.GoodBye();
                        Menu();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid menu choice");
                        Menu();
                    }
                }
                else if(whichOne == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Add class:\tEnter '1'\n\nEdit class:\tEnter '2'\n\nDelete class:\tEnter '3'\n\nExit:\tEnter '4'");
                    int chooseL = int.Parse(Console.ReadLine());
                    if(chooseL == 1)
                    {
                        listing = listingUtility.GetAllClasses();
                        listing = listingUtility.AddClass(listing);
                        Menu();
                    }
                    if(chooseL == 2)
                    {
                        listing = listingUtility.GetAllClasses();
                        listing = listingUtility.UpdateClass(listing);
                        Menu();
                    }
                    if(chooseL == 3)
                    {
                        Console.Clear();
                        listingUtility.GetAllClasses();
                        listingUtility.PrintAllListings();
                        Console.WriteLine();
                        Console.WriteLine("What is the ID of the listing you would like to remove?");
                        int listId = int.Parse(Console.ReadLine());
                        listingUtility.DeleteClass(listId);
                        listingUtility.GetAllClasses();
                        Console.Clear();
                        Menu();
                    }
                    if(chooseL == 4) 
                    {
                        listingUtility.GoodBye();
                        Menu();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid menu choice");
                        Menu();
                    }
                }
            }
            if(menuChoice == 3)
            {
                Console.Clear();
                Console.WriteLine("Would you like to manage membership data or run reports?\n\nManage Membership Data:\tEnter '1'\nRun Reports:\tEnter '2'\nExit:\tEnter '3' ");
                int chooseR = int.Parse(Console.ReadLine());
                if(chooseR == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Add membership:\tEnter '1'\n\nEdit membership:\tEnter '2'\n\nDelete membership:\tEnter '3'\n\nExit:\tEnter '4'");
                    int memChoice = int.Parse(Console.ReadLine());
                    if(memChoice == 1)
                    {
                        memU.AddMembership();
                        Menu();
                    }
                    if(memChoice == 2)
                    {
                        memU.UpdateMembership();
                        Menu();
                    }
                    if(memChoice == 3)
                    {
                        memU.DeleteMembership();
                        Menu();
                    }
                    if(memChoice == 4)
                    {
                        listingUtility.GoodBye();
                        Menu();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid menu choice");
                        Menu();
                    }

                }
                if(chooseR == 2)
                {
                    Console.Clear();
                    Console.WriteLine("What reports would you like to run?\n\nIndividual Customer Sessions\tEnter: '1'\nIndividual Customer Memberships\tEnter: '2'\n\nHistorical Customer Sessions\tEnter: '3'\nHistorical Revenue Report\tEnter: '4'\n\nExit\tEnter '5'");
                    int chooseH = int.Parse(Console.ReadLine());
                    if(chooseH == 1)
                    {
                        listUtility.CustomerSessionsReport(transactions);
                        Menu();
                    }
                    if(chooseH == 2)
                    {
                        listUtility.CustByMembership(custMems);
                        Menu();
                    }
                    if(chooseH == 3)
                    {
                        //listUtility.CustomersByDate();
                        Menu();
                    }
                    if(chooseH == 4)
                    {
                        transactions = TransactionsUtility.GetAllTransactions();
                        transactionsReportUtility.RevenueReport(transactions);
                        Menu();
                    }
                    if(chooseH == 5)
                    {
                        listingUtility.GoodBye();
                        Menu();
                        Environment.Exit(0);
                    }
                    else{
                        Console.WriteLine("Invalid Menu Choice");
                        Menu();
                    }

                }
            }if(menuChoice == 4)
            {
                listingUtility.GoodBye();
                Environment.Exit(0);
            }
        }
    }
}


