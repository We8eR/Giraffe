using System.Runtime.Serialization;
using System.Security.Permissions;

[Serializable]
public sealed class Singleton : ISerializable
{
    private static readonly Singleton theOneObject = new Singleton();

    public String Name = "Jeff";
    public DateTime Date = DateTime.Now;
    private Singleton() { }

    public static Singleton GetSingleton() { return theOneObject; }

    [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.SetType(typeof(SingletonSerializationHelper));
    }
    [Serializable]
    private sealed class SingletomSerializationHelper : IObjectRegerence
    {
        public Object GetRealObject(StreamingContext context)
        {
            return Singleton.GetSingleton();
        }
    }
}