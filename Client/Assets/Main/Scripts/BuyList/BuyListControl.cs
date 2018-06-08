using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyListControl : MonoBehaviour {

    public GameObject objTemplate;
    public RectTransform transParent;

	// Use this for initialization
	void Start () {
        transParent.localPosition = Vector3.zero;
        transParent.sizeDelta = new Vector2(780,600+(GameMrg.mInstance.curTask.goodList.Count-4)*140);
        for (int i = 0; i < GameMrg.mInstance.curTask.goodList.Count; i++) {
            GameObject curObj = Instantiate(objTemplate) as GameObject;
            curObj.SetActive(true);
            curObj.transform.parent = transParent.transform;
            curObj.transform.localPosition = new Vector3(212,-80-140*i,0);

            curObj.GetComponent<BuyListItem>().SetGood(GameMrg.mInstance.curTask.goodList[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
