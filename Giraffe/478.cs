using System;
[Flags]
internal enum Accounts
{
    Savings = 0x0001,
    Checking = 0x0002,
    Brokerage = 0x0004
}
[AttributeUsage(AttributeTargets.Class)]
internal sealed class AccountAttribute : Attribute
{
    private Accounts m_accounts;

    public AccountsAttribute(Accounts accounts)
    {
        m_accounts = accounts;
    }
    public override Boolean Match(Object obj)
    {
        if(obj == null) return false;
        if(this.GetType() != obj.GetType()) return false;
        AccountsAttribute other = (AccountAttribute)obj;
        if((other.m_accounts & m_accounts) != m_accounts)
            return false;
        return true;
    }

    public override Boolean Equals(Object obj)
    {
        if(obj == null) return false;
        if(this.GetType() != obj.GetType()) return false;
        AccountAttribute other = (AccountAttribute)obj;
        if(other.m_accounts != m_accounts) 
            return false;
        return true;
    }
    public override Int32 GetHashCode()
        return(Int32) m_accounts;
    }
  }
[Accounts(Accounts.Savings)]
internal sealed class ChildAccount { }

[Accounts(Accounts.Savings / Accounts.Checking / Accounts.Brokerage)]
internal sealed class AdultAccount { }

public sealed class Program
{
    public static void Main()
    {
        CanWriteCheck(new ChildAccount());
        CanWriteCheck(new AdultAccount());
        CanWriteCheck(new Program());
    }
public static void CanWriteCheck(Object obj)
    {
        Attribute cheking = new AccountsAttribute(Accounts.Checking);
        Attribute validAccounts =
            obj.GetType().GetCustomAttributes<AccountsAttribute>(false);
        if (validAccounts != null) && cheking.Match(validAccounts)){
            Console.WriteLine("{0} types can write checks.", obj.GetType());
        }else{
            Console.WriteLine("{0} types can NOT write checks.", obj.GetType());
    }
}
}