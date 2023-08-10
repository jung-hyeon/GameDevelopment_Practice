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

    // �α��� ui����� �������� �ϴ� update������ �Ǵ��ϵ��� �ϵ��ڵ�
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Game); // ���� ���� ���޴��� ���(����Ƽ�� ���� �Ǿ� �ִ� �� ���)
        }
    }

    public override void Clear()
    {
        Debug.Log("LoginScene Clear!");
    }

}
