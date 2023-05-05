namespace mis_221_pa_5_Iveymcaleer
{
  public class Membership
  {

    //this is an extra class for the manager of the gym to add, delete, and update memberships
    //please look at file to see what the memberships are supposed to look like

    public int memId;
    public string hourAccess;
    public string consultantion;
    public string kidCare;
    public string premiumClass;
    public string complimentaryClass;
    public int cost; 
    static public int count;
    public bool delete;

    public Membership() 
    {

    }

    public Membership(int memId, string hourAccess, string consultantion, string kidCare, string premiumClass, string complimentaryClass, int cost) 
    {
      this.memId = memId;
      this.hourAccess = hourAccess;
      this.consultantion = consultantion;
      this.kidCare = kidCare;
      this.premiumClass = premiumClass;
      this.complimentaryClass = complimentaryClass;
      this.cost = cost;
    }

    public void SetMemId(int memId) 
    {
      this.memId = memId;
    }

    public int GetMemId() 
    {
      return memId;
    }

    public void SetHourAccess(string hourAccess) 
    {
      this.hourAccess = hourAccess;
    }

    public string GetHourAccess() 
    {
      return hourAccess;
    }

    public void SetConsultation(string consultantion) 
    {
      this.consultantion = consultantion;
    }

    public string GetConsultation() 
    {
      return consultantion;
    }

    public void SetKidCare(string kidCare) 
    {
      this.kidCare = kidCare;
    }

    public string GetKidCare() 
    {
      return kidCare;
    }

    public void SetPremiumClass(string premiumClass)
    {
      this.premiumClass = premiumClass;
    }

    public string GetPremiumClass()
    {
      return premiumClass;
    }

    public void SetComplimentaryClass(string complimentaryClass)
    {
      this.complimentaryClass = complimentaryClass;
    }

    public string GetComplimentaryClass()
    {
      return complimentaryClass;
    }

    public void SetCost(int cost) 
    {
      this.cost = cost;
    }

    public int GetCost()
    {
      return cost; 
    }

    static public void SetCount(int count) 
    {
      Membership.count = count;
    }

    static public void IncCount() 
    {
      Membership.count++;
    }

    static public int GetCount() 
    {
      return Membership.count;
    }

    public void SetDelete(bool delete)
    {
      this.delete = delete;  
    }
    public bool GetDelete()
    {
      return delete;
    }

    public override string ToString() 
    {
      return $"Membership #{memId} gives members {hourAccess}, {consultantion}, {kidCare}, {premiumClass}, and {complimentaryClass} at the cost of {cost}.";
    }

    public string ToFile() 
    {
      return $"{memId}#{hourAccess}#{consultantion}#{kidCare}#{premiumClass}#{complimentaryClass}#{cost}";
    }
        
    }
}