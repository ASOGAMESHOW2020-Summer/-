using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkButton : MonoBehaviour
{
    public enum MonkButtonState
    {
        Select,
        NoSelect
    };
    private MonkButtonState monkButtonState;
    [SerializeField]
    private GameObject Monk;
    [SerializeField]
    private GameObject CharacterButton;
    private Animator animator;
    public static bool MonkFlag = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        Monk = GameObject.Find("僧侶");
        MonkFlag = false;
    }

    void Update()
    {
        if(monkButtonState == MonkButtonState.Select)
        {
            if(Input.GetKeyDown("joystick button 0"))
            {
                //MonkFlag = true;
                //Monk.SetActive(true);
            }
        }
    }

    public void OnClick()
    {
        MonkFlag = true;
        Monk.SetActive(true);
    }
}
