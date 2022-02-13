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
    public int Health;
    public float speed;
    public float jumpPower;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//Player 위치 찾기
        jumpCnt = howJump;
        Health = 1;
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
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "DeadLine")
        {
            if (Health > 1)//목숨이 1개보다 많으면 목숨 개수 줄이기
            {
                Health--;
            }
            else//목숨이 1개라면 다시 하기
            {
                SceneManager.LoadScene("1_Cafe");
            }
        }

    }

}
