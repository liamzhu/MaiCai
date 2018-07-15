using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public static PlayerControl instance;
    float speed = 1.0f;
	public Animator animator;

	public Transform [] transPos; //最多16个位置
	public GameObject cartDetail;

	public Good3D[] good3DArray;

	List<Good3DCopy> copyGoodList = new List<Good3DCopy>();

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("IsMove",false);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {//前
            transform.position += transform.forward * speed*Time.deltaTime;
			animator.SetBool ("IsMove",true);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))//后
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
			animator.SetBool ("IsMove",true);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//左
        {
            transform.eulerAngles -= new Vector3(0,50*Time.deltaTime,0);
			animator.SetBool ("IsMove",true);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//右
        {
            transform.eulerAngles += new Vector3(0, 50 * Time.deltaTime, 0);
			animator.SetBool ("IsMove",true);
        }

		ChooseGood ();
    }

	void ChooseGood(){
		if (Input.GetMouseButtonDown (0)) {
			if(cartDetail.activeSelf)
			{
				return;
			}
			RaycastHit hitInfo;
			// Create a ray from mouse coords
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// Targeting raycast
			if (Physics.Raycast(ray, out hitInfo))
			{
				// Cache what we've hit
				Good3D good = hitInfo.collider.transform.parent.GetComponent<Good3D>();
				if (good != null) {
					Debug.Log ("选中的物品 = "+good.gameObject.name);
					Debug.Log ("选中的名字 = "+good.goodInfo.name);
					PutGoodInCart (good);
				}
			}
		}
	}

	void PutGoodInCart(Good3D good){
		if (GameMrg.mInstance.curBuyGoodList.Contains(good.goodInfo)) {
			GameMrg.mInstance.LoadPopUpTip ("已经购买了！");
			return;
		}

		if (GameMrg.mInstance.curBuyGoodList.Count >= GameMrg.mInstance.curTask.goodList.Count) {
			GameMrg.mInstance.LoadPopUpTip("已达购买最大数目限制");
			return;
		}

		GameMrg.mInstance.curBuyGoodList.Add (good.goodInfo);

		if (good.moveObj == null) {
			return;
		}

		//复制一个放在购物车中
		GameObject copyObj = Instantiate (good.moveObj) as GameObject;
		copyObj.transform.parent = transPos [0].parent;
		copyObj.transform.localPosition = transPos [GameMrg.mInstance.curBuyGoodList.Count - 1].localPosition;

		Good3DCopy goodCopy = copyObj.AddComponent<Good3DCopy> ();
		goodCopy.good3d = good;
		copyGoodList.Add (goodCopy);

		//隐藏货架上的物品
		good.moveObj.SetActive(false);
	}

	public void RemoveGood3D(Good goodInfo){
		//查找对应的good3d
		Good3D curGood3d = null;
		for(int i = 0; i < good3DArray.Length; i++){
			if (good3DArray [i].goodInfo == goodInfo) {
				curGood3d = good3DArray [i];
				break;
			}
		}

		if (curGood3d == null) {
			Debug.Log ("删除的物品在商店中未找到！");
			return;
		}

		//还原显示货架上的物品
		if(curGood3d.moveObj != null){
			curGood3d.moveObj.SetActive (true);
		}

		Good3DCopy desCy = null;
		for (int i = 0; i < copyGoodList.Count; i++) {
			if (copyGoodList [i].good3d == curGood3d) {
				desCy = copyGoodList[i];
				break;
			}
		}

		if (desCy != null) {
			Destroy (desCy.gameObject);
		}
	}
}
