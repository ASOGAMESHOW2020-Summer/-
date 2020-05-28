using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameSystem.isClear==true)
        {
            SceneMnager.LoadScene("Clear");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
