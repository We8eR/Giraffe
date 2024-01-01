
using System.ComponentModel.Design;

public static class GCNotification
{
    private static Action<Int32> s_gcDone = null;

    public static event Action<Int32> GCDone
    {
        add
        {
            if (s_gcDone == null) { new GenObject(0); new GenObject(2); }
            s_gcDone += value;
        }
        remove { s_gcDone -= value; }
    }
    private sealed class GenObject
    {
        private Int32 m_generation;
        public GenObject(Int32 generation) { m_generation = generation; }
        ~GenObject()
        {
            Action<Int32> temp = Volatile.Read(ref s_gcDone);
            if (temp != null) temp(m_generation);
        }
        if((s_gcDone != null))
            && !AppDomain.CurrentDomain.IsFinalizingForUnload()
            && !Environment.HasShutdownStarted) {
            if (m_generation == 0) new GenObject(0);
            else GC.ReRegisterForFinalize(this);
        } else { /* Позволяем объекту исчезнуть */ }
    }
}
}
