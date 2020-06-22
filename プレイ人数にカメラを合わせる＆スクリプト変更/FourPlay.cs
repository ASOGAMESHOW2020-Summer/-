using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FourPlay : MonoBehaviour
{
    public static bool FourFlag = false;

    void Start()
    {
        DontDestroyOnLoad(this);
        FourFlag = false;
    }

    public void OnClick()
    {
        FourFlag = true;
        SceneManager.LoadScene("FourCharacterSelect");
    }

}
