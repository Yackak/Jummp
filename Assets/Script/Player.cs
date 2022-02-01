using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    Transform playerTransform;//플레이어 시작위치 저장
    public int howJump;
    public int jumpCnt;
    public float speed;
    public float jumpPower;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//Player 위치 찾기
        jumpCnt = howJump;

    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCnt < howJump && Input.GetButtonDown("Jump"))//점프키를 눌렀을 때 점프(점프는 fixedupdate에서 처리하면 안됨)
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            jumpCnt++;
        }
        Vector3 moveVec = new Vector3(1, 0, 0).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)// 겉에 닿았을때 
    {
        if (other.gameObject.tag == "Floor")//바닥에 닿았으면 점프 횟수 초기화
        {
            jumpCnt = 0;
        }
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Example1");
        }

    }

}
