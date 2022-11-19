using System;
using System.Collections;
using UnityEngine;

public class MonoSingleton<T> :MonoBehaviour where T: MonoBehaviour
{
    private static object mutex = new object();
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (mutex)
                {
                    if (_instance == null)
                    {
                        Bootstrapper.CreateObject<T>();
                    }
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
            
        DontDestroyOnLoad(gameObject);
    }
}