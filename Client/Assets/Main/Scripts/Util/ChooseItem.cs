using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseItem : MonoBehaviour {
    public GameObject objSelect;
    ChooseItem[] chooseItems;

	// Use this for initialization
	void Start () {
        chooseItems = transform.parent.GetComponentsInChildren<ChooseItem>();
        GetComponent<Button>().onClick.AddListener(ClickChoose);
    }
	
	// Update is called once per frame
	void Update () {
    
	}

    public void ClickChoose()
    {
        if (objSelect.activeSelf)
        {
            return;
        }
        for (int i = 0; i < chooseItems.Length; i++)
        {
            chooseItems[i].objSelect.SetActive(false);
        }
        objSelect.SetActive(true);
    }
}
