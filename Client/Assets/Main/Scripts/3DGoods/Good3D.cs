using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Good3D : MonoBehaviour {
	public GameObject moveObj;
	//public bool isBuy = false;
	public Good goodInfo;
	// Use this for initialization
	void Start () {
		int tempIndex = int.Parse (gameObject.name);
		goodInfo = GameMrg.mInstance.allGoodList[tempIndex-1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
