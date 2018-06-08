using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        transParent.sizeDelta = new Vector2(1530+(sControl.taskList.Count-3)*500,532);
        for (int i = 0; i < sControl.taskList.Count; i++) {
            GameObject objItem = Instantiate(taskTemplate.gameObject) as GameObject;
            objItem.SetActive(true);
            objItem.transform.parent = transParent.transform;
            objItem.transform.localPosition = new Vector3(178+500*i,0,0);
            //objItem.transform.localScale = Vector3.one;
            itemList.Add(objItem.GetComponent<ChooseItem>());
        }
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
