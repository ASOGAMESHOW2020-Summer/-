using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkButton : MonoBehaviour
{
    [SerializeFiled]
    public GameObject Monk;

    [SerializeFiled]
    public GameObjet PlayerButton3;

    public void OnClick()
    {
        Monk = GameObject.Find("僧侶");
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
