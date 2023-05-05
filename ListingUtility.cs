namespace mis_221_pa_5_Iveymcaleer
{
    public class ListingUtility
    {
        public Listing[] listing;

        public ListingUtility(Listing[] listing) 
        {
            this.listing = listing;
        }

        // populates classes for listing //
        public Listing[] GetAllClasses() 
        {
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

        // add a class //
        public Listing[] AddClass(Listing[] listings) 
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

        // Saves an added, edited, or deleted class //
        public void Save(Listing[] listings) 
        {
            StreamWriter outFile = new StreamWriter("listings.txt");
            for(int i = 0; i < Listing.GetCount(); i++) 
            {
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }

        // edit a trainer
        public Listing[] UpdateClass(Listing[] listings) {
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
                Console.WriteLine("Enter the correct time (00:00 AM/PM)");
                listings[foundListing].SetTime(TimeOnly.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the correct cost");
                listings[foundListing].SetCost(int.Parse(Console.ReadLine()));
                Save(listings);
                Console.WriteLine("Class added!");
            }
            else
            {
                Console.WriteLine("Listing not found");
            }
            return listings;
        }

        // deletes a class //
        public void DeleteClass(int listId)
        {
            GetAllClasses();
            PrintAllListings();
            string file = "listings.txt";
            List<string> linesOfFile = File.ReadAllLines(file).ToList();

            for (int i = 0; i < linesOfFile.Count; i++)
            {
                string[] temp = linesOfFile[i].Split('#');
                if (int.Parse(temp[0]) == listId)
                {
                    linesOfFile.RemoveAt(i);
                    break;
                }
            }

            //SortById(file);

            File.WriteAllLines(file, linesOfFile);
            Console.WriteLine("Deleted.");
        }

        // finds a class //
        public int FindClass(int searchVal)
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


        public void SortById(string file)
        {
            int min = listing.Length;
            for (int i = 0; i < min - 1; i++)
            {
                for (int j = 0; j < min - 1; j++)
                {
                    if (listing[j].GetListId() > listing[j+1].GetListId())
                    {
                        Listing temp = listing[j];
                        listing[j] = listing[j+1];
                        listing[j+1] = temp;
                    }
                }
            }
        }


        // Prints all listings while spots are avaliable //
        public Listing[] PrintAllListings()
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listing[i].GetStatus() == true)
                {
                Console.WriteLine(listing[i].ToString());
                }
            }
            return listing;
        }

        // Exiting method //
        public void GoodBye()
        {
            Console.WriteLine("Exiting...");
        }

    }
}