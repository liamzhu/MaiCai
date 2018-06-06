using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginControl : MonoBehaviour {

    public GameObject uppercase;
    public Text erroTip;
    public InputField userNameInput;
    public InputField passWordInput;

    [DllImport("user32.dll", EntryPoint = "GetKeyboardState")]
    public static extern int GetKeyboardState(byte[] pbKeyState);

    public static bool CapsLockStatus
    {
        get
        {
            byte[] bs = new byte[256];
            GetKeyboardState(bs);
            return (bs[0x14] == 1);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //if (userNameInput)
            //{
            //    userNameInput.isSelected = false;
            //    passWordInput.isSelected = true;
            //}
            //else
            //{
            //    userNameInput.isSelected = true;
            //    passWordInput.isSelected = false;
            //}
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ClickLogin();
        }

        if (CapsLockStatus)
        {
            uppercase.SetActive(true);
        }
        else
        {
            uppercase.SetActive(false);
        }
    }

    public void ClickLogin() {
        if (userNameInput.text == string.Empty)
        {
            erroTip.gameObject.SetActive(true);
            erroTip.text = "请输入用户名！";
        }
        else if (passWordInput.text == string.Empty)
        {
            erroTip.gameObject.SetActive(true);
            erroTip.text = "请输入密码！";
        }
        else
        {
            if (GameMrg.mInstance.isNet)
            {
                StartCoroutine(Login());
                GameMrg.mInstance.LoadPopUpLoading();
            }
            else
            {
                SceneManager.LoadScene("Select");
            }
        }
    }

    public IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", userNameInput.text);
        form.AddField("password", passWordInput.text);
        form.AddField("version", "1.0");

        WWW www_data = new WWW(GameMrg.mInstance.shareUrl + GameMrg.mInstance.loginURL, form);
        yield return www_data;
        Debug.Log(www_data.text);
        ParseReStr(www_data.text);
        GameMrg.mInstance.StopLoading();
    }

    string tempURL = string.Empty;
    //解析返回的字符串
    void ParseReStr(string reStr)
    {
        if (reStr == string.Empty)
        {
            //GameManager.Instance.LoadPopUpTip("请检查网络连接！", transform, true, null, null);
            return;
        }

        //LoginBack mLoginBack = LitJson.JsonMapper.ToObject<LoginBack>(reStr);
        //if (mLoginBack.update)
        //{//有更新
        //    GameManager.Instance.LoadPopUpTip("发现新版本，请前往更新！", transform.parent.transform, true, ClickUpdate, null);
        //    tempURL = mLoginBack.list;
        //}
        //else
        //{
        //    if (mLoginBack.userInfo.UserID == null)
        //    {
        //        errTipLabel.gameObject.SetActive(true);
        //        errTipLabel.text = "登录失败，用户名或密码不正确！";
        //    }
        //    else
        //    {
        //        //Debug.Log(userBaseInfo.UsersOID);
        //        GameManager.Instance.userBaseInfo = mLoginBack.userInfo;
        //        //GameManager.Instance.userBaseInfo.UserSex = "0";
        //        //跳转下一场景
        //        Application.LoadLevel("Select");
        //    }
        //}
    }


    public void ClickOnRegister() {
        Application.OpenURL("www.baidu.com");
    }

    public void ClickOnGetPass() {
        Application.OpenURL("www.sougou.com");
    }
}
