using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butsuzo : MonoBehaviour
{
    private bool ButsuzoFlag = false;
    //カウントダウン
    public float countdown = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        ButsuzoFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントする
        countdown -= Time.deltaTime;

        //カウントが0になった時
        if (countdown <= 0)
        {
            ButsuzoFlag = false;
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Monk")
        {
            Destroy(gameObject);
            coll.GetComponent<MonkMoveScript>().SetButsuzoFlag(true);
            ButsuzoFlag = true;
            GetButsuzoFlag();
        }
        else
        {
            return;
        }
    }

    public bool GetButsuzoFlag()
    {
        return ButsuzoFlag;
    }
}
