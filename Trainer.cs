namespace mis_221_pa_5_Iveymcaleer
{
    public class Trainer
    {

        //initalized varables
        public int tId;
        public string tName;
        public string classType; // extra field 
        public string mAddress;
        public string eAddress;
        public bool delete;

        // class variable 
        static private int count;

        // no arg constructor & arg constructor 

        public Trainer() 
        {

        }

        public Trainer(int tId, string tName, string classType, string mAddress, string eAddress, bool delete) 
        {
            this.tId = tId;
            this.tName = tName;
            this.classType = classType;
            this.mAddress = mAddress;
            this.eAddress = eAddress;
            this.delete = delete;
            //this.count = count;
        }

        // access mutators 

        public void SetID(int tId) 
        {
            this.tId = tId;
        }

        public int GetID() 
        {
            return tId;
        }

        public void SetName(string tName) 
        {
            this.tName = tName;
        }

        public string GetName() 
        {
            return tName;
        }

        public void SetClassType(string classType) // extra method for extra field 
        {
            this.classType = classType;
        }

        public string GetClassType() // extra method for extra field 
        {
            return classType;
        }
        public void SetMAddress(string mAddress) 
        {
            this.mAddress = mAddress;
        }

        public string GetMAddress() 
        {
            return mAddress;
        }

        public void SetEAddress(string eAddress) 
        {
            this.eAddress = eAddress;
        }

        public string GetEAddress() 
        {
            return eAddress;
        }

        static public void SetCount(int count) 
        {
            Trainer.count = count;
        }

        static public void IncCount() 
        {
            Trainer.count++;
        }

        static public int GetCount() 
        {
            return Trainer.count;
        }

        public void SetDelete(bool delete)
        {
            this.delete = false; 
        }
        public bool GetDelete()
        {
            return delete;
        }

        public override string ToString() 
        {
            return $"Trainer #{tId} is {tName}. His mail address is {mAddress} and his email address is {eAddress}.";
        }

        public string ToFile() 
        {
            return $"{tId}#{tName}#{mAddress}#{eAddress}";
        }

        
    }
}