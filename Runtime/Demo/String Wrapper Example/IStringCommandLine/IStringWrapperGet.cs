using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStringWrapperGet
{
    public string GetString();
    public void GetString(out string value);
    public void StoreStringIn(ref string container);
    public bool IsEmpty();
    public bool IsNull();
    public int Lenght();
    public char GetCharAt(int index);

}
public interface IStringWrapperSet
{
    public void SetValue(in string value);
}
public interface IStringRefGetSet: IStringWrapperGet
{}


public class StringWrapper : IStringWrapperSet, IStringWrapperGet
{
    private string m_value;

    public StringWrapper(string value="")
    {
        m_value = value;
    }
 
    public string GetString()
    {
        return m_value;
    }

    public void GetString(out string value)
    {
        value = m_value;
    }
    public bool IsWhitespace()
    {
        return string.IsNullOrWhiteSpace(m_value);
    }

    public bool IsEmpty()
    {
        return string.IsNullOrEmpty(m_value);
    }

    public bool IsNull()
    {
        return m_value == null;
    }

    public void SetValue(in string value)
    {
        m_value = value;
    }

    public void StoreStringIn(ref string container)
    {
        container = m_value;
    }

    public int Lenght()
    {
        return m_value.Length;
    }

    public char GetCharAt(int index)
    {
        if (index >= Lenght())
            return ' ';
        return m_value[index];
    }
}

public class StringDelegeRefWrapper :  IStringWrapperGet
{
    public delegate string AccessTargetString();
    private AccessTargetString m_valueGet;

    public void SetHowToAccessString(AccessTargetString methodeToAccess) { m_valueGet = methodeToAccess; }
    public string GetString()
    {
        if (m_valueGet == null) return "";
        return m_valueGet();
    }

    public void GetString(out string value)
    {
        if (m_valueGet == null) value= "";
        else value= m_valueGet();
    }
    public bool IsWhitespace()
    {
        return string.IsNullOrWhiteSpace(GetString());
    }

    public bool IsEmpty()
    {
        return string.IsNullOrEmpty(GetString());
    }

    public bool IsNull()
    {
        return m_valueGet == null || GetString()==null;
    }

    public void StoreStringIn(ref string container)
    {
        container = GetString();
    }
    public int Lenght()
    {
        return GetString().Length;
    }
    public char GetCharAt(int index)
    {
        if (index >= Lenght())
            return ' ';
        return GetString()[index];
    }
    public AccessTargetString GetAccessor() { return m_valueGet; }
}