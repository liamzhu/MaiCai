using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectControl : MonoBehaviour {

    public SelectRenWu sRenWu;
    public SelectChangJing sChangJing;

    public List<Task> taskList = null;

	// Use this for initialization
	void Start () {
        taskList = CreateTask();
        sRenWu.InitTaskList();

		GameMrg.mInstance.curBuyGoodList.Clear();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 创建任务
    /// </summary>
    /// <returns></returns>
    List<Task> CreateTask()
    {
        List<Task> taskList = new List<Task>();

        {
            Task task = new Task();
            int[] randArray = Util.GetRandomSequence(GameMrg.mInstance.allGoodList.Count, 5);
            for (int i = 0; i < randArray.Length; i++)
            {
                task.goodList.Add(GameMrg.mInstance.allGoodList[randArray[i]]);
            }
            taskList.Add(task);
        }

        {
            Task task = new Task();
            int[] randArray = Util.GetRandomSequence(GameMrg.mInstance.allGoodList.Count, 7);
            for (int i = 0; i < randArray.Length; i++)
            {
                task.goodList.Add(GameMrg.mInstance.allGoodList[randArray[i]]);
            }
            taskList.Add(task);
        }

        {
            Task task = new Task();
            int[] randArray = Util.GetRandomSequence(GameMrg.mInstance.allGoodList.Count, 9);
            for (int i = 0; i < randArray.Length; i++)
            {
                task.goodList.Add(GameMrg.mInstance.allGoodList[randArray[i]]);
            }
            taskList.Add(task);
        }

        {
            Task task = new Task();
            int[] randArray = Util.GetRandomSequence(GameMrg.mInstance.allGoodList.Count, 11);
            for (int i = 0; i < randArray.Length; i++)
            {
                task.goodList.Add(GameMrg.mInstance.allGoodList[randArray[i]]);
            }
            taskList.Add(task);
        }
        return taskList;
    }
}
