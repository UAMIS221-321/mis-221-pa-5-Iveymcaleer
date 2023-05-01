namespace mis_221_pa_5_Iveymcaleer
{
    public class ListingUtility
    {
        Listing[] listings;

        public ListingUtility(Listing[] listings) 
        {
            this.listings = listings;
        }

        public Listing[] GetAllClasses () 
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
                listings[Listing.GetCount()] = new Listing(listId, temp[1], temp[2], month, day, year, temp[6], time, cost, statusBooked);
                Listing.IncCount();
                line = inFile.ReadLine(); // update read
            }

            inFile.Close();
            return listings;
        }
        // add a class
        public Listing[] AddClass() 
        {
            Console.WriteLine("To add a new class please do the following:");
            Listing listing = new Listing();
            int ListID = Listing.GetCount();
            listing.SetListId(ListID);
            Console.WriteLine("Enter the trainer's name");
            listing.SetTName(Console.ReadLine());
            Console.WriteLine("Enter the types of classes the trainer can teach");
            listing.SetClassType(Console.ReadLine());
            Console.WriteLine("Enter the month (MM)");
            string month = Console.ReadLine();
            listing.SetMonth(int.Parse(month));
            Console.WriteLine("Enter the day (DD)");
            string day = Console.ReadLine();
            listing.SetDay(int.Parse(day));
            Console.WriteLine("Enter the year (YYYY)");
            string year = Console.ReadLine();
            listing.SetYear(int.Parse(year));
            string date = month + "/" + day + "/" + year;
            listing.SetDate(date);
            Console.WriteLine("Enter the time (00:00 AM/PM)");
            listing.SetTime(TimeOnly.Parse(Console.ReadLine()));
            Console.WriteLine("Enter the cost");
            listing.SetCost(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter the status (enter 'true')");
            listing.SetStatus(bool.Parse(Console.ReadLine()));
            listings[Listing.GetCount()] = listing;
            Listing.IncCount();
            Save(listings);
            return listings;
        }

        public void Save(Listing[] listings) 
        {
            StreamWriter outFile = new StreamWriter("listing.txt");
            for(int i = 0; i < Listing.GetCount(); i++) 
            {
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }

        // edit a trainer
        public Listing[] UpdateClass() {
            PrintAllListings();
            Console.WriteLine("Please enter the listing ID for the class you wish to edit"); 
            int searchVal = int.Parse(Console.ReadLine()); 
            int foundListing = FindClass(searchVal);

            if(foundListing != -1) 
            {
                Console.WriteLine("Enter the correct listing ID");
                listings[foundListing].SetListId(int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the correct trainer name");
                listings[foundListing].SetTName(Console.ReadLine());
                Console.WriteLine("Enter the type of classes you are able to train");
                listings[foundListing].SetClassType(Console.ReadLine());
                Console.WriteLine("Enter the correct month (MM)");
                string month = Console.ReadLine();
                listings[foundListing].SetMonth(int.Parse(month));
                Console.WriteLine("Enter the day (DD)");
                string day = Console.ReadLine();
                listings[foundListing].SetDay(int.Parse(day));
                Console.WriteLine("Enter the year (YYYY)");
                string year = Console.ReadLine();
                listings[foundListing].SetYear(int.Parse(year));
                string date = month + "/" + day + "/" + year;
                listings[foundListing].SetDate(date);
                Console.WriteLine("Enter the correct time (00:00 AM/PM");
                listings[foundListing].SetTime(TimeOnly.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the correct cost");
                listings[foundListing].SetCost(int.Parse(Console.ReadLine()));
                Save(listings);
                SortById();
                Console.WriteLine("Class added!");
            }
            else
            {
                Console.WriteLine("Listing not found");
            }
            return listings;
        }

        public Listing[] DeleteClass()
        {
            listings = GetAllClasses();
            Console.WriteLine("What is the listing ID of the class you would like to delete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundClass = FindClass(searchVal);
            if(foundClass !=-1)
            {
                listings[foundClass].SetDelete(true);
                Save(listings);
                listings = GetAllClasses();
                Console.WriteLine("Trainer was deleted");
            }
            else
            {
                Console.WriteLine("Listing not found");
            }
            return listings;
        }

        public int FindClass(int searchVal)
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listings[i].GetListId() == searchVal) 
                {
                    return i;
                }
            }
            return -1;
        }

        public void SortById() 
        {
            int min = 0;
            for(int i = 0; i < Listing.GetCount() -1; i++) 
            {
                for(int j = i +1; j < Listing.GetCount(); j++) 
                {
                    if(listings[j].GetListId().CompareTo(listings[min].GetListId()) < 0) 
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

        public void Swap(int x, int y) 
        {
            Listing temp = listings[x];
            listings[x] = listings[y];
            listings[y] = temp;
        }

        private void PrintAllListings()
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                Console.WriteLine(listings[i].ToString());
            }
        }

        public void GoodByeListing()
        {
            Console.WriteLine("Exiting...");
        }
    }
}