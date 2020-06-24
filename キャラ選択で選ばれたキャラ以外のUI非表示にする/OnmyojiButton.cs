using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnmyojiButton : MonoBehaviour
{
    public enum OnmyojiButtonState
    {
        Select,
        NoSelect
    };
    private OnmyojiButtonState onmyojiButtonState;
    [SerializeField]
    private GameObject Onmyoji;
    [SerializeField]
    private GameObject CharacterButton;
    private Animator animator;
    public static bool OnmyojiFlag = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        Onmyoji = GameObject.Find("陰陽師");
        OnmyojiFlag = false;
    }

  
    void Update()
    {
        if (onmyojiButtonState == OnmyojiButtonState.Select)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                //OnmyojiFlag = true;
                //Onmyoji.SetActive(true);
            }
        }
    }

    public void OnClick()
    {
        OnmyojiFlag = true;
        Onmyoji.SetActive(true);
    }
}
