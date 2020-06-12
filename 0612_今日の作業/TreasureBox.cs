using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TreasureBox : MonoBehaviour
{
    public enum ItemList
    {
        Katana,
        Gofu,
        Butsuzo,
        Otakara
    };

    private ItemList itemList;
    public GameObject[] treasureBox;
    //アイテム
    private bool KatanaFlag = false;
    private bool ButsuzoFlag = false;
    private bool GofuFlag = false;
    private bool OtakaraFlag = false;
    private bool KeyFlag = false;

    public GameObject item_key;
    public GameObject item_katana;
    public GameObject item_otakara;
    public GameObject item_gofu;
    public GameObject item_butsuzo;

    public string[] samuraiItemNames = { "Katana", "Key" };
    public string[] monkItemNames = { "Butsuzo", "Key" };
    public string[] onmyojiItemNames = { "Gofu", "Key" };
    public string[] thiefItemNames = { "Otakara", "Key" };

    //アニメーター
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<animator>();
        ItemFlag = false;
        KatanaFlag = false;
        ButsuzoFlag = false;
        GofuFlag = false;
        OtakaraFlag = false;

        number = Random.Range(0, Train.Length);
        Instantiate(inTreasureBox[number], transform.position, transform.rotation);
        print(GetRandomItemName());
        print(GetRandomSamuraiItemName());
        print(GetRandomMonkItemName());
        print(GetRandomOnmyojiItemName());
        print(GetRandomThiefItemName());

        eventsystem = GameObject.Find("EventSystem").GetComponent<eventsystem>();
        item_key = GameObject.Find("Key");
        item_katana = GameObject.Find("katana");
        item_otakara = GameObject.Find("otakara");
        item_gofu = GameObject.Find("gofu");
        item_butsuzo = GameObject.Find("butsuzo");
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Samurai")
        {
            if (animator.SetBool("touch", true))
            {
                animator.Play("Open");
                if ((KatanaFlag == false) && (KeyFlag == false))
                {
                    Destroy(gameObject);
                    //刀を取得
                    collider.GetComponent<SamuraiMoveScript>().SetKatanaFlag(true);
                    KatanaFlag = true;
                    GetKatanaFlag();
                    //鍵を取得
                    collider.GetComponent<SamuraiMoveScript>().SetKeyFlag(true);
                    KeyFlag = true;
                    GetKeyFlag();
                }
                else if ((KatanaFlag == false) && (KeyFlag == true))
                {
                    Destroy(gameObject);
                    //刀を取得
                    collider.GetComponent<SamuraiMoveScript>().SetKatanaFlag(true);
                    KatanaFlag = true;
                    GetKatanaFlag();
                }
                else if ((KatanaFlag == true) && (KeyFlag == true))
                {
                    return;
                }
            }
        }
        if (collider.tag == "Monk")
        {
            if (animator.SetBool("touch", true))
            {
                animator.Play("Open");
                if ((ButsuzoFlag == false) && (KeyFlag == false))
                {
                    Destroy(gameObject);
                    //仏像を取得
                    collider.GetComponent<MonkMoveScript>().SetButsuzoFlag(true);
                    ButsuzoFlag = true;
                    GetButsuzoFlag();
                    //鍵を取得
                    collider.GetComponent<MonkMoveScript>().SetKeyFlag(true);
                    KeyFlag = true;
                    GetKeyFlag();
                }
                else if ((ButsuzoFlag == false) && (KeyFlag == true))
                {
                    Destroy(gameObject);
                    //刀を取得
                    collider.GetComponent<MonkMoveScript>().SetButsuzoFlag(true);
                    ButsuzoFlag = true;
                    GetButsuzoFlag();
                }
                else if ((ButsuzoFlag == true) && (KeyFlag == true))
                {
                    return;
                }
            }
        }
        if (collider.tag == "Onmyoji")
        {
            if (animator.SetBool("touch", true))
            {
                animator.Play("Open");
                if ((GofuFlag == false) && (KeyFlag == false))
                {
                    Destroy(gameObject);
                    //刀を取得
                    collider.GetComponent<SamuraiMoveScript>().SetGofuFlag(true);
                    GofuFlag = true;
                    GetGofuFlag();
                    //鍵を取得
                    collider.GetComponent<SamuraiMoveScript>().SetKeyFlag(true);
                    KeyFlag = true;
                    GetKeyFlag();
                }
                else if ((GofuFlag == false) && (KeyFlag == true))
                {
                    Destroy(gameObject);
                    //刀を取得
                    collider.GetComponent<SamuraiMoveScript>().SetGofuFlag(true);
                    GofuFlag = true;
                    GetGofuFlag();
                }
                else if ((GofuFlag == true) && (KeyFlag == true))
                {
                    return;
                }
            }
        }
        if (collider.tag == "Thief")
        {
            if (animator.SetBool("touch", true))
            {
                animator.Play("Open");
                if ((OtakaraFlag == false) && (KeyFlag == false))
                {
                    Destroy(gameObject);
                    //刀を取得
                    collider.GetComponent<SamuraiMoveScript>().SetOtakaraFlag(true);
                    OtakaraFlag = true;
                    GetOtakaraFlag();
                    //鍵を取得
                    collider.GetComponent<SamuraiMoveScript>().SetKeyFlag(true);
                    KeyFlag = true;
                    GetKeyFlag();
                }
                else if ((OtakaraFlag == false) && (KeyFlag == true))
                {
                    Destroy(gameObject);
                    //刀を取得
                    collider.GetComponent<SamuraiMoveScript>().SetOtakaraFlag(true);
                    OtakaraFlag = true;
                    GetOtakaraFlag();
                }
                else if ((OtakaraFlag == true) && (KeyFlag == true))
                {
                    return;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    string GetRandomSamuraiItemName()
    {
        var incidenceDistoribution = GetIncidenceDistributionList(item_katana, item_key);

        int rdm = Random.Range(0, incidenceDistoribution.Count);
        return samuraiItemName[incidenceDistoribution[rdm]];
    }

    string GetRandomMonkItemName()
    {
        var incidenceDistoribution = GetIncidenceDistributionList(item_butsuzo, item_key);

        int rdm = Random.Range(0, incidenceDistoribution.Count);
        return monkItemNames[incidenceDistoribution[rdm]];
    }

    string GetRandomOnmyojiItemName()
    {
        var incidenceDistoribution = GetIncidenceDistributionList(item_gofu, item_key );

        int rdm = Random.Range(0, incidenceDistoribution.Count);
        return onmyojiItemNames[incidenceDistoribution[rdm]];
    }
    string GetRandomThiefItemName()
    {
        var incidenceDistoribution = GetIncidenceDistributionList(item_otakara, item_key);

        int rdm = Random.Range(0, incidenceDistoribution.Count);
        return thiefItemNames[incidenceDistoribution[rdm]];
    }

    List<int> GetIncidenceDistributionList(params int[] incidences)
    {
        var incidenceList = new List<int>();

        int gcd = GCD(incidences);

        for (int i = 0, len = incidences.Length; i < len; i++)
        {
            int incidence = incidences[i] / gcd;

            for (int j = 0; j <= incidence; j++)
            {
                incidenceList.Add(i);
            }
        }
        return incidenceList;
    }

    int GCD(int[] numbers)
    {
        return numbers.Aggregate(GCD);
    }

    int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }

}
