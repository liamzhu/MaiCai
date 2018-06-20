using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebPageGoodItem : MonoBehaviour {
    public Image icon;
    public Text goodName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetItem(Good g) {
        gameObject.SetActive(true);
        goodName.text = g.name;
    }

    public void ClickOnBuy() {

    }
}
