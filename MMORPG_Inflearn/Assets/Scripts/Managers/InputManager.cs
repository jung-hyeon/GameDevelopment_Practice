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

        //if (Input.anyKey == false) // Ű���� �Է� üũ
        //    return;

        //if (keyAction != null) // keyAction üũ
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
                if (_pressed) // pressed �Ǿ��ٰ� mouse �� ���� => click
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                _pressed = false;
            }
        }
    }
}
