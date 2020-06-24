using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamuraiName : MonoBehaviour
{
    [SerializeField]
    private Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }


    void Update()
    {
        if(SamuraiButton.SamuraiFlag == true)
        {
            text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
        else if(SamuraiButton.SamuraiFlag == false)
        {
            text.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
