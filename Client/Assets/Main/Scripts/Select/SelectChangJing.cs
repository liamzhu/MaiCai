using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectChangJing : MonoBehaviour {

    SelectControl sControl;

    public ChooseItem changJing1;       //超市
    public SelectChooseTool sChooseTool;
    public ChooseItem changJing2;       //网购

    // Use this for initialization
    void Start () {
        sControl = transform.parent.GetComponent<SelectControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickOnEnter(){
		if (changJing1.objSelect.activeSelf) {
            sChooseTool.gameObject.SetActive(true);
        } 
		else {
			SceneManager.LoadScene("WebBuy");
		}
	}
}
