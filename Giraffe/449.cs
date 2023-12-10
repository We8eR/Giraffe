using System;
using System.Reflection;
using System.Text;

internal sealed class Light
{
    public String SwitchPosition()
    {
        return "The light is off";
    }
}

internal sealed class Fan
{
    public String Speed()
    {
        throw new InvalidOperationException("The fan broke due to overhating");
    }
}
internal sealed class Program
{
    private delegate String GetStatus();

    public static void Main()
    {
        GetStatus getStatus = null;
        getStatus += new GetStatus(new Light().SwitchPosition);
        getStatus += new GetStatus(new Fan().Speed);
        getStatus += new GetStatus(new Speaker().Volume);
        Console.WriteLine(GetComponentStatusReport(getStatus));
    }
    private static String GetComponentStatusReport(GetStatus status)
    {
        if (status == null) return null;
        StringBuilder report = new StringBuilder();
        Delegate[] arrayOfDelegates = status.GetInvocationList();
        foreach (GetStatus getStatus in arrayOfDelegates)
        {
            try
            {
                report.AppendFormat("{0}{1}{1}", getStatus(), Enviroment.NewLine);
                
            }
            catch (InvalidOperationException e)
            {
                Object components = getStatus.Target;
                report.AppendFormat("Failed to get status from {1}{2}{0} Error: {3}{0}{0}", Enviroment.NewLine, ((components == null) ? "" : component.GetType() + "."), getStatus.Method.Name, e.Message);

            }
        }
        return report.ToString();
    }
}