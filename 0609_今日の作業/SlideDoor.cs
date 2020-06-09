using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    //鍵
    [SerializeField]
    private Key KeyScript;
    [SerializeField]
    private Key KeyScript2;
    [SerializeField]
    private Key KeyScript3;
    [SerializeField]
    private GameObject[] KeyObj;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        KeyObj[0] = GameObject.Find("鍵");
        KeyScript = KeyObj[0].GetComponent<Key>();
        KeyObj[1] = GameObject.Find("鍵2");
        KeyScript2 = KeyObj[1].GetComponent<Key2>();
        KeyObj[2] = GameObject.Find("鍵3");
        KeyScript3 = KeyObj[2].GetComponent<Key3>();

        animator = GetComponent<animator>();
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoorOpen();
    }

    void DoorOpen()
    {
        var key1 = KeyScript.GetKeyFlag();
        var key2 = KeyScript2.GetKeyFlag();
        var key3 = KeyScript3.GetKeyFlag();

        if((key1==true)&&(key2==true)&&(key3==true))
        {
            animator.enabled = true;
            animator.Play("SlideDoor");
        }
    }
}
