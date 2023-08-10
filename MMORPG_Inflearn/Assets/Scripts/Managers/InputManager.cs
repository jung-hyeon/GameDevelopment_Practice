using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class InputManager
{
    public Action keyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    bool _pressed = false;

    public void OnUpdate()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        //if (Input.anyKey == false) // 키보드 입력 체크
        //    return;

        //if (keyAction != null) // keyAction 체크
        //    keyAction.Invoke();

        if (Input.anyKey && keyAction != null)
        {
            keyAction.Invoke();
        }

        if (MouseAction != null)
        {
            if(Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed) // pressed 되었다가 mouse 땐 상태 => click
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                _pressed = false;
            }
        }
    }
}
