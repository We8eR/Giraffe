using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;

[Serializable]
internal class Base
{
    protected String m_name = "Jeff";
    public Base() { /* Наделяем тип способностью создавать экземпляры */ }
}

[Serializable]
internal class Derived : Base, ISerializable
{
    private DateTime m_date = DateTime.Now;
    public Derived() { /* Наделяем тип способностью создавать экземпляры */ }

    [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    private Derived(SerializationInfo info, StreamingContext context)
    {
        Type baseType = this.GetType().BaseType;
        MemberInfo[] mi = FormatterServices.GetSerializableMembers(baseType, context);

        for(Int32 i = 0; i < mi.Length; i++)
        {
            FieldInfo field = (FieldInfo)mi[i];
            fi.SetValue(this, info.GetValue(baseType.FullName + "+" + fi.Name, fi.FieldType));
        }
        m_date = info.GetDateTime("Date");
    }
    [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Date", m_date);
        Type baseType = this.GetType().BaseType;
        MemberInfo[] mi = FormatterServices.GetSerializableMembers(baseType, context);
        
        for(Int32 i = 0;i < mi.Length; i++)
        {
            FieldInfo fi = (FieldInfo)mi[i];
            fi.SetValue(this, info.GetValue(baseType.FullName + "+" + fi.Name, fi.FieldType));
        }
        m_date = info.GetDateTime("Date");
    }
    [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Date", m_date);
        Type baseType = this.GetType().BaseType;
        MemberInfo[] mi = FormatterServices.GetSerializableMembers(baseType, context);
        for (Int32 i = 0; i < mi.Length; i++)
        {
            info.AddValue(baseType.FullName + "+" + mi[i].Name, ((FieldInfo)mi[i]).GetValue(this));
        }
    }
    public override string ToString()
    {
        return String.Format("Name = {0}, Date={1}", m_name, m_date);
    }
}