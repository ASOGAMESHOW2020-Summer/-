/*鍵アイテムの処理スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key3 : MonoBehaviour
{
    //Audio
    [SerializeField]
    private AudioClip KeyGet;
    AudioSource audioSource;
    private Vector3 randomPosition;
    [Header("入力した値の間のランダム値をX座標にする")]
    [SerializeField]
    float Xmin, Xmax;
    [Header("入力した値の間のランダム値をY座標にする")]
    [SerializeField]
    float Ymin, Ymax;
    [Header("入力した値の間のランダム値をZ座標にする")]
    [SerializeField]
    float Zmin, Zmax;
    private bool GetKey = false;
    void Start()
    {
        GetKey = false;
        var x = Random.Range(Xmin, Xmax);
        var y = Random.Range(Ymin, Ymax);
        var z = Random.Range(Zmin, Zmax);
        randomPosition = new Vector3(x, y, z);
        transform.position = randomPosition;
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Samurai")
        {
            audioSource.PlayOneShot(KeyGet);
            Destroy(gameObject);
            coll.GetComponent<SamuraiMoveScript>().SetKeyFlag(true);
            GetKey = true;
            GameManager.keynum++;
        }
        else if (coll.tag == "Monk")
        {
            audioSource.PlayOneShot(KeyGet);
            Destroy(gameObject);
            coll.GetComponent<MonkMoveScript>().SetKeyFlag(true);
            GetKey = true;
            GameManager.keynum++;
        }
        else if (coll.tag == "Onmyoji")
        {
            audioSource.PlayOneShot(KeyGet);
            Destroy(gameObject);
            coll.GetComponent<OnmyojiMoveScript>().SetKeyFlag(true);
            GetKey = true;
            GameManager.keynum++;
        }
        else if (coll.tag == "Thief")
        {
            audioSource.PlayOneShot(KeyGet);
            Destroy(gameObject);
            coll.GetComponent<ThiefMoveScript>().SetKeyFlag(true);
            GetKey = true;
            GameManager.keynum++;
        }
    }

    public bool GetKeyFlag()
    {
        return GetKey;
    }
}
