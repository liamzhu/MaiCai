using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRenWu : MonoBehaviour {
    SelectControl sControl;

    public ChooseItem taskTemplate;
    public RectTransform transParent;

    List<ChooseItem> itemList = new List<ChooseItem>();
	// Use this for initialization
	void Start () {
        sControl = transform.parent.GetComponent<SelectControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitTaskList() {
        transParent.localPosition = new Vector3(0,0,0);
        transParent.sizeDelta = new Vector2(1580+(sControl.taskList.Count-3)*600,532);
        for (int i = 0; i < sControl.taskList.Count; i++) {
            GameObject objItem = Instantiate(taskTemplate.gameObject) as GameObject;
            objItem.SetActive(true);
            //objItem.transform.parent = transParent.transform;
			objItem.transform.SetParent(transParent.transform);
            objItem.transform.localPosition = new Vector3(50+600*i,0,0);
            //objItem.transform.localScale = Vector3.one;
            itemList.Add(objItem.GetComponent<ChooseItem>());
			objItem.GetComponentInChildren<Text> ().text = "任务" + (i + 1).ToString ();
        }

		itemList [0].objSelect.SetActive (true);
    }

    public void ClickNext()
    {
        sControl.sRenWu.gameObject.SetActive(false);
        sControl.sChangJing.gameObject.SetActive(true);

        int curChooseIndex = 0;
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].objSelect.activeSelf)
            {
                curChooseIndex = i;
                break;
            }
        }
        //设置当前任务
        GameMrg.mInstance.curTask = sControl.taskList[curChooseIndex];
    }
}
