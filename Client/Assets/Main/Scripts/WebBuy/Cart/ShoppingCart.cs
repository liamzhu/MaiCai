using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingCart : MonoBehaviour {
    public Text num;

    public CartDetail cartDetail;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.frameCount % 5 != 0) {
            return;
        }

        if (GameMrg.mInstance.curBuyGoodList.Count == 0)
        {
            num.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            num.transform.parent.gameObject.SetActive(true);
            num.text = GameMrg.mInstance.curBuyGoodList.Count.ToString();
        }
	}

    public void ClickOnCart() {
        cartDetail.gameObject.SetActive(true);
    }
}
