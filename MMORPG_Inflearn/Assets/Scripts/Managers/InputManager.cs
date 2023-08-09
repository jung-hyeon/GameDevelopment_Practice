using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action keyAction = null;
    // public Action<Define.MouseEvent> MouseAction = null;
    // bool _pressed = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.anyKey == false)
            return;

        if (keyAction != null)
            keyAction.Invoke();
    }
}
