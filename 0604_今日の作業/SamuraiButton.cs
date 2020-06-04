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
    private CharacterButton characterButton;

    private Animator animator;

    [SerializeFiled]
    public GameObject Samurai;

    [SerializeFiled]
    public GameObject PlayerButton;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<animator>();
        if (OnClick.PlayerButton==true)
        {
            Samurai = GetComponent<CharacterSelect>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
