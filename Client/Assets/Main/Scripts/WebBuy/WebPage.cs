using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebPage : MonoBehaviour {
    //public Toggle[] chooseTypes;
    public GameObject objTemplate;
    public RectTransform objContent;

    List<WebPageGoodItem> itemPool = new List<WebPageGoodItem>();

	// Use this for initialization
	void Start () {
        //先生成100个
        for (int i = 0; i < 100; i++) {
            GameObject objItem = Instantiate(objTemplate) as GameObject;
            //objItem.transform.parent = objContent.transform;
			objItem.transform.SetParent (objContent.transform);
            itemPool.Add(objItem.GetComponent<WebPageGoodItem>());
        }

        GameMrg.mInstance.curBuyGoodList.Clear();
        //set default
        OnChooseValueChange(0);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnChooseValueChange(int typeNum) {
        CreateGoodList((GoodType)typeNum);
    }

    void CreateGoodList(GoodType gType) {
        //hide all
        for (int i = 0; i < itemPool.Count; i++) {
            itemPool[i].gameObject.SetActive(false);
        }

        List<Good> curList = GetChooseGoodList(gType);
        int lineNum = 7;    //一行几个
        int totalLine = curList.Count / lineNum;
        objContent.localPosition = new Vector3(objContent.localPosition.x,0,0);
        objContent.sizeDelta = new Vector2(1904,totalLine*350+350);

        for (int i = 0; i < curList.Count; i++)
        {
            itemPool[i].transform.localPosition = new Vector3(200+ i%lineNum * 250,-200+ i/lineNum * -320,0);
            itemPool[i].SetItem(curList[i]);
        }
    }

    List<Good> GetChooseGoodList(GoodType gType)
    {
        List<Good> tempGoodList = new List<Good>();
        if (gType == GoodType.All)
        {
            tempGoodList.AddRange(GameMrg.mInstance.allGoodList);
        }
        else
        {
            for (int i = 0; i < GameMrg.mInstance.allGoodList.Count; i++)
            {
                Good curGood = GameMrg.mInstance.allGoodList[i];
                if (curGood.type == gType)
                {
                    tempGoodList.Add(curGood);
                }
            }
        }
        return tempGoodList;
    }
}
