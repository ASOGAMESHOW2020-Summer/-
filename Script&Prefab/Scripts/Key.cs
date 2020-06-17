using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    //Audio
    [SerializeField]
    private AudioClip KeyGet;
    AudioSource audioSource;

    [Header("入力した値の間のランダム値をX座標にする")]
    [SerializeField]
    int Xmin, Xmax;
    [Header("入力した値の間のランダム値をY座標にする")]
    [SerializeField]
    int Ymin, Ymax;
    [Header("入力した値の間のランダム値をZ座標にする")]
    [SerializeField]
    int Zmin, Zmax;

    private bool GetKey = false;

    void Start()
    {
        GetKey = false;
        var x = Random.Range(Xmin, Xmax);
        var y = Random.Range(Ymin, Ymax);
        var z = Random.Range(Zmin, Zmax);
        var randomPosition = new Vector3(x, y, z);
        transform.position = randomPosition;
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Samurai")
        {
            audioSource.PlayOneShot(KeyGet);
            Destroy(gameObject);
            coll.GetComponent<SamuraiMoveScript>().SetKeyFlag(true);
            GetKey = true;
        }
        else if(coll.tag == "Monk")
        {
            audioSource.PlayOneShot(KeyGet);
            Destroy(gameObject);
            coll.GetComponent<MonkMoveScript>().SetKeyFlag(true);
            GetKey = true;
        }
        else if(coll.tag == "Onmyoji")
        {
            audioSource.PlayOneShot(KeyGet);
            Destroy(gameObject);
            coll.GetComponent<OnmyojiMoveScript>().SetKeyFlag(true);
            GetKey = true;
        }
        else if(coll.tag == "Thief")
        {
            audioSource.PlayOneShot(KeyGet);
            Destroy(gameObject);
            coll.GetComponent<ThiefMoveScript>().SetKeyFlag(true);
            GetKey = true;
        }
    }

    public bool GetKeyFlag()
    {
        return GetKey;
    }
}
