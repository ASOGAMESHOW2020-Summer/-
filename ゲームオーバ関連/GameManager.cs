using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject obj;

    //プレイヤー（侍）を格納する
    [SerializeField]
    private SamuraiMoveScript SamuraiScript;
    //プレイヤー（僧侶）を格納する
    [SerializeField]
    private MonkMoveScript MonkScript;
    //プレイヤー（陰陽師）を格納する
    [SerializeField]
    private OnmyojiMoveScript OnmyojiScript;
    //プレイヤー（盗賊）を格納する
    [SerializeField]
    private ThiefMoveScript ThiefScript;

    // Start is called before the first frame update
    void Start()
    {
        SamuraiScript = GetComponent<SamuraiMoveScript>();
        MonkScript = GetComponent<MonkMoveScript>();
        OnmyojiScript = GetComponent<OnmyojiMoveScript>();
        ThiefScript = GetComponent<ThiefMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        NextScene();
    }

    void NextScene()
    {
        obj.GetComponent<SamuraiMoveScript>().GetState();
        //プレイヤー（侍）の状態を取得
        SamuraiMoveScript.MyState SamuraiState = SamuraiScript.GetState();
        //プレイヤー（侍）の状態を取得
        MonkMoveScript.MyState MonkState = MonkScript.GetState();
        //プレイヤー（侍）の状態を取得
        OnmyojiMoveScript.MyState OnmyojiState = OnmyojiScript.GetState();
        //プレイヤー（侍）の状態を取得
        ThiefMoveScript.MyState ThiefState = ThiefScript.GetState();

        if (SamuraiState == SamuraiMoveScript.MyState.Dead
        && (MonkState == MonkMoveScript.MyState.Dead)
        && (OnmyojiState == OnmyojiMoveScript.MyState.Dead)
        && (ThiefState == ThiefMoveScript.MyState.Dead))
        {
          SceneManager.LoadScene("Test");
        }
    }
}
