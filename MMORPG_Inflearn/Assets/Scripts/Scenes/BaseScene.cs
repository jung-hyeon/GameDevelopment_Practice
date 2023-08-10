using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;
    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        // EventSystem 존재하지 않다면 만들기
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj = null) 
        {
            Managers.Resouce.Instantiate("UI/EventSystem").name = "@EventSystem";
        }
    }
    // 종료시 삭제할 것들 넣어줌
    public abstract void Clear();
}
