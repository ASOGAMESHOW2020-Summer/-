/*プレイヤーUI表示スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    [SerializeField]
    Image img;

    void Awake()
    {
        img = GetComponent<Image>();
        img.color = Color.clear;
    }


    public void ImgFlash(bool flag)
    {
        if (flag == true)
        {
            //徐々に赤色にする
            this.img.color = Color.Lerp(this.img.color, Color.red, Time.deltaTime);
        }
        else if (flag == false)
        {
            //徐々に透明にする
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);

        }
    }

    public void ColorClear()
    {
        this.img.color = Color.clear;
    }
}
