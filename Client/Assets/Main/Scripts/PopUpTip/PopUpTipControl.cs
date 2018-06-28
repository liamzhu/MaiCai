using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void ClickEvent();

public class PopUpTipControl : MonoBehaviour {
    public Text tipTxt;
    public Button btnOK;
    public Button btnNo;

    ClickEvent clickYes;
    ClickEvent clickNo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetShow(string tip,ClickEvent eventYes = null,ClickEvent eventNo = null) {
        tipTxt.text = tip;
        clickYes = eventYes;
        clickNo = eventNo;
        btnOK.gameObject.SetActive(false);
        btnNo.gameObject.SetActive(false);
        if (eventYes != null && eventNo != null)
        {
            btnOK.gameObject.SetActive(true);
            btnNo.gameObject.SetActive(true);
            btnOK.transform.localPosition = new Vector3(-120, -127, 0);
            btnNo.transform.localPosition = new Vector3(120, -127, 0);
        }
        else {
            btnOK.gameObject.SetActive(true);
            btnOK.transform.localPosition = new Vector3(0, -127, 0);
        }
    }

    public void ClickYes() {
        Destroy(gameObject);
        if (clickYes != null) {
            clickYes();
        }
    }

    public void ClickNo() {
        Destroy(gameObject);
        if (clickNo != null)
        {
            clickNo();
        }
    }

}
