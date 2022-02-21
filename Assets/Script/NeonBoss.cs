using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonBoss : MonoBehaviour
{
    public Transform target1;//목표 위치  
    public Transform target2;//플레이어 위치  
    public Transform target3;//정비 위치  
    public int isit;//플레이어를 노릴 수 있는 위치에 도달했는가?
    public float combackSpeed;
    public float fallSpeed;
    public int Waitingtime;
    private Quaternion Right = Quaternion.identity;
    private float timer;
    Vector3 velo = Vector3.zero;
    Animator animator;
    
    void Awake()
    {
        isit = 0;
        timer = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isit == 0)//플레이어를 노릴 수 없는 위치가 아니라면
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, combackSpeed * Time.deltaTime);//플레이어를 노릴 수 있는 위치로 이동

        }
        else if(isit == 1)//플레이어를 노릴 수 있는 위치라면
        {
            timer += Time.deltaTime;
            Right.eulerAngles = new Vector3(0, 270, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Right, Time.deltaTime * 200.0f);//회전
            if (timer > Waitingtime)// 설정시간만큼 대기
            {
                animator.speed = 1.0f;
                transform.position = Vector3.SmoothDamp(transform.position, target2.position, ref velo, fallSpeed * Time.deltaTime);//플레이어를 향해 돌진(선형보간)
            }
        }
        else if(isit == 2)
        {
            Right.eulerAngles = new Vector3(0, 180, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Right, Time.deltaTime * 200.0f);//180도 회전
            transform.position = Vector3.MoveTowards(transform.position, target3.position, 5 * combackSpeed * Time.deltaTime);//정비 위치로 이동

        }
    }
    void OnTriggerEnter(Collider other) //닿았을 때 호출 함수
    {
        if (other.tag == "Target")//플레이어에 닿았다면
        {
            isit = 1;
            animator.speed = 0.5f;
        }
        else if(other.tag == "TargetFail")
        {
            isit = 2;
            animator.speed = 1.0f;
        }
        else if(other.tag == "TargetAgain")
        {
            transform.Rotate(new Vector3(0, 180, 0), Space.World);
            timer = 0;
            isit = 0;
            animator.speed = 1.0f;
        }
    }
}
