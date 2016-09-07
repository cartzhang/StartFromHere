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
        AttributeUtils.GetAllDestByProperties<SFHStartCall>(testMono);        
        for (int i = 0; i < AttributeUtils.myFuctionList.Count; i++)
        {
            List<AtrributeFlagFunction> mlist = (List<AtrributeFlagFunction>)AttributeUtils.myFuctionList.GetByIndex(i);
            for (int j = 0; j < mlist.Count; j++)
            {
                AtrributeFlagFunction item = (AtrributeFlagFunction)mlist[j];
                Debug.Log("order is " + AttributeUtils.myFuctionList.GetKey(i));
                MonoBehaviour monob = (MonoBehaviour)item.monob;
                object result = item.methodInfo.Invoke((object)monob, new object[] { });
                if (item.methodInfo.ReturnType == typeof(IEnumerator))
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


