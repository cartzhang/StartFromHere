using UnityEngine;
using System.Collections;

public class inhertTest2 : Test2
{

    [SFHStartCall(1)]
    public void  myIntets()
    {
        Debug.Log("inherit test ");
    }

    [SFHStartCall(2)]
    public override void IscanBeCalled()
    {
        Debug.Log("inherit " + " inherit  test2 SFHCall can be called here");
    }

}
