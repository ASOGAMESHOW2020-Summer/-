using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToriiRandomPosition : MonoBehaviour
{
    //ランダム範囲
    [Header("入力した値の間のランダム値をX座標にする")]
    [SerializeField]
    float Xmin, Xmax;
    [Header("入力した値の間のランダム値をY座標にする")]
    [SerializeField]
    float Ymin, Ymax;
    [Header("入力した値の間のランダム値をZ座標にする")]
    [SerializeField]
    float Zmin, Zmax;
    // Start is called before the first frame update
    void Start()
    {
        var x = Random.Range(Xmin, Xmax);
        var y = Random.Range(Ymin, Ymax);
        var z = Random.Range(Zmin, Zmax);
        var randomPosition = new Vector3(x, y, z);
        transform.position = randomPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
