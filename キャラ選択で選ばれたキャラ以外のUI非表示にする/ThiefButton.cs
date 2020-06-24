using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefButton : MonoBehaviour
{
    public enum ThiefButtonState
    {
        Select,
        NoSelect
    };
    private ThiefButtonState thiefButtonState;
    [SerializeField]
    private GameObject Thief;
    [SerializeField]
    private GameObject CharacterButton;
    private Animator animator;
    public static bool ThiefFlag = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        Thief = GameObject.Find("盗賊");
        ThiefFlag = false;
    }

    void Update()
    {
        if (thiefButtonState == ThiefButtonState.Select)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                //ThiefFlag = true;
                //Thief.SetActive(true);
            }
        }
    }

    public void OnClick()
    {
        ThiefFlag = true;
        Thief.SetActive(true);
    }
}
