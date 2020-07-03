/*シーン遷移スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackModeSelect : MonoBehaviour
{
   public void OnClick()
   {
        SceneManager.LoadScene("ModeSelect");
   }
}
