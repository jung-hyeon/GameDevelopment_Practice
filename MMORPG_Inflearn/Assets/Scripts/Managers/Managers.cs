using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // ���ϼ��� �����
    static Managers Instance { get { Init(); return s_instance; } }// ������ �Ŵ����� �����´�.

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
            // �ʱ�ȭ
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go); // �����Ǵ� �� ����
            s_instance = go.GetComponent<Managers>();
        }
    }
}