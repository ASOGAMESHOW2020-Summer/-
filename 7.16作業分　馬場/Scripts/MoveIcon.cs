/*カーソルアイコンの移動処理*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveIcon : MonoBehaviour
{
	//アイコンの速度
	private const int speed = 500;
	//　アイコンが1秒間に何ピクセル移動するか
	[SerializeField]
	private float iconSpeed = speed;
	//　アイコンのサイズ取得で使用
	private RectTransform rect;
	//　アイコンが画面内に収まる為のオフセット値
	private Vector2 offset;
	//画面サイズ
	private const int Screen_W = 1920, Screen_H = 1080;
	///<summary>
	///使用するInputKey名を入れる
	///</summary>
	[SerializeField]
	private string horizontalString;
	[SerializeField]
	private string verticalString;
	//Imageを入れるオブジェクト
	//[SerializeField]
	//private GameObject IconImg1;
	//[SerializeField]
	//private MoveIcon icon1;
	//[SerializeField]
	//private GameObject IconImg2;
	//[SerializeField]
	//private MoveIcon icon2;
	//[SerializeField]
	//private GameObject IconImg3;
	//[SerializeField]
	//private MoveIcon icon3;
	//[SerializeField]
	//private GameObject IconImg4;
	//[SerializeField]
	//private MoveIcon icon4;

	void Start()
	{
		rect = GetComponent<RectTransform>();
		//　オフセット値をアイコンのサイズの半分で設定
		offset = new Vector2(rect.sizeDelta.x / 2f, rect.sizeDelta.y / 2f);
	}

	void Update()
	{
		if (GamePadConnectNum.pad1 == true)
		{
			//　移動キーを押していなければ何もしない
			if (Mathf.Approximately(Input.GetAxis(horizontalString), 0f) && Mathf.Approximately(Input.GetAxis(verticalString), 0f))
			{
				return;
			}
			//　移動先を計算
			var pos = rect.anchoredPosition + new Vector2(Input.GetAxis(horizontalString) * iconSpeed, Input.GetAxis(verticalString) * iconSpeed) * Time.deltaTime;

			//　アイコンが画面外に出ないようにする
			pos.x = Mathf.Clamp(pos.x, -Screen_W * 0.5f + offset.x, Screen_W * 0.5f - offset.x);
			pos.y = Mathf.Clamp(pos.y, -Screen_H * 0.5f + offset.y, Screen_H * 0.5f - offset.y);
			//　アイコン位置を設定
			rect.anchoredPosition = pos;
		}
		else if(GamePadConnectNum.pad2 == true)
		{
			//　移動キーを押していなければ何もしない
			if (Mathf.Approximately(Input.GetAxis(horizontalString), 0f) && Mathf.Approximately(Input.GetAxis(verticalString), 0f))
			{
				return;
			}
			//　移動先を計算
			var pos = rect.anchoredPosition + new Vector2(Input.GetAxis(horizontalString) * iconSpeed, Input.GetAxis(verticalString) * iconSpeed) * Time.deltaTime;

			//　アイコンが画面外に出ないようにする
			pos.x = Mathf.Clamp(pos.x, -Screen_W * 0.5f + offset.x, Screen_W * 0.5f - offset.x);
			pos.y = Mathf.Clamp(pos.y, -Screen_H * 0.5f + offset.y, Screen_H * 0.5f - offset.y);
			//　アイコン位置を設定
			rect.anchoredPosition = pos;
		}
		else if(GamePadConnectNum.pad3 == true)
		{
			//　移動キーを押していなければ何もしない
			if (Mathf.Approximately(Input.GetAxis(horizontalString), 0f) && Mathf.Approximately(Input.GetAxis(verticalString), 0f))
			{
				return;
			}
			//　移動先を計算
			var pos = rect.anchoredPosition + new Vector2(Input.GetAxis(horizontalString) * iconSpeed, Input.GetAxis(verticalString) * iconSpeed) * Time.deltaTime;

			//　アイコンが画面外に出ないようにする
			pos.x = Mathf.Clamp(pos.x, -Screen_W * 0.5f + offset.x, Screen_W * 0.5f - offset.x);
			pos.y = Mathf.Clamp(pos.y, -Screen_H * 0.5f + offset.y, Screen_H * 0.5f - offset.y);
			//　アイコン位置を設定
			rect.anchoredPosition = pos;
		}
		else if(GamePadConnectNum.pad4 == true)
		{
			//　移動キーを押していなければ何もしない
			if (Mathf.Approximately(Input.GetAxis(horizontalString), 0f) && Mathf.Approximately(Input.GetAxis(verticalString), 0f))
			{
				return;
			}
			//　移動先を計算
			var pos = rect.anchoredPosition + new Vector2(Input.GetAxis(horizontalString) * iconSpeed, Input.GetAxis(verticalString) * iconSpeed) * Time.deltaTime;

			//　アイコンが画面外に出ないようにする
			pos.x = Mathf.Clamp(pos.x, -Screen_W * 0.5f + offset.x, Screen_W * 0.5f - offset.x);
			pos.y = Mathf.Clamp(pos.y, -Screen_H * 0.5f + offset.y, Screen_H * 0.5f - offset.y);
			//　アイコン位置を設定
			rect.anchoredPosition = pos;
		}
	}
}
