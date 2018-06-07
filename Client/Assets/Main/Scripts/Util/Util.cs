using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util{

    public static int[] GetRandomSequence(int total, int n)
    {
        //随机总数组  
        int[] sequence = new int[total];
        //取到的不重复数字的数组长度  
        int[] output = new int[n];
        for (int i = 0; i < total; i++)
        {
            sequence[i] = i;
        }
        int end = total - 1;
        for (int i = 0; i < n; i++)
        {
            //随机一个数，每随机一次，随机区间-1  
            int num = Random.Range(0, end + 1);
            output[i] = sequence[num];
            //将区间最后一个数赋值到取到数上  
            sequence[num] = sequence[end];
            end--;
            //执行一次效果如：1，2，3，4，5 取到2  
            //则下次随机区间变为1,5,3,4;  
        }
        return output;
    }
}
