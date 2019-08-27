using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientBegin : MonoBehaviour
{
    private void Start()
    {
        Factory fact = new Factory();
        ShareFlyWeight fw1 =  fact.FactoryMake("Let");
        fw1.SetExternalState(Color.black);
        fw1.ShowState();
        ShareFlyWeight fw2 = fact.FactoryMake("Let");
        fw2.SetExternalState(Color.red);
        fw2.ShowState();
        ShareFlyWeight fw3 = fact.FactoryMake("Let");
        fw3.SetExternalState(Color.green);
        fw3.ShowState();
    }
}
