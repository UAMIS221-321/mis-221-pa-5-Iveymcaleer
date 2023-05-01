using mis_221_pa_5_Iveymcaleer;
Listing[] listing = new Listing[100];
Listing.SetCount(0);
ListingUtility listingUtility = new ListingUtility(listing);
Transactions[] transactions = new Transactions[100];
Transactions.SetCount(0);
TransactionsUtility TransactionsUtility = new TransactionsUtility(transactions);
TransactionsReportUtility transactionsReportUtility = new TransactionsReportUtility(transactions);

Menu();
// things to do: 
// add save to file
// finish menu system 
// finish report 
// change status 

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
                    SignIn[] signIn = new SignIn[150];
                    CustomerMemberships[] cust = new CustomerMemberships[200];
                    SignInUtility checkIn = new SignInUtility(signIn, listing, cust);
                    checkIn.Welcome(); 
                }
                if(awnser == 2)
                {
                    Console.WriteLine("Would you like to book or cancel a session?\nEnter '1' for book & Enter '2' for cancel");
                    int chooseS = int.Parse(Console.ReadLine());
                    if(chooseS == 1){
                    Transactions[] transations = new Transactions[100];
                    CustomerMemberships[] cust = new CustomerMemberships[100];
                    TransactionsUtility transaction = new TransactionsUtility(transations, listing, cust); 
                    transaction.GetAllSessions(listing);
                    transaction.BookSession(); 
                    }
                    if(chooseS == 2)
                    {

                    }
                    else
                    {
                        Console.WriteLine("Please enter valid menu choice");
                    }
                }
                if(awnser == 3)
                {
                    CustomerMemberships[] custMems = new CustomerMemberships[200];
                    SignIn[] signIn = new SignIn[150];
                    Membership[] mem = new Membership[10];
                    CustomerMembershipsUtility custmem = new CustomerMembershipsUtility(custMems, listing, signIn, mem);
                    custmem.PurchaseMembership();
                }
                if(awnser == 4)
                {
                    SignIn[] checkIn = new SignIn[200];
                    Listing[] listings = new Listing[150];
                    CustomerMemberships[] cust = new CustomerMemberships[200];
                    SignInUtility signIn = new SignInUtility(checkIn, listings, cust);
                    signIn.GoodBye();
                }
                else
                {
                    Console.WriteLine("Invalid menu choice");
                    SignIn[] checkIn = new SignIn[200];
                    Listing[] listings = new Listing[150];
                    CustomerMemberships[] cust = new CustomerMemberships[200];
                    SignInUtility signIn = new SignInUtility(checkIn, listings, cust);
                    signIn.GoodBye();
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
                        Trainer[] trainerss = new Trainer[50];
                        Trainer.SetCount(0);
                        TrainerUtility train = new TrainerUtility(trainerss);
                        trainerss = train.AddTrainer();
                        Menu();
                    }
                    if(choose == 2)
                    {
                        Trainer[] trainerss = new Trainer[50];
                        Trainer.SetCount(0);
                        TrainerUtility train = new TrainerUtility(trainerss);
                        trainerss = train.GetAllTrainers();
                        trainerss = train.UpdateTrainer();
                        Menu();
                    }
                    if(choose == 3)
                    {
                        Trainer[] trainerss = new Trainer[50];
                        Trainer.SetCount(0);
                        TrainerUtility train = new TrainerUtility(trainerss);
                        trainerss = train.GetAllTrainers();
                        trainerss = train.DeleteTrainer();
                        Menu();
                    }
                    if(choose == 4)
                    {
                        Trainer[] trainerss = new Trainer[50];
                        TrainerUtility train = new TrainerUtility(trainerss);
                        train.GoodByeTrainer();
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid menu choice");
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
                        listing = listingUtility.AddClass();
                        Menu();
                    }
                    if(chooseL == 2)
                    {
                        listing = listingUtility.GetAllClasses();
                        listing = listingUtility.UpdateClass();
                        Menu();
                    }
                    if(chooseL == 3)
                    {
                        listing = listingUtility.GetAllClasses();
                        listing = listingUtility.DeleteClass();
                        Menu();
                    }
                    if(chooseL == 4) 
                    {
                        listingUtility.GoodByeListing();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid menu choice");
                        Menu();
                    }
                }
            }
            if(menuChoice == 3)
            {
                Console.WriteLine("Would you like to manage membership data or run reports?\n\nManage Membership Data:\tEnter '1'\nRun Reports:\tEnter '2'\nExit:\tEnter '3' ");
                int chooseR = int.Parse(Console.ReadLine());
                if(chooseR == 1)
                {
                    Console.WriteLine("Add membership:\tEnter '1'\n\nEdit membership:\tEnter '2'\n\nDelete membership:\tEnter '3'\n\nExit:\tEnter '4'");
                    int mem = int.Parse(Console.ReadLine());
                    if(mem == 1)
                    {
                        
                    }
                }
                transactions = TransactionsUtility.GetAllTransactions();
                transactionsReportUtility.SortByYear(transactions);
                transactionsReportUtility.PrintAllTransactions();
                Menu();
            }
        }
    }
}


