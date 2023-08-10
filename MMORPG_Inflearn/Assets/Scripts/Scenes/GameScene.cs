using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;

        //Managers.UI.ShowSceneUI<UI_Inven>(); // ui 부분 들은 후에 주석 처리 뺴주기
    }

    public override void Clear()
    {
    }

}
