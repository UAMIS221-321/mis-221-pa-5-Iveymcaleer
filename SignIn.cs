namespace mis_221_pa_5_Iveymcaleer
{
    public class SignIn
    {
        // this is a class for customers to sign in once at the gym, if they are a new customer they get one class for free and are not charged.
        // Yet, the gym will have access to the cutomers who signed in as new so they can keep track of how many cutomers have not signed up for a membership yet.
        // There is also a sign in for returning members and their email is searched to make sure they pay a monthly fee (membership) to be able to use the gym
        public string custName;

        public int custId;

        public int memId;

        public DateOnly signInDate;

        public TimeOnly signInTime;

        public string custEmail;


        private static int count;

        public SignIn() 
        {

        }

        public SignIn(string custName, int custId, int memId, DateOnly signInDate, TimeOnly signInTime, string custEmail)
        {
            this.custName = custName;
            this.custId = custId;
            this.memId = memId;
            this.signInDate = signInDate;
            this.signInTime = signInTime;
            this.custEmail = custEmail;
        }

        public void SetCustName(string custName) 
        {
            this.custName = custName;
        }

        public string GetCustName() 
        {
            return custName;
        }

        public void SetCustId(int custId) 
        {
            this.custId = custId;
        }

        public int GetCustId() 
        {
            return custId;
        }

        public void SetMemId(int memId) 
        {
            this.memId = memId;
        }

        public int GetMemId() 
        {
            return memId;
        }
        public void SetDate(DateOnly signInDate) 
        {
            this.signInDate = signInDate;
        }

        public DateOnly GetDate() 
        {
            return signInDate;
        }

        public void SetTime(TimeOnly signInTime)
        {
            this.signInTime = signInTime;
        }

        public TimeOnly GetTime()
        {
            return signInTime;
        }
        public void SetCustEmail(string custEmail) 
        {
            this.custEmail = custEmail;
        }

        public string GetCustEmail()
        {
            return custEmail;
        }

        static public void SetCount(int count) 
        {
            SignIn.count = count;
        }

        static public void IncCount() 
        {
            SignIn.count++;
        }

        static public int GetCount() 
        {
            return SignIn.count;
        }

        public override string ToString()
        {
            return $"You, {custName}, are checked in on {signInDate} at {signInTime} with this email: {custEmail}.";
        }

        public string ToFile1() 
        {
            return $"{custName}#{signInDate}#{signInTime}#{custEmail}";
        }


    }
}