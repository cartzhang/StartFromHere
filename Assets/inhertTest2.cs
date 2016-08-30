using UnityEngine;
using System.Collections;

public class inhertTest2 : Test2
{

    [SFHCall]
    public void  myIntets()
    {
        Debug.Log("inherit test ");
    }

    [SFHCall]
    public override void IscanBeCalled()
    {
        Debug.Log("inherit " + " inherit  test2 SFHCall can be called here");
    }

}
