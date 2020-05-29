using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiButton : MonoBehaviour
{
    [SerializeFiled]
    public GameObject Samurai;

    [SerializeFiled]
    public GameObject PlayerButton;

    // Start is called before the first frame update
    void Start()
    {
        if (OnClick.PlayerButton==true)
        {
            Samurai = GameObject.Find("侍");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
