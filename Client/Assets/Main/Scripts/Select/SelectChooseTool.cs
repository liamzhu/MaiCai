using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectChooseTool : MonoBehaviour {
    public Toggle car;
    public Toggle basket;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickOnClose() {
        gameObject.SetActive(false);
    }

    public void ClickOnEnter() {
        if (car.isOn)
        {

        }
        else if (basket.isOn) {

        }
        SceneManager.LoadScene("Market");
    }
}
