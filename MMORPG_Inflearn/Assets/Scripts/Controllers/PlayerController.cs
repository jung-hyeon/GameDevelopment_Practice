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
        Managers.Input.keyAction -= OnKeyboard; // �� �� ������û �ϰ� ���� ���ɼ� ���
        Managers.Input.keyAction += OnKeyboard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        //Managers.Resouce.instantiate("UI/UI_Button");

        //Managers.UI.ShowPopupUI<UI_Button>();


    }

    void Update()
    {
        if (_moveToDest) // ���콺�� ��ǥ ���� ������ �̵�
        {
            Vector3 dir = _destPos - transform.position;
            if (dir.magnitude < 0.0001f)
            {
                _moveToDest = false;
            }
            else
            {
                float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); // �÷��̾ �������� �����ƴ� �ٽ� �Դ� �͸����� �ϴ� ���� �ذ�
                transform.position += dir.normalized * moveDist;

                // lookat����ϸ� �÷��̾��� �������� �Ҷ� ����� �� ó�� ���� => Quaternion���
                //transform.LookAt(_destPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            }
        }
    }

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.forward); // �̷��� �ϸ� �ʹ� ����� ���� = Slerp���
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += (Vector3.forward * Time.deltaTime * _speed);   // transform.Translate((Vector3.forward * Time.deltaTime * _speed) ���� �����
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

        _moveToDest = false; // Ű���� ���������� ���콺 �̵� X
    }

    // ���콺 Ŭ���ϸ� �ش� ��ǥ�� �÷��̾ �̵�
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall"))) // LayerMask.GetMask("Wall")�� �ٷ� �־���
        {
            _destPos = hit.point;
            _moveToDest = true;
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.tag}");
        }
    }
}
