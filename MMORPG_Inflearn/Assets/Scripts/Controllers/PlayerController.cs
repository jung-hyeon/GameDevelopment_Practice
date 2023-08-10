using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    bool _moveToDest = false;
    Vector3 _destPos;

    void Start()
    {
        Managers.Input.keyAction -= OnKeyboard; // 두 번 구독신청 하고 있을 가능성 고려
        Managers.Input.keyAction += OnKeyboard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        //Managers.Resouce.instantiate("UI/UI_Button");

        //Managers.UI.ShowPopupUI<UI_Button>();


    }

    void Update()
    {
        if (_moveToDest) // 마우스로 좌표 찍은 곳으로 이동
        {
            Vector3 dir = _destPos - transform.position;
            if (dir.magnitude < 0.0001f)
            {
                _moveToDest = false;
            }
            else
            {
                float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); // 플레이어가 목적지를 지나쳤다 다시 왔다 와리가리 하는 문제 해결
                transform.position += dir.normalized * moveDist;

                // lookat사용하면 플레이어의 움직임이 뚝뚝 끊기는 것 처럼 보임 => Quaternion사용
                //transform.LookAt(_destPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            }
        }
    }

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.forward); // 이렇게 하면 너무 끊기는 느낌 = Slerp사용
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += (Vector3.forward * Time.deltaTime * _speed);   // transform.Translate((Vector3.forward * Time.deltaTime * _speed) 쓰면 어색함
        }

        if (Input.GetKey(KeyCode.S))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += (Vector3.back * Time.deltaTime * _speed); 
        }

        if (Input.GetKey(KeyCode.A))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += (Vector3.left * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += (Vector3.right * Time.deltaTime * _speed);
        }

        _moveToDest = false; // 키보드 눌렀을때는 마우스 이동 X
    }

    // 마우스 클릭하면 해당 좌표로 플레이어가 이동
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall"))) // LayerMask.GetMask("Wall")로 바로 넣어줌
        {
            _destPos = hit.point;
            _moveToDest = true;
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.tag}");
        }
    }
}
