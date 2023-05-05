namespace mis_221_pa_5_Iveymcaleer
{
    public class TrainerUtility
    {
        private Trainer[] trainer;

        private Trainer[] updatedtrainer;

        int maxSize = 1000;

        public TrainerUtility(Trainer[] trainer) 
        {
            this.trainer = trainer;
        }

        // all trainers on file //
        public Trainer[] GetAllTrainers() 
        {
            trainer = new Trainer[maxSize];
            Trainer.SetCount(0);
            int tID = Trainer.GetCount(); 
            // open
            StreamReader inFile = new StreamReader("trainers.txt");
            // process 
            string line = inFile.ReadLine();
            while(line != null) 
            { 
                string[] temp = line.Split('#');
                trainer[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4]);
                Trainer.IncCount();
                line = inFile.ReadLine(); // update read
            }
            inFile.Close();
            return trainer;
        }

        // add a trainer //
        public Trainer AddTrainer() 
        {
            Console.Clear();
            Trainer myTrainer = new Trainer();
            int trainerID = Trainer.GetCount() +1; 
            myTrainer.SetID(trainerID);
            Console.WriteLine("To add a new trainer please do the following:");
            Console.WriteLine("Enter the trainer's name");
            myTrainer.SetName(Console.ReadLine());
            Console.WriteLine("Enter the types of classes the trainer can teach");
            myTrainer.SetClassType(Console.ReadLine());
            Console.WriteLine("Enter the trainer's mail address");
            myTrainer.SetMAddress(Console.ReadLine());
            Console.WriteLine("Enter the trainer's email address");
            myTrainer.SetEAddress(Console.ReadLine());

            trainer[Trainer.GetCount()] = myTrainer;
            Trainer.IncCount();

            return myTrainer;
        }

        // saves a trainer //
        public void Save(Trainer[] trainer) 
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for(int i = 0; i < Trainer.GetCount(); i++) 
            {
                outFile.WriteLine(trainer[i].ToFile());
            }
            outFile.Close();
        }

        // edit a trainer //
        public Trainer[] UpdateTrainer(Trainer[] trainer) {  
            GetAllTrainers();
            Console.WriteLine("Please enter the trainer's ID for the trainer you wish to edit"); 
            int searchVal = int.Parse(Console.ReadLine()); 
            int foundTrainer = FindTrainer(searchVal, trainer);

            if(foundTrainer != -1) 
            {
                Console.WriteLine("Enter the correct trainer ID");
                trainer[foundTrainer].SetID(int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the correct trainer name");
                trainer[foundTrainer].SetName(Console.ReadLine());
                Console.WriteLine("Enter the type of classes you are able to train");
                trainer[foundTrainer].SetClassType(Console.ReadLine());
                Console.WriteLine("Enter the correct trainer mailing address");
                trainer[foundTrainer].SetMAddress(Console.ReadLine());
                Console.WriteLine("Enter the correct trainer email address");
                trainer[foundTrainer].SetEAddress(Console.ReadLine());

                Save(trainer);
                Console.WriteLine("Trainer added!");
                
            }
            else
            {
                Console.WriteLine("Trainer not found");
            }
            return trainer;
        }

        public void DeleteTrainer(int trainerID)
        {
            string file = "trainers.txt";
            List<string> linesOfFile = File.ReadAllLines(file).ToList();

            for (int i = 0; i < linesOfFile.Count; i++)
            {
                string[] fields = linesOfFile[i].Split('#');
                if (int.Parse(fields[0]) == trainerID)
                {
                    linesOfFile.RemoveAt(i);
                    break;
                }
            }

            SortById(file);

            File.WriteAllLines(file, linesOfFile);
        }


        // find a trainer's ID //
        public int FindTrainer(int searchVal, Trainer[] trainer)   
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                Console.WriteLine(trainer[i].GetID());
                if(trainer[i].GetID() == searchVal) 
                {
                    return i;
                }
            }
            return -1;
        }

        // sorts a trainer by their ID //
        public void SortById(string file) 
        {
            int min = 0;
            for(int i = 0; i < Trainer.GetCount() -1; i++) 
            {
                for(int j = i +1; j < Trainer.GetCount(); j++) 
                {
                    if(trainer[j].GetName().CompareTo(trainer[min].GetName()) < 0) 
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

        // Swap method for SortById //
        public void Swap(int x, int y) 
        {
            Trainer temp = trainer[x];
            trainer[x] = trainer[y];
            trainer[y] = temp;
        }

        // prints all trainers //
        public Trainer[] PrintAllTrainers()
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                Console.WriteLine(trainer[i].ToString());
            }
            return trainer;
        }


  
    }
}