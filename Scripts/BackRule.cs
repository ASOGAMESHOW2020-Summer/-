using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BackRule : MonoBehaviour
{
	public void OnclickBackRuleButton()
	{
		SceneManager.LoadScene("Rule");
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
				OnclickBackRuleButton();
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
