using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;

class SFHListener
{
    static SFHListener()
    {
        InitialStart();
    }
        
    public static void callme()
    {
        Console.WriteLine("call me");
    }


    private  static void InitialStart()
    {
        MonoBehaviour[] testMono = GetScriptAssetsOfType<MonoBehaviour>();
        AttributeUtils.GetAllDestByProperties<SFHCall>(testMono);

        int AttributeFunctionCount = AttributeUtils.monoRPCMethodsCache.Count;
        if (AttributeFunctionCount < 0)
        {
            return;
        }

        foreach (var item in AttributeUtils.monoRPCMethodsCache)
        {
            MonoBehaviour monob = (MonoBehaviour)item.Key;
            for (int iMethod = 0; iMethod < item.Value.Count; iMethod++)
            {
                object result = item.Value[iMethod].Invoke((object)monob, new object[] { });
                if (item.Value[iMethod].ReturnType == typeof(IEnumerator))
                {
                    monob.StartCoroutine((IEnumerator)result);
                }
            }
        }
    }

    private static MonoBehaviour[] GetScriptAssetsOfType<T>()
    {
        // current scripts in current scene;
        MonoBehaviour[] Monoscripts = (MonoBehaviour[])GameObject.FindObjectsOfType<MonoBehaviour>();
        // get all monobehaviours contains current scene and also all Prefabs
        //MonoBehaviour[] Monoscripts = (MonoBehaviour[])Resources.FindObjectsOfTypeAll<MonoBehaviour>();
        return Monoscripts;
    }
}


