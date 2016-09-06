using System;

/// <summary>this is my attribute test.</summary>
/// 
[System.AttributeUsage(AttributeTargets.All)]
public class SFHCall : Attribute
{
    public SFHCall(int lev)
    {
        level = lev;
    }

    public int GetLevel()
    {
        return level;
    }
    protected int level;
}

[System.AttributeUsage(AttributeTargets.All)]
public class SFHStartCall : SFHCall
{
    public SFHStartCall(int lev):base(lev)
    {
        level = lev;
    }
}