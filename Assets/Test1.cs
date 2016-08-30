using UnityEngine;
using System.Collections;

public class Test1 : MonoBehaviour {

	// Use this for initialization
	void OnStart ()
    {
        Debug.Log(this.name + "Test1");
	}
	
	// Update is called once per frame
	void OnUpdate () {
	
	}

    [SFHCall]
    public void Test()
    {
        Debug.Log(this.name + "Test function");
    }

    [SFHCall]
    public void mutsssstd()
    {
        Debug.Log(this.name + "mutsssstd function");
    }

}
