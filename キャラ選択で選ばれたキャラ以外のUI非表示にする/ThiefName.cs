using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThiefName : MonoBehaviour
{
    [SerializeField]
    private Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }


    void Update()
    {
        if (ThiefButton.ThiefFlag == true)
        {
            text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
        else if (ThiefButton.ThiefFlag == false)
        {
            text.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
