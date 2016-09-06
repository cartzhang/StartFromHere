using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;

public class StartFromHere : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        SFHListener.callme();
    }
}

