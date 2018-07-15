using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Good{
    public GoodType type;
    public string name;
    public string icon;

    public Good(GoodType mType,string mName) {
        type = mType;
        name = mName;
    }
}
