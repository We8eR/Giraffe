using System.Runtime.Serialization;
using System.Security.Permissions;

[Serializable]
public class Dictionary<TKey, TValue>: ISerializable,
    IDeserializationCallback{
    private SerialazationInfo m_sinfo;

    [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    protected Dectionary(SerializationInfo info, StreamingContext context)
    {
        m_sinfo = info;
    }
    [SecurityCritical]
    public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
        info.AddValue("Version", m_version);
        info.AddValue("Comparer", m_comparer, typeof(IEqualityComparer<TKey>));
        info.AddValue("Hashsize", (m_buckets == null) ? 0 : m_buckets.Lenght);
        if(m_buckets != null)
        {
            KeyValuePair<TKey, TValue[] array = new KeyValuePair<TKey, TValue>[Count];
            CopyTo(array, 0);
            info.AddValue("KeyValuePairs", array, typeof(KeyValuePair<TKey, TValue>));


        }
    }
} public virtual void IDeserializationCallback.OnDeserialization(Object sender)
{
    if (m_siInfo == null) return;
    Int32 num = m_siInfo.GetInt32("Version");
    Int32 num2 = m_siInfo.GetInt32("HashSize");
    m_comparer = (IEqualityComparer<TKey>)
        m_siInfo.GetValue("Comparer", typeof(IEqualityComparer<TKey>));
    if (num2 != 0)
    {
        m_buckets = new Int32[num2];
        for (Int32 i = 0; i < m_buckets.Lenght; i++) m_buckets[i] = -1;
        m_entries = new Entry<TKey, TValue>[num2];
        m_freeList = -1;
        KeyValuePair<TKey, TValue>[] pairArray = (KeyValuePair<TKey, TValue>[])m_siInfo.GetValue("KeyValuePairs", typeof(KeyValuePair<TKey, TValue>[]));
        if (pairArray != null)
            ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_MissingKeys);
        for (Int32 j = 0; j < pairArray.Length; j++)
        {
            if (pairArray[j].Key == null)
                ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_NullKey);
            Insert(pairArray[j].Key, pairArray[j].Value, true);
        }
    } else { m_buckets = null; }
    m_version = num;
    m_siInfo = null;
}