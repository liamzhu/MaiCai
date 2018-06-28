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

    public List<Good> allGoodList = new List<Good>();
    public Task curTask = null;
    public List<Good> curBuyGoodList = new List<Good>();

    public bool isNet = true;

    private void Awake()
    {
        mInstance = this;
        ReadConfigByTxt();
        CreateGoodLibrary();    //初始化物品库
        DontDestroyOnLoad(gameObject);
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
        //objLoading.transform.parent = GameObject.Find("UI Root").transform;
        objLoading.transform.localScale = Vector3.one;
        objLoading.transform.localPosition = Vector3.zero;
    }

    public void StopLoading()
    {
        Destroy(objLoading);
    }

    public void LoadPopUpTip(string tip, ClickEvent eventYes = null, ClickEvent eventNo = null) {
        string tempStr = "Prefab/PopUpTip";
        GameObject tempObj = Resources.Load(tempStr) as GameObject;
        GameObject objTip = Instantiate(tempObj) as GameObject;
        //objLoading.transform.parent = GameObject.Find("UI Root").transform;
        objTip.transform.localScale = Vector3.one;
        objTip.transform.localPosition = Vector3.zero;
        objTip.GetComponent<PopUpTipControl>().SetShow(tip, eventYes, eventNo);
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

    //检查正确率
    public float CheckResult() {
        int totalNum = curTask.goodList.Count;
        int rightNum = 0;
        for (int i = 0; i < totalNum; i++) {
            Good desGood = curTask.goodList[i];
            for (int j = 0; j < curBuyGoodList.Count; j++) {
                Good buyGood = curBuyGoodList[j];
                if (desGood.name == buyGood.name) {
                    rightNum++;
                    break;
                }
            }
        }

        float result = (float)rightNum / (float)totalNum;
        return result;
    }

    void CreateGoodLibrary() {
        {
            allGoodList.Add(new Good(GoodType.Fruit, "苹果"));
            allGoodList.Add(new Good(GoodType.Fruit, "杏子"));
            allGoodList.Add(new Good(GoodType.Fruit, "香蕉"));
            allGoodList.Add(new Good(GoodType.Fruit, "橙子"));
            allGoodList.Add(new Good(GoodType.Fruit, "草莓"));
            allGoodList.Add(new Good(GoodType.Fruit, "杨桃"));
        }
        {
            allGoodList.Add(new Good(GoodType.Meat, "牛肉"));
            allGoodList.Add(new Good(GoodType.Meat, "牛排"));
            allGoodList.Add(new Good(GoodType.Meat, "牛尾"));
            allGoodList.Add(new Good(GoodType.Meat, "猪腿"));
            allGoodList.Add(new Good(GoodType.Meat, "猪肉"));
            allGoodList.Add(new Good(GoodType.Meat, "猪排"));
        }
        {
            allGoodList.Add(new Good(GoodType.PoultryEgg, "鸡"));
            allGoodList.Add(new Good(GoodType.PoultryEgg, "鸭"));
            allGoodList.Add(new Good(GoodType.PoultryEgg, "鹅"));
        }
    }
}
