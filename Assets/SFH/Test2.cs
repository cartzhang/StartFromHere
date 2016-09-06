using UnityEngine;
using System.Collections;
using System;

public class Test2 : MonoBehaviour
{

    private string classname = "Test2";

    
    // Use this for initialization
    void OnStart() {
        Debug.Log(this.name + classname);
    }

    // Update is called once per frame
    void OnUpdate()
    {

    }
    [SFHStartCall(20)]
    public virtual void IscanBeCalled()
    {
        Debug.Log(classname + "SFHCall can be called here");
    }

    [SFHStartCall(19)]
    private void Test()
    {
        Debug.Log(classname + "Test function");
    }

    [SFHStartCall(18)]
    public void mutsssstd()
    {
        Debug.Log(classname + "mutsssstd function");
    }

}
