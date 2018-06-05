using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingControl : MonoBehaviour {

	public Text loadLabel;

	int index = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine(WaitToTimeOut(30.0f));
	}

    IEnumerator WaitToTimeOut(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameMrg.mInstance.StopLoading();
        //GameMrg.mInstance.LoadPopUpTip("请求超时，请检查网络！", transform, true, null, null);
    }

    // Update is called once per frame
    void FixedUpdate () {
		if(Time.frameCount % 10 != 0){
			return;
		}
		index++;
		if(index == 4){
			index = 0;
		}

		if(index == 0){
			loadLabel.text = "Loading";
		}
		else if(index == 1){
			loadLabel.text = "Loading.";
		}
		else if(index == 2){
			loadLabel.text = "Loading..";
		}
		else if(index == 3){
			loadLabel.text = "Loading...";
		}
	}
}
