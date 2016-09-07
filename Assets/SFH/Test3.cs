using UnityEngine;
using System.Collections;

public class Test3 : MonoBehaviour {

    // Use this for initialization
    [SFHStartCall(10)]
    void OnStart () {
        Debug.Log(this.name + "Test3");
    }
	
	// Update is called once per frame
	void OnUpdate () {
	
	}

    
}
