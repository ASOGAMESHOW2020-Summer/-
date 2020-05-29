using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnmyojiButton : MonoBehaviour
{
    [SerializeFiled]
    public GameObject Onmyoji;

    [SerializeFiled]
    public GameObject PlayerButton1;

    public void OnClick()
    {
        Onmyoji = GameObject.Find("陰陽師");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
