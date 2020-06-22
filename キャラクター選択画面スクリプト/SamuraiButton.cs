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

    void Start()
    {
        animator = GetComponent<Animator>();
        Samurai = GameObject.Find("侍");
    }

    // Update is called once per frame
    void Update()
    {
        if(samuraiButtonState == SamuraiButtonState.Select)
        {
            if(Input.GetKeyDown("joystick button 0"))
            {
                Samurai.SetActive(true);
            }
        }
    }
}
