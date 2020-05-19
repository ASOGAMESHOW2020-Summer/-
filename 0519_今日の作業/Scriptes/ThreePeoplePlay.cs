using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThreePeoplePlay : MonoBehaviour
{
    public void Onclick()
    {
        //ここで移りたいシーンを指定
        SceneManager.LoadScene("ThreePeoplePlayCharSelect");
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
