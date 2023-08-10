using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    private Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f); // 카메라 각도 벡터 정의

    [SerializeField]
    private GameObject _player;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            // wall이 카메라 가릴 때
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude;
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else // wall이 카메라 가리지 않을 때
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);
            }
        }
    }

    public void SetQuarterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
