using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            // 위의 3줄을 한 줄로 표현하는 더 간단한 버전
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            LayerMask mask = (LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"));
            // int mask = (1<<8) | (1<<9);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.tag}");
            }
        }
    }
}

