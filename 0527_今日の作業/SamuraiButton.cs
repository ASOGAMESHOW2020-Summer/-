using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiButton : MonoBehaviour
{
    [SerializeFiled]
    public GameObject Samurai;
    // Start is called before the first frame update
    void Start()
    {
        Samurai = GameObject.Find("侍");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
