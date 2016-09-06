using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public class AtrribteFlagFunction
{
    public MonoBehaviour monob;
    public MethodInfo methodInfo;
}

public class AttributeUtils
{
    public static SortedList myFuctionList = new SortedList();
    public static void GetAllDestByProperties<T>(object []mono) where T:SFHCall 
    {
        int length = mono.Length;
        for (int i = 0; i < length; i++)
        {
            Cache<T>((MonoBehaviour)mono[i]);
        }
    }
    
    private static void Cache<T>(MonoBehaviour p) where T : SFHCall
    {   
        var type = p.GetType();
        // 不会重复调用父类的方法了。
        var fields2 = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (var field in fields2)
        {
            AtrribteFlagFunction aff = new AtrribteFlagFunction();
            var objs = field.GetCustomAttributes(typeof(T), false);
            if (objs.Length > 0)
            {
                aff.monob = p;
                aff.methodInfo = field;
                T attr = (T)objs[0];
                int value = attr.GetLevel();
                if (!myFuctionList.ContainsKey(value))
                {
                    myFuctionList.Add(value, aff);
                }
                else
                {
                    //Debug.LogError("value is the same "  + value);
                }
                //Debug.Log(field.GetMethodBody().ToString() + "my levle is  " + value);
            }
            
        }
    }
}
