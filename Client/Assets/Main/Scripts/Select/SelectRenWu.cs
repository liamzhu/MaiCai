using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRenWu : MonoBehaviour {

    SelectControl sControl;
    public ChooseItem taskTemplate;

	// Use this for initialization
	void Start () {
        sControl = transform.parent.GetComponent<SelectControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickNext()
    {
        sControl.sRenWu.gameObject.SetActive(false);
        sControl.sChangJing.gameObject.SetActive(true);
    }
}
