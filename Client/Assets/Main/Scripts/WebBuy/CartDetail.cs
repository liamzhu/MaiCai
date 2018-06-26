using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartDetail : MonoBehaviour {

    public GameObject objTemplate;
    public RectTransform objContent;

    List<CartItem> itemPool = new List<CartItem>();
    // Use this for initialization
    void Start () {

    }

    void OnEnable()
    {
        if (itemPool.Count == 0) {
            for (int i = 0; i < 30; i++)
            {
                GameObject objItem = Instantiate(objTemplate) as GameObject;
                //objItem.transform.parent = objContent.transform;
				objItem.transform.SetParent(objContent.transform);
                itemPool.Add(objItem.GetComponent<CartItem>());
            }
        }
        SetShow();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetShow() {
        for (int i = 0; i < itemPool.Count; i++) {
            itemPool[i].gameObject.SetActive(false);
        }
        //GameMrg.mInstance.curBuyGoodList;   

		objContent.transform.localPosition = new Vector3(0, 0, 0);
        objContent.sizeDelta = new Vector2(1904, GameMrg.mInstance.curBuyGoodList.Count * 200 + 350);
        for (int i = 0; i < GameMrg.mInstance.curBuyGoodList.Count; i++) {
            Good curGood = GameMrg.mInstance.curBuyGoodList[i];
            itemPool[i].transform.localPosition = new Vector3(952,-108 - i*180f,0);
            itemPool[i].gameObject.SetActive(true);
			itemPool[i].SetShow(curGood,this);
        }
    }

    public void ClickOnBack() {
        gameObject.SetActive(false);
    }

    //确定了
    public void ClickOnConfirm() {

    }
}
