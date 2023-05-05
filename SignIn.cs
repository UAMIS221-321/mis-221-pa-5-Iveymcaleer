namespace mis_221_pa_5_Iveymcaleer
{
    public class SignIn
    {
        // this is a class for customers to sign in once at the gym, if they are a new customer they get one class for free and are not charged.
        // Yet, the gym will have access to the cutomers who signed in as new so they can keep track of how many cutomers have not signed up for a membership yet.
        // There is also a sign in for returning members and their email is searched to make sure they pay a monthly fee (membership) to be able to use the gym
        public int signId;
        public string custName;
        public DateOnly signInDate;
        public string custEmail;
        private static int count;


        public SignIn() 
        {

        }

        public SignIn(int signId, string custName, DateOnly signInDate, string custEmail)
        {
            this.signId = signId;
            this.custName = custName;
            this.signInDate = signInDate;
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

        public void SetSignId(int signId) 
        {
            this.signId = signId;
        }

        public int GetSignId() 
        {
            return signId;
        }

        public void SetDate(DateOnly signInDate) 
        {
            this.signInDate = signInDate;
        }

        public DateOnly GetDate() 
        {
            return signInDate;
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
            return $"#{signId} sign in : {custName}\tsigned in on {signInDate} with this email: {custEmail}.";
        }

        public string ToFile() 
        {
            return $"{signId}#{custName}#{signInDate}#{custEmail}";
        }



    }
}