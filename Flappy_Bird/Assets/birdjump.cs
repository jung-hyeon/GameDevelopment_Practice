using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class birdjump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower; // pubkuc으로 지정하면 unity 엔진에서도 변수 조정 가능
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 눌리면  or 스마트폰 터치
        {
            GetComponent<AudioSource>().Play();
            rb.velocity = Vector2.up * jumpPower; // vector2는 (0,1)을 의미
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
