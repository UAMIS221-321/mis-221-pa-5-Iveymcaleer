namespace mis_221_pa_5_Iveymcaleer
{
    public class TrainerUtility
    {
        Trainer[] trainer;

        public TrainerUtility(Trainer[] trainer) 
        {
            this.trainer = trainer;
        }

        // all trainers on file
        public Trainer[] GetAllTrainers() 
        {
            // open
            StreamReader inFile = new StreamReader("trainers.txt");
            // process 
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null) 
            { 
                string[] temp = line.Split('#');
                int tId = int.Parse(temp[0]);
                bool delete = bool.Parse(temp[5]);
                trainer[Trainer.GetCount()] = new Trainer(tId, temp[1], temp[2], temp[3], temp[4], delete);
                Trainer.IncCount();
                line = inFile.ReadLine(); // update read
            }

            inFile.Close();
            return trainer;
        }

        // add a trainer
        public Trainer[] AddTrainer() 
        {
            Console.Clear();
            Console.WriteLine("To add a new trainer please do the following:");
            Console.WriteLine("Enter Trainer's ID");
            Trainer myTrainer = new Trainer();
            myTrainer.SetID(int.Parse(Console.ReadLine()));
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

            Save();
            return trainer;
        }

        public void Save() 
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetCount(); i++) 
            {
                outFile.WriteLine(trainer[i].ToFile());
            }
            outFile.Close();
        }

        // edit a trainer
        public Trainer[] UpdateTrainer() {
            PrintAllTrainers();
            Console.WriteLine("Please enter the trainer's ID for the trainer you wish to edit"); 
            int searchVal = int.Parse(Console.ReadLine()); 
            int foundTrainer = FindTrainer(searchVal);

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

                Save();
            }
            else
            {
                Console.WriteLine("Trainer not found");
            }
            return trainer;
        }

        public Trainer[] DeleteTrainer()
        {
            trainer = GetAllTrainers();
            Console.WriteLine("What is the trainer ID of the trainer you would like to delete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundTrainer = FindTrainer(searchVal);
            if(foundTrainer !=-1)
            {
                trainer[foundTrainer].SetDelete(true);
                Save();
                trainer = GetAllTrainers();
                Console.WriteLine("Trainer was deleted");
            }
            else
            {
                Console.WriteLine("Trainer not found");
            }
            return trainer;

        }

        public int FindTrainer(int searchVal)
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainer[i].GetID() == searchVal) 
                {
                    return i;
                }
            }
            return -1;
        }

        public void Sort() 
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

        public void Swap(int x, int y) 
        {
            Trainer temp = trainer[x];
            trainer[x] = trainer[y];
            trainer[y] = temp;
        }

        public void PrintAllTrainers()
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                Console.WriteLine(trainer[i].ToString());
            }
        }

        public void GoodByeTrainer()
        {
            Console.WriteLine("Exiting ...");
        }
  
    }
}