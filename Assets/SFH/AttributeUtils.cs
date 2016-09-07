using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public class AtrributeFlagFunction
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
            AtrributeFlagFunction aff = new AtrributeFlagFunction();
            var objs = field.GetCustomAttributes(typeof(T), false);
            if (objs.Length > 0)
            {
                aff.monob = p;
                aff.methodInfo = field;
                T attr = (T)objs[0];
                int value = attr.GetLevel();
                if (!myFuctionList.ContainsKey(value))
                {
                    {
                        List<AtrributeFlagFunction> AttributeList = new List<AtrributeFlagFunction>();
                        AttributeList.Add(aff);
                        myFuctionList.Add(value, AttributeList);
                    }
                }
                else
                {
                    List<AtrributeFlagFunction> mlist = (List<AtrributeFlagFunction>)myFuctionList[value];
                    mlist.Add(aff);
                }
                //Debug.Log(field.GetMethodBody().ToString() + "my levle is  " + value);
            }
            
        }
    }
}
