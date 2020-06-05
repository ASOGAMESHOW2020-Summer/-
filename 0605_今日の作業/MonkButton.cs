using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkButton : MonoBehaviour
{
    public enum MonhButtonState
    {
        Select,
        NoSelect
    };
    private MonkButtonState monkButtonState;
    [SerializeFiled]
    public GameObject Monk;

    [SerializeFiled]
    public GameObjet CharacterButton3;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<animator>()+
        Monk = GameObject.Find("僧侶");
    }

    // Update is called once per frame
    void Update()
    {
        if (monkButtonState == MonkButtonState.Select)
        {
            if (Input.GetKeyDown("jotstickbutton 3"))
            {
                Samurai.SetActive(true);
            }

        }
    }
}
