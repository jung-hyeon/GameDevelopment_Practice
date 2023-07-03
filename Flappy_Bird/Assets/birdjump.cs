using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class birdjump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower; // pubkuc���� �����ϸ� unity ���������� ���� ���� ����
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư ������  or ����Ʈ�� ��ġ
        {
            GetComponent<AudioSource>().Play();
            rb.velocity = Vector2.up * jumpPower; // vector2�� (0,1)�� �ǹ�
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (Score.score > Score.bestscore)
        {
            Score.bestscore = Score.score;
        }
        SceneManager.LoadScene("GameOverScene");
    }
}