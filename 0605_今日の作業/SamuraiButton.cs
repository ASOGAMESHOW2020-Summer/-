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

    [SerializeFiled]
    public GameObject Samurai;

    [SerializeFiled]
    public GameObject CharacterButton;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<animator>();
        
        Samurai = GameObject.Find("侍");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(samuraiButtonState==SamuraiButtonState.Select)
        {
            if(Input.GetKeyDown("jotstickbutton 3"))
            {
                Samurai.SetActive(true);
            }
           
        }
    }
  
}
