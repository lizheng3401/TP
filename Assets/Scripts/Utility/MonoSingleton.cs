using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

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
                        SetupInstance();
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
			DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static void SetupInstance()
    {
        _instance = FindObjectOfType<T>();
        if (_instance == null)
        {
            var obj = new GameObject(typeof(T).Name);
            _instance = obj.AddComponent<T>();
            DontDestroyOnLoad(obj);
        }
    }
}