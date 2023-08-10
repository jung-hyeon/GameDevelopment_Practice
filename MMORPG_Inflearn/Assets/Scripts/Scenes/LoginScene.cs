using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;
    }

    // 로그인 ui만들기 귀찮으니 일단 update문으로 판단하도록 하드코딩
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Game); // 직접 만든 씬메니져 사용(유니티에 내장 되어 있는 것 대신)
        }
    }

    public override void Clear()
    {
        Debug.Log("LoginScene Clear!");
    }

}
