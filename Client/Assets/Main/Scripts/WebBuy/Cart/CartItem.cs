using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartItem : MonoBehaviour {
    public Image icon;
    public Text nameStr;

	CartDetail cartDetail;
    Good goodInfo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetShow(Good good,CartDetail cd) {
		cartDetail = cd;
        goodInfo = good;
        nameStr.text = good.name;
    }

    public void ClickOnDelete() {
		GameMrg.mInstance.curBuyGoodList.Remove (goodInfo);
		cartDetail.SetShow ();
    }
}
