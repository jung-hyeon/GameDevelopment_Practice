using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    /* 굳이 외우기 보다 그때그때 활용
    1. 나 OR 상대한테 RigidBody 있어야 한다. (IsKinematic : off)
    2. 나한테 Collider 있어야 한다. (IsTrigger : off)
    3. 상대한테 collider 있어야 한다. (IsTrigger : off)
    */
    /*
    private void OnCollisionEnter(Collision other) {
        Debug.Log($"Collision @ {other.gameObject.name}");
    }
    */

    /* 굳이 외우기 보다 그때그때 활용
    1. 둘 다 Collider 있어야 한다.
    2. 둘 중 하나는 IsTrigger : On
    3. 둘 중 하나는 RigidBody 있어야 한다.
    */
    /*
    private void OnTriggerEnter(Collider other) {
        Debug.Log($"Trigger @ {other.gameObject.name}");
    }
    */

    void Update()
    {
        // local <-> World <-> Viewport <-> Screen

        /// Debug.Log(Input.mousePosition); // Screen 좌표

        // Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // Viewport

        if (Input.GetMouseButton(0))
        {
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

        /*
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Vector3 dir = mousePos - Camera.main.transform.position;
            dir = dir.normalized;

            Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

            if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");

            }
        */
    }







    /* 
    Vector3 look = transform.TransformDirection(Vector3.forward);
    Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

    RaycastHit[] hits;
    hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);

    foreach (RaycastHit hit in hits)
    {
        Debug.Log($"Raycast {hit.collider.gameObject.name}");
    }
    */
}

