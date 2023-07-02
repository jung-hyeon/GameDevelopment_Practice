using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; 
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDown;

    bool isJump;

    Vector3 moveVec;
    Rigidbody rigid;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }

    private void GetInput()
    {
        // Horizontal, Vertical은 유니티 Edit-ProjectSettings-InputManager에서 관리하고 있음
        hAxis = Input.GetAxisRaw("Horizontal"); // Axis값을 정수로 반환하는 함수
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    private void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized; //normalized쓰면 대각선으로 이동해도 벡터 값이 1로 보장
        // 벽은 fixedupdate이기 때문에 update문에 있는 transform이동이 무시되는 상황 발생 가능 => player의 rigidbody-collision detecion을 continuous로 변경

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if(jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 30, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }
}
