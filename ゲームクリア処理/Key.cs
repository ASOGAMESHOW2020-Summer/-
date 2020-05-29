using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    private int KeyNum = 0;
    private const int GetKeyMax = 2;
    public Text text;

    void Start()
    {
        KeyNum = 0;
    }
    void Update()
    {
        text.text = KeyNum.ToString();
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Samurai")
        {
            Destroy(gameObject);
            coll.GetComponent<SamuraiMoveScript>().SetKeyFlag(true);
            KeyNum += 1;
        }
        else if(coll.tag == "Monk")
        {
            Destroy(gameObject);
            coll.GetComponent<MonkMoveScript>().SetKeyFlag(true);
            KeyNum += 1;
        }
        else if(coll.tag == "Onmyoji")
        {
            Destroy(gameObject);
            coll.GetComponent<OnmyojiMoveScript>().SetKeyFlag(true);
            KeyNum += 1;
        }
        else if(coll.tag == "Thief")
        {
            Destroy(gameObject);
            coll.GetComponent<ThiefMoveScript>().SetKeyFlag(true);
            KeyNum += 1;
        }
    }

    public int GetKeyNum()
    {
        return KeyNum;
    }

    public void GameClear()
    {
        if (KeyNum >= GetKeyMax)
        {
            SceneManager.LoadScene("Test2");
            Debug.Log("ゲームクリアシーン移動");
        }
    }
}
