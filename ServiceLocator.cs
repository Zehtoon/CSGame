using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator 
{
    private static Dictionary<System.Type, object> services = new Dictionary<System.Type, object>();

    public static void Register<T>(T service)
    {
        services[typeof(T)] = service;
    }

    public static T Get<T>()
    {
        if(!services.ContainsKey(typeof(T)))
        {
            Debug.LogError($"Service of type{typeof(T)} is not registered");
            return default(T);
        }
        return (T)services[typeof(T)];
    }
}
