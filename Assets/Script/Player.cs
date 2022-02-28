using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    StageManager stagemanagement;
    Transform playerTransform;//플레이어 위치 저장
    public GameObject ShieldObject;
    public char Mypos;
    public int howJump;
    public int jumpCnt;
    public int coin;
    public float speed;
    public float basicSpeed;
    public float jumpspeed;
    public float jumpPower;
    public bool isX2;
    public bool isShield = false;
    public bool isItem = false;
    public  float timer;
    public float WaitingTime = 5;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//Player 위치 찾기
        jumpCnt = howJump; 
        isShield = false;
        basicSpeed = speed;
        Mypos = 'R';

    }

    // Update is called once per frame
    void Update()
    {
        if(isShield == false)
        {
            ShieldObject.SetActive(false);
        }
        else
        {
            ShieldObject.SetActive(true);
        }
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
        if (isItem == true)
        {
            timer += Time.deltaTime;
            if (timer > WaitingTime)
            {
                ItemReset();
            }
        }
    }
    void OnCollisionEnter(Collision other)//닿았을 때 호출 함수
    {
        if (other.gameObject.tag == "Floor")//바닥에 닿으면 점프 초기화
        {
            jumpCnt = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")//바닥에 닿으면 점프 초기화
        {
            SceneManager.LoadScene("3_NeonCity");
        }
        else if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "DeadLine")
        {
            if (isShield == false)//쉴드가 없으면 죽음
            {
                SceneManager.LoadScene("3_NeonCity");
            }
            else//쉴드가 있으면 3초 무적
            {
                timer = 0;
                WaitingTime = 3;
            }
        }
    }
    public void ItemReset()//아이템 초기화 함수
    {
        isX2 = false;//코인 아이템 초기화
        howJump = 1;//더블 점프 아이템 초기화
        speed = basicSpeed;//속도 초기화
        isShield = false;
        WaitingTime = 5;
        timer = 0;
        isItem = false;
    }
}
