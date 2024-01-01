public static class Contract
{
    public static void Requires(Boolean condition);
    public static void EndContractBlock();
}

public static void Requirea<TException>(Boolean condition) where TException : Exception;

public static void Ensures(Boolean condition);
public static void EnsuresOnThrow<TException>(Boolean condition) where TException : Exception;
public static T Result<T>();
public static T OldValue<T>(T value);
public static T ValueAtReturn<T>(out T value);

public static void Invariant(Boolean condition);

public static Boolean Exists<T>(IEnumerable<T> collection, Predicate<T> predicate);
public static Boolean Exists(Int32 fromInclusive, Int32 toExclusive, Predicate<Int32> predicate);

public static Boolean ForAll<T>(IEnumerable<T> collection, Predicate<T> predicate);
public static Boolean ForAll(Int32 fromInclusive, Int32 toExclusive, Predicate<Int32> predicate);
public static void Assert(Boolean condition);
public static void Assume(Boolean condition);
public static event EventHandler<ContractFailedEventArgs> ContractFailed;   
}

