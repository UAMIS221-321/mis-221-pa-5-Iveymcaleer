namespace mis_221_pa_5_Iveymcaleer
{
    public class CustomerMemberships
    {

    // this is a class for customers to add, change, or delete their own membership
    public int custId;
    public string custName;
    public string custEmail;
    public double cost;
    public int month;
    public int day;
    public int year;
    public string date;
    static public int count;
    public bool delete;


    public CustomerMemberships() 
    {

    }

    public CustomerMemberships(int custId, string custName, string custEmail, double cost, int month, int day, int year, string date) 
    {
      this.custId = custId;
      this.custName = custName;
      this.custEmail = custEmail;
      this.cost = cost;
      this.month = month;
      this.day = day;
      this.year = year;
      this.date = date;
      
    }

    public void SetCustID(int custId) 
    {
      this.custId = custId;
    }

    public int GetCustID() 
    {
      return custId;
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

    public void SetCost(double cost)
    {
      this.cost = cost;
    }

    public double GetCost()
    {
      return cost; 
    }

    public string SetDate()
    {
      return date;
    }
    public string GetDate() 
    {
      return date;
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
      CustomerMemberships.count = count;
    }

    static public void IncCount() 
    {
      CustomerMemberships.count++;
    }

    static public int GetCount() 
    {
      return CustomerMemberships.count;
    }


    public override string ToString() 
    {
      return $"{custName}, you customer gym ID is #{custId}. You pay ${cost} per month and purchased this membership on {month}/{day}/{year}.\nIf we need to reach out to you, we will do so at {custEmail} ";
    }

    public string ToFile() 
    {
      return $"{custName}#{custId}#{cost}#{month}#{day}#{year}#{date}#{custEmail}";
    }
        
  } 
    
}