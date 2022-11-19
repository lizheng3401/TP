using UnityEngine;

public sealed class TPLog
{
    public static void Log(string msg)
    {
        Debug.Log(msg);
    }

    public static void LogFormat(string format, params object[] args)
    {
        Debug.LogFormat(format, args);
    }
}