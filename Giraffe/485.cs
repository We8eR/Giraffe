﻿using System.Runtime.CompilerServices;

private struct Nullable<T> where T : struct
{
    private Boolean hasValue = false;
    internal T value = default(T);
    public Nullable(T value)
    {
        this.value = value;
        this.hasValue = true;
    }
    public Boolean HasValue { get { return hasValue; } }

    public T Value
        get {
        if(!hasValue) {
           throw new InvalidOperationException("Nullable object must have a value.");
        }
        return value;
    }
}

public T GetValueOrDefault() { return value; }

public T GetValueOrDefault(T defaultValue)
{
    if(!HasValue) return defaultValue;
    return value;
}

public override Boolean Equals(Object other)
{
    if (!HasValue) return (other == null);
    if (other == null) return false;
    return value.Equals(other);
}

public override int GetHashCode()
{
    if (!HasValue) return 0;
    return value.GetHashCode();
}

public override string ToString()
{
    if (!HasValue) return "";
    return value.ToString();
}

public static implicit operator Nullable<T>(T value)
{
    return new Nullable<T>(value);
}

public static implicit operator Nullable<T>(T value)
{
    return new Nullable<T>(value);
}

public static implicit operator T(Nullable<T> value)
{
    return value.Value;
}
}