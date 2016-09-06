using UnityEngine;
using System.Collections;

public class Test1 : MonoBehaviour
{
    public GameObject go;
    public static int count = 1;
    //public void Start()
    //{
    //    count++;
    //    Debug.LogError("current count is" + count);
    //}
	// Use this for initialization
	void OnStart ()
    {
        Debug.Log(this.name + "Test1");
	}
	
	// Update is called once per frame
	void OnUpdate () {
	
	}
        
    [SFHStartCall(10)]
    public void Test()
    {
        if (go != null)
        {
            Debug.Log(this.name + "Game object is " + go.name);
        }
        else
        {
            Debug.Log(this.name + "Game object is nul;");
        }
        Debug.Log(this.name + "Test function");
    }

    [SFHStartCall(12)]
    public void mutsssstd()
    {
        Debug.Log(this.name + "mutsssstd function");
    }

}
