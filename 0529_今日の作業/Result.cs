using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameSystem.isClear == true)
        {
            SceneMnager.LoadScene("Clear");
        }
        else if(SamuraiState == SamuraiMoveScript.SamuraiState.Dead
        && (MonkState == MonkMoveScript.MonkState.Dead)
        && (OnmyojiState == OnmyojiMoveScript.OnmyojiState.Dead)
        && (ThiefState == ThiefMoveScript.ThiefState.Dead))
        {
            GameSystem.isFailed == true;
            SceneManager.LoadScene("Failed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
