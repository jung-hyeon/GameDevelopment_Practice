using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장됨
    static Managers Instance { get { Init(); return s_instance; } }// 유일한 매니저를 가져온다.

    InputManager _input = new InputManager();
    ResourceManager _resouce = new ResourceManager();
    //UIManager _ui = new UIManager();

    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resouce { get { return Instance._resouce; } }
    //public static UIManager UI { get { return Instance._ui; } }


    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            // 초기화
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go); // 삭제되는 것 방지
            s_instance = go.GetComponent<Managers>();
        }
    }
}
