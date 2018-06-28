using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebPageGoodItem : MonoBehaviour {
    public Image icon;
    public Text goodName;
    public Button btnAdd;

    Good goodInfo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetItem(Good g) {
        goodInfo = g;
        gameObject.SetActive(true);
        goodName.text = g.name;
    }

    public void ClickOnBuy() {
        if (GameMrg.mInstance.curBuyGoodList.Count >= GameMrg.mInstance.curTask.goodList.Count) {
            //Debug.Log("已达购买最大数目限制！");
            GameMrg.mInstance.LoadPopUpTip("已达购买最大数目限制");
            return;
        }

        if (GameMrg.mInstance.curBuyGoodList.Contains(goodInfo))
        {
            //Debug.Log("这个已经买过啦！");
            GameMrg.mInstance.LoadPopUpTip("这个已经买过啦");
        }
        else
        {
            GameMrg.mInstance.curBuyGoodList.Add(goodInfo);
        }
    }
}
