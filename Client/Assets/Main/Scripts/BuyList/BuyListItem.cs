using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyListItem : MonoBehaviour {
    public Text goodName;
    public Image icon;
    public Text area;

    Good curGood;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGood(Good mGood) {
        curGood = mGood;

        goodName.text = curGood.name;
    }
}
