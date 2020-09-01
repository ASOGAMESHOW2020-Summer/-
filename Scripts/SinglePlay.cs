/*シーン遷移スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SinglePlay : MonoBehaviour
{
    public static bool SingleFlag = false;

	void Start()
    {
        //シーンが切り替わってもオブジェクトを削除しない
        DontDestroyOnLoad(this);
        SingleFlag = false;
	}

    public void OnClick()
    {
        SingleFlag = true;
		SceneManager.LoadScene("SingleCharacterSelect");
    }

	//　マウスアイコンが自分のアイコン上に入った時
	void OnTriggerEnter2D(Collider2D col)
	{
		CheckEvent(col);
	}

	//　マウスアイコンが自分のアイコン上にいる間
	void OnTriggerStay2D(Collider2D col)
	{
		CheckEvent(col);
	}

	void CheckEvent(Collider2D col)
	{
		//　アイコンを検知する
		if (col.tag == "Icon")
		{
			if (EventSystem.current.currentSelectedGameObject == null)
			{
				//　このUIをフォーカスする
				EventSystem.current.SetSelectedGameObject(gameObject);

			}
			if (Input.GetButtonDown("Submit"))
			{
				OnClick();
			}
		}
	}

	//　マウスアイコンが自分のアイコン上から出て行った時
	void OnTriggerExit2D(Collider2D col)
	{

		if (col.tag == "Icon")
		{
			//　フォーカスを解除する
			EventSystem.current.SetSelectedGameObject(null);
		}
	}
}