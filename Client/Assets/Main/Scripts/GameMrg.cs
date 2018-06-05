using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameMrg : MonoBehaviour {
    public static GameMrg mInstance;

    public string shareUrl = string.Empty;
    public string loginURL = string.Empty;                                                          //登陆
    public string registURL = string.Empty;                                                         //注册
    public string forgetPassWordURL = string.Empty;                                                 //忘记密码

    private void Awake()
    {
        mInstance = this;
        ReadConfigByTxt();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    GameObject objLoading = null;
    public void LoadPopUpLoading()
    {
        string tempStr = "Prefab/Loading";
        GameObject tempObj = Resources.Load(tempStr) as GameObject;
        objLoading = Instantiate(tempObj) as GameObject;
        objLoading.transform.parent = GameObject.Find("UI Root").transform;
        objLoading.transform.localScale = Vector3.one;
        objLoading.transform.localPosition = Vector3.zero;
    }

    public void StopLoading()
    {
        Destroy(objLoading);
    }

    public void ReadConfigByTxt()
    {
        StreamReader sr = File.OpenText(Application.streamingAssetsPath + "/config.txt");
        string line;
        ArrayList arrlist = new ArrayList();
        while ((line = sr.ReadLine()) != null)
        {
            arrlist.Add(line);
        }

        {
            string tempStr = arrlist[0].ToString();
            int tempInt = tempStr.IndexOf("\t");
            shareUrl = tempStr.Substring(0, tempInt);
            Debug.Log("shareURL " + tempStr.Substring(0, tempInt));
        }
        {
            string tempStr = arrlist[1].ToString();
            int tempInt = tempStr.IndexOf("\t");
            loginURL = tempStr.Substring(0, tempInt);
        }
        {
            string tempStr = arrlist[2].ToString();
            int tempInt = tempStr.IndexOf("\t");
            registURL = tempStr.Substring(0, tempInt);
        }
        {
            string tempStr = arrlist[3].ToString();
            int tempInt = tempStr.IndexOf("\t");
            forgetPassWordURL = tempStr.Substring(0, tempInt);
        }
    }
}
