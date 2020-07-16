using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApperanceKey : MonoBehaviour
{
    //オブジェクトを格納する変数
    [SerializeField]
    public GameObject[] Keys;
    //最大数
    [SerializeField]
    private int MaxKeys;
    //キーが出現した数
    [SerializeField]
    private int KeyNum;
    
    void Start()
    {
        KeyNum = 0;
    }

    void Update()
    {
        if (KeyNum >= MaxKeys)
        {
            return;
        }
        AppearKey();
    }

    //　鍵出現メソッド
    void AppearKey()
    {
        var x = Random.Range(-25,25);
        var y = Random.Range(0, 1);
        var z = Random.Range(-25, 25);
        var randomPosition = new Vector3(x,y,z);
        //　鍵の向きをランダムに決定
        var randomRotationY = Random.value * 360f;
        GameObject.Instantiate(Keys[KeyNum], randomPosition, Quaternion.Euler(0f, randomRotationY, 0f));
        KeyNum++;
    }
}
