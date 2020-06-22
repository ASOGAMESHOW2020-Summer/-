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

    void Start()
    {
        animator = GetComponent<Animator>();
        Monk = GameObject.Find("僧侶");
    }

    void Update()
    {
        if(monkButtonState == MonkButtonState.Select)
        {
            if(Input.GetKeyDown("joystick button 0"))
            {
                Monk.SetActive(true);
            }
        }
    }
}
