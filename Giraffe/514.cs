[Serializable]
public sealed class DiskFullExceptionArgs : ExceptionArgs
{
    private readonly String m_diskpath;

    public DiskFullExceptionArgs(String diskpath)
    {
        m_diskpath = diskpath;
    }
    public String Diskpath { get { return m_diskpath; } } 
    public override String Message
    {
        get
        {
            return (m_diskpath == null) ? base.Message : "DiskPath=" + m_diskpath;    
        }
    }
}