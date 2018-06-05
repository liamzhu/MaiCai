using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class LoginControl : MonoBehaviour {

    public GameObject uppercase;
    public GameObject erroTip;
    public Input userNameInput;
    public Input passWordInput;

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

    }

    public void ClickOnRegister() {

    }

    public void ClickOnGetPass() {

    }
}
