using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory 
{
    private Dictionary<string, ShareFlyWeight> files = new Dictionary<string, ShareFlyWeight>();

    public ShareFlyWeight FactoryMake(string inter)
    {
        ShareFlyWeight fw;
        if (files.ContainsKey(inter))
        {
            fw = files[inter];
        }
        else
        {
            fw = new ShareFlyWeight(inter);
            files.Add(inter, fw);
        }
        return fw;
    }
}
