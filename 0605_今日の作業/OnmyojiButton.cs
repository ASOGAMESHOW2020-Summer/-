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
    [SerializeFiled]
    public GameObject Onmyoji;

    [SerializeFiled]
    public GameObject PlayerButton1;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Onmyoji = GameObject.Find("陰陽師");
    }

    // Update is called once per frame
    void Update()
    {
        if (onmyojiButtonState == OnmyojiButtonState.Select)
        {
            if (Input.GetKeyDown("jotstickbutton 3"))
            {
                Onmyoji.SetActive(true);
            }

        }
    }
}
