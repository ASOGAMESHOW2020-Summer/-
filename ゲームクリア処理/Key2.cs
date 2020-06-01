using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key2 : MonoBehaviour
{
    private bool KeyFlag = false;

    void Start()
    {
        KeyFlag = false;
    }
   
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Samurai")
        {
            Destroy(gameObject);
            coll.GetComponent<SamuraiMoveScript>().SetKeyFlag(true);
            KeyFlag = true;
            GetKeyFlag();
        }
        else if (coll.tag == "Monk")
        {
            Destroy(gameObject);
            coll.GetComponent<MonkMoveScript>().SetKeyFlag(true);
            KeyFlag = true;
            GetKeyFlag();
        }
        else if (coll.tag == "Onmyoji")
        {
            Destroy(gameObject);
            coll.GetComponent<OnmyojiMoveScript>().SetKeyFlag(true);
            KeyFlag = true;
            GetKeyFlag();
        }
        else if (coll.tag == "Thief")
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
