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
    [SFHCall]
    public virtual void IscanBeCalled()
    {
        Debug.Log(classname + "SFHCall can be called here");
    }

    [SFHCall]
    private void Test()
    {
        Debug.Log(classname + "Test function");
    }

    [SFHCall]
    public void mutsssstd()
    {
        Debug.Log(classname + "mutsssstd function");
    }

}
