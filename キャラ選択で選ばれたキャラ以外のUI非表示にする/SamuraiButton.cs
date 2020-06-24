using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiButton : MonoBehaviour
{
    public enum SamuraiButtonState
    {
        Select,
        NoSelect
    };
    private SamuraiButtonState samuraiButtonState;
    private Animator animator;
    [SerializeField]
    private GameObject Samurai;
    [SerializeField]
    private GameObject CharacterButton;
    public static bool SamuraiFlag = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        Samurai = GameObject.Find("侍");
        SamuraiFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(samuraiButtonState == SamuraiButtonState.Select)
        {
            if(Input.GetKeyDown("joystick button 0"))
            {
                //SamuraiFlag = true;
                //Samurai.SetActive(true);
            }
        }
    }

    public void OnClick()
    {
        SamuraiFlag = true;
        Samurai.SetActive(true);
    }
}
