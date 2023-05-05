namespace mis_221_pa_5_Iveymcaleer
{
    public class Listing
    {
        public int listId;
        public string tName;
        public string classType; //extra field  
        public int month;
        public int day;
        public int year; 
        public string listingDate; // This is only going to be displayed to user
        public TimeOnly listingTime;
        public int cost;
        public bool statusBooked;
        private bool delete;
        public int tID;

        // class field
        static private int count;

        // no arg constructor 
        public Listing() 
        {

        }

        // arg constructor 
        public Listing(int listId, string tName, string classType, int month, int day, int year, string listingDate, TimeOnly listingTime, int cost, bool statusBooked, int tID) 
        {
            this.listId = listId;
            this.tName = tName;
            this.classType = classType;
            this.month = month;
            this.day = day;
            this.year = year;
            this.cost = cost;
            this.listingDate = listingDate;
            this.listingTime = listingTime;
            this.statusBooked = statusBooked; 
            this.tID = tID;
        }

        public void SettID(int tID) 
        {
            this.tID = tID;
        }

        public int GettID() 
        {
            return tID;
        }

        public void SetListId(int listId) 
        {
            this.listId = listId;
        }

        public int GetListId() 
        {
            return listId;
        }

        public void SetTName(string tName) 
        {
            this.tName = tName;
        }

        public string GetTName() 
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
        public void SetDate(string listingDate) 
        {
            this.listingDate = listingDate;
        }

        public string GetDate() 
        {
            return listingDate;
        }

        public void SetTime(TimeOnly listingTime)
        {
            this.listingTime = listingTime;
        }

        public TimeOnly GetTime()
        {
            return listingTime;
        }

        public void SetCost(int cost) 
        {
            this.cost = cost;
        }

        public int GetCost() 
        {
            return cost;
        }

        public void SetMonth(int month) 
        {
            this.month = month;
        }

        public int GetMonth() 
        {
            return month;
        }

        public void SetDay(int day) 
        {
            this.day = day;
        }

        public int GetDay() 
        {
            return day;
        }

        public void SetYear(int year) 
        {
            this.year = year;
        }

        public int GetYear() 
        {
            return year;
        }

        public void SetStatus(bool statusBooked) 
        {
            this.statusBooked = statusBooked;
        }

        public bool GetStatus() 
        {
            return statusBooked;
        }

        public void SetDelete(bool delete)
        {
            this.delete = false;  
        }

        public bool GetDelete()
        {
            return delete;
        }
        static public void SetCount(int count) 
        {
            Listing.count = count;
        }

        static public void IncCount() 
        {
            Listing.count++;
        }
        static public int GetCount() 
        {
            return Listing.count;
        }

        public override string ToString() 
        {
            return $"Class #{listId} is lead by {tName}.\nclass: {classType}\t on {listingDate} at {listingTime} .\nspots available: {statusBooked}\n\n";
        }

        public string ToFile() 
        {
            return $"{listId}#{tName}#{classType}#{month}#{day}#{year}#{listingDate}#{listingTime}#{cost}#{statusBooked}#{tID}";
        }

    }
}