using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChangJing : MonoBehaviour {

    SelectControl sControl;

    public ChooseItem changJing1;       //超市
    public ChooseItem changJing2;       //网购

    // Use this for initialization
    void Start () {
        sControl = transform.parent.GetComponent<SelectControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
