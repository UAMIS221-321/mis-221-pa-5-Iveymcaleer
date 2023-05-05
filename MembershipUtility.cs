namespace mis_221_pa_5_Iveymcaleer
{
    public class MembershipUtility
    {
        Membership[] mem;

        public MembershipUtility(Membership[] mem) 
        {
            this.mem = mem;
        }

        public Membership[] GetAllMemberships() 
        {
            // open
            StreamReader inFile = new StreamReader("memberships.txt");
            // process 
            Membership.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null) 
            { 
                string[] temp = line.Split('#');
                int memId = int.Parse(temp[0]);
                double hourAccess = double.Parse(temp[1]);
                double consultantion = double.Parse(temp[2]);
                double complimentaryClass = double.Parse(temp[5]);
                int cost = int.Parse(temp[6]);
                mem[Membership.GetCount()] = new Membership(memId, hourAccess, consultantion, temp[3], temp[4], complimentaryClass, cost);
                Membership.IncCount();
                line = inFile.ReadLine(); // update read
            }

            inFile.Close();
            //close
            return mem;
        }
        public Membership[] AddMembership() 
        {
            Console.Clear();
            Console.WriteLine("To add a new membership please do the following:");
            Console.WriteLine("Enter a membership Id");
            Membership membership = new Membership();
            membership.SetMemId(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter the amount of hour access the customers will have");
            membership.SetHourAccess(double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter how many & the amount of time in a free consulation for a member if provided");
            membership.SetConsultation(double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter if the membership will inculde complimentary kidCare");
            membership.SetKidCare(Console.ReadLine());
            Console.WriteLine("Enter if the membership will inculde premium class options");
            membership.SetPremiumClass(Console.ReadLine());
            Console.WriteLine("Enter if this membership will include a/many complimentary classes");
            membership.SetComplimentaryClass(double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter the cost of the membership");
            membership.SetCost(int.Parse(Console.ReadLine()));

            mem[Membership.GetCount()] = membership;
            Membership.IncCount();

            Save(mem);
            return mem;
        }

        public void Save(Membership[] mem) 
        {
            StreamWriter outFile = new StreamWriter("memberships.txt");

            for(int i = 0; i < Membership.GetCount(); i++) 
            {
                outFile.WriteLine(mem[i].ToFile());
            }
            outFile.Close();
        }

        public void PrintAllMemberships() 
        {
            for(int i = 0; i < Membership.GetCount(); i++)
            {
                Console.WriteLine(mem[i].ToString());
            }
        }
        public Membership[] UpdateMembership() {
            Console.Clear();
            PrintAllMemberships();
            Console.WriteLine("Please enter the membership ID of the membership you wish to edit"); 
            int searchVal = int.Parse(Console.ReadLine()); 
            int foundMem = FindMem(searchVal);

            if(foundMem != -1) 
            {
                Console.WriteLine("Enter the correct membership ID");
                mem[foundMem].SetMemId(int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the correct hour access");
                mem[foundMem].SetHourAccess(int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter if any & how many free consultations will be given");
                mem[foundMem].SetConsultation(double.Parse(Console.ReadLine()));
                Console.WriteLine("Enter if any complimentary kid care will be avaliable");
                mem[foundMem].SetKidCare(Console.ReadLine());
                Console.WriteLine("Enter if there will be access to premium classes");
                mem[foundMem].SetPremiumClass(Console.ReadLine());
                Console.WriteLine("Enter if there will be a complimentary class and if it will include a regular class, premium class, or both");
                mem[foundMem].SetComplimentaryClass(double.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the cost of this membership per month");
                mem[foundMem].SetCost(int.Parse(Console.ReadLine()));


                Save(mem);
            }
            else
            {
                Console.WriteLine("Membership not found");
            }
            return mem;
        }

        public Membership[] DeleteMembership()
        {
            GetAllMemberships();
            Console.WriteLine("What is the membership ID of the class you would like to delete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundMem = FindMem(searchVal);
            if(foundMem !=-1)
            {
                mem[foundMem].SetDelete(true);
                Save(mem);
                GetAllMemberships();
                Console.WriteLine("Membership was deleted");
            }
            else
            {
                Console.WriteLine("Membership not found");
            }
            return mem;
        }


        public int FindMem(int searchVal)
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

        public void SortById(Membership[] mem) 
        {
            int min = 0;
            for(int i = 0; i < Membership.GetCount() -1; i++) 
            {
                for(int j = i +1; j < Listing.GetCount(); j++) 
                {
                    if(mem[j].GetMemId().CompareTo(mem[min].GetMemId()) < 0) 
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
            Membership temp = mem[x];
            mem[x] = mem[y];
            mem[y] = temp;
        }

        
    }
}