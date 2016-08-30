using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;


public class AttributeUtils
{
    public static Dictionary<MonoBehaviour, List<MethodInfo>> monoRPCMethodsCache = new Dictionary<MonoBehaviour, List<MethodInfo>>();
    
    public static void GetAllDestByProperties<T>(object []mono)
    {
        int length = mono.Length;
        for (int i = 0; i < length; i++)
        {
            GetDescByProperties<T>(mono[i]);
        }
    }

    private static void GetDescByProperties<T>(object p)
    {
        MonoBehaviour mo = (MonoBehaviour)p;
        if (!monoRPCMethodsCache.ContainsKey(mo))
        {
            Cache<T>(mo);
        }
        return;
    }

    private static void Cache<T>(MonoBehaviour p)
    {
        List<MethodInfo> cachedCustomMethods = new List<MethodInfo>();
        monoRPCMethodsCache.Add(p, cachedCustomMethods);
        var type = p.GetType();
        // 不会重复调用父类的方法了。
        var fields2 = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (var field in fields2)
        {
            var objs = field.GetCustomAttributes(typeof(T), false);
            if (objs.Length > 0)
            {
                cachedCustomMethods.Add(field);
            }
        }
    }

    //private static void Cache<T>(Type type)
    //{
    //    List<MethodInfo> cachedRPCMethods = null;

    //    var dict = new Dictionary<string, string>();
    //    cache.Add(type, dict);
    //    //var fields = type.GetFields();
    //    var fields2 = type.GetMethods();
    //    foreach (var field in fields2)
    //    {
    //        var objs = field.GetCustomAttributes(typeof(T), true);
    //        if (objs.Length > 0)
    //        {
    //            T obj = (T)objs[0];
    //            Type attrType = obj.GetType();
    //            PropertyInfo pi = attrType.GetProperty("Desc");
    //            UnityEngine.Debug.Log(pi);

    //            dict.Add(field.Name, pi.GetValue(obj, null).ToString());
    //        }
    //    }
    //}
}
