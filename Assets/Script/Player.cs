using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    StageManager stagemanagement;
    Transform playerTransform;//플레이어 위치 저장
    public char Mypos;
    public int howJump;
    public int jumpCnt;
    public int Health;
    public int coin;
    public float speed;
    public float jumpspeed;
    public float jumpPower;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//Player 위치 찾기
        jumpCnt = howJump; 
        Health = 1;
        Mypos = 'R';

    }

    // Update is called once per frame
    void Update()
    {
            /*if ((stagemanagement.CurrentStage > 0) && (stagemanagement.CurrentStage < 11)) {// cafe 맵일때
                if (jumpCnt < howJump && Input.GetButtonDown("Jump"))//����Ű�� ������ �� ����(������ fixedupdate���� ó���ϸ� �ȵ�)
                {
                    rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
                    jumpCnt++;
                } 
           }*/
            /*else if ((stagemanagement.CurrentStage > 10) && (stagemanagement.CurrentStage < 21)//Load 맵일 때
            {
                if (jumpCnt < howJump && Input.GetButtonDown("Jump"))//����Ű�� ������ �� ����(������ fixedupdate���� ó���ϸ� �ȵ�)
                {
                    rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
                    jumpCnt++;
                }
            }*/
            //else if ((stagemanagement.CurrentStage > 20) && (stagemanagement.CurrentStage < 31){//Neon_city 맵일 때
        if (jumpCnt < howJump && Input.GetButtonDown("Jump"))//����Ű�� ������ �� ����(������ fixedupdate���� ó���ϸ� �ȵ�)
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            jumpCnt++;
            if (Mypos == 'R')//오른쪽에서 점프할 때
            {
                rigid.AddForce(new Vector3(jumpspeed, 0, 0), ForceMode.Impulse);
                Mypos = 'L';
            }
            else//왼쪽에서 점프할 때
            {
                rigid.AddForce(new Vector3(-jumpspeed, 0, 0), ForceMode.Impulse);
                Mypos = 'R';
            }
        }
        Vector3 moveVec = new Vector3(0, 0, -1).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
        if (playerTransform.position.x > 241)//위치 고정 함수
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
            transform.position += new Vector3(-1, 0, 0);
        }
        else if (playerTransform.position.x > 156 && playerTransform.position.x < 160)
        {
            if (jumpCnt == 0)
            {
                rigid.velocity = Vector3.zero;
                rigid.angularVelocity = Vector3.zero;
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (playerTransform.position.x < 155)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
            transform.position += new Vector3(1, 0, 0);
        }
        else if (playerTransform.position.x > 230 && playerTransform.position.x < 239)
        {
            if (jumpCnt == 0)
            {
                rigid.velocity = Vector3.zero;
                rigid.angularVelocity = Vector3.zero;
                transform.position += new Vector3(1, 0, 0);
            }
        }
    }
    void OnCollisionEnter(Collision other)//닿았을 때 호출 함수
    {
        if (other.gameObject.tag == "Floor")//바닥에 닿으면 점프 초기화
        {
            jumpCnt = 0;
        }
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "DeadLine")
        {
            if (Health > 1)//목숨이 더 있으면 목숨 깍임
            {
                Health--;
            }
            else//목숨이 없다면 죽음
            {
                SceneManager.LoadScene("3_NeonCity");
            }
        }

    }

}
