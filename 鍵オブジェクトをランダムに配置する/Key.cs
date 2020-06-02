using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    [Header("入力した値の間のランダム値をX座標にする")]
    [SerializeField]
    int Xmin, Xmax;
    [Header("入力した値の間のランダム値をY座標にする")]
    [SerializeField]
    int Ymin, Ymax;
    [Header("入力した値の間のランダム値をZ座標にする")]
    [SerializeField]
    int Zmin, Zmax;

    private bool KeyFlag = false;

    void Start()
    {
        KeyFlag = false;
        var x = Random.Range(Xmin, Xmax);
        var y = Random.Range(Ymin, Ymax);
        var z = Random.Range(Zmin, Zmax);
        var randomPosition = new Vector3(x, y, z);
        transform.position = randomPosition;
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Samurai")
        {
            Destroy(gameObject);
            coll.GetComponent<SamuraiMoveScript>().SetKeyFlag(true);
            KeyFlag = true;
            GetKeyFlag();
        }
        else if(coll.tag == "Monk")
        {
            Destroy(gameObject);
            coll.GetComponent<MonkMoveScript>().SetKeyFlag(true);
            KeyFlag = true;
            GetKeyFlag();
        }
        else if(coll.tag == "Onmyoji")
        {
            Destroy(gameObject);
            coll.GetComponent<OnmyojiMoveScript>().SetKeyFlag(true);
            KeyFlag = true;
            GetKeyFlag();
        }
        else if(coll.tag == "Thief")
        {
            Destroy(gameObject);
            coll.GetComponent<ThiefMoveScript>().SetKeyFlag(true);
            KeyFlag = true;
            GetKeyFlag();
        }
    }

    public bool GetKeyFlag()
    {
        return KeyFlag;
    }

}
