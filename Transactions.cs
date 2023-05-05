namespace mis_221_pa_5_Iveymcaleer
{
    public class Transactions
    {
        public int sessionId;
        public string custName;
        public string custEmail;
        public string transactionDate;
        public int month;
        public int day;
        public int year;
        public TimeOnly transactionTime;
        public int tId;
        public string tName;
        public string classType; // extra field w accessors and mutators
        //public string f;
        static public int count;
        public int cost;

        public Transactions() 
        {

        }

        public Transactions(int sessionId, string custName, string custEmail, string transactionDate, int month, int day, int year, TimeOnly transactionTime, int tId, string tName, string classType, int cost) 
        {
            this.sessionId = sessionId;
            this.custName = custName;
            this.custEmail = custEmail;
            this.transactionDate = transactionDate;
            this.month = month;
            this.day = day;
            this.year = year;
            this.transactionTime = transactionTime;
            this.tId = tId;
            this.tName = tName;
            this.classType = classType;
            this.cost = cost;
        }


        public void SetID( int sessionId) 
        {
            this.sessionId = sessionId;
        }

        public int GetID() 
        {
            return sessionId;
        }
        public void SetCost(int cost) 
        {
            this.cost = cost;
        }

        public int GetCost() 
        {
            return cost;
        }

        public void SetCustName(string custName) 
        {
            this.custName = custName;
        }

        public string GetCustName() 
        {
            return custName;
        }

        public void SetCustEmail(string custEmail) 
        {
            this.custEmail = custEmail;
        }

        public string GetCustEmail() 
        {
            return custEmail;
        }

        public void SetDate (string transactionDate) 
        {
            this.transactionDate = transactionDate;
        }

        public string GetDate() 
        {
            return transactionDate;
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

        public void SetTime(TimeOnly transactionTime)
        {
            this.transactionTime = transactionTime;
        }

        public TimeOnly GetTime()
        {
            return transactionTime;
        }

        public void SetTId(int tId) 
        {
            this.tId = tId;
        }

        public int GetTId() 
        {
            return tId;
        }

        public void SetTName(string tName) 
        {
            this.tName = tName;
        }

        public string GetTName() 
        {
            return tName;
        }


        public void SetClassType(string classType) 
        {
            this.classType = classType;
        }

        public string GetClassType()
        {
            return classType;
        }

        // public void SetStatus(string f) 
        // {
        //     this.f = f;
        // }

        // public string SetStatus()
        // {
        //     return f;
        // }


        static public void SetCount(int count) 
        {
            Transactions.count = count;
        }

        static public void IncCount() 
        {
            Transactions.count++;
        }
        static public int GetCount() 
        {
            return Transactions.count;
        }

        public override string ToString() 
        {
            return $"#{sessionId}, is the session you are booked for, {custName} (with this email: {custEmail} on {transactionDate}).\nReceipt: {month}/{day}/{year}, {transactionTime}\tWith ({tId}){tName} for {classType}.\t${cost}\n ";
        }

        public string ToFile() 
        {
            return $"{sessionId}#{custName}#{custEmail}#{transactionDate}#{month}#{day}#{year}#{transactionTime}#{tId}#{tName}#{classType}#{cost}";
        }



    }
}