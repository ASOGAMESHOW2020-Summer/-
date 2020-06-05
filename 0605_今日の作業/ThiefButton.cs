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

    //盗人を格納する
    [SerializeFiled]
    public GameObject Thief;
    [SerializeFiled]
    public GameObject CharacterButton2;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<animator>();
        Thief = GameObject.Find("盗人");
    }

    // Update is called once per frame
    void Update()
    {
        if (thiefButtonState == ThiefButtonState.Select)
        {
            if (Input.GetKeyDown("jotstickbutton 3"))
            {
                Thief.SetActive(true);
            }

        }
    }
}
