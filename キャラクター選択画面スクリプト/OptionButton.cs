using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionButton : MonoBehaviour
{
    public void OnclickOptionButton()
    {
        SceneManager.LoadScene("Option");
    }
}
