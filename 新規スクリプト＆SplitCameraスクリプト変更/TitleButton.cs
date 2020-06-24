using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
   public void OnClickTitleButoon()
   {
        SceneManager.LoadScene("Title");
   }
}
