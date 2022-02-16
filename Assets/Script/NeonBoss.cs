using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonBoss : MonoBehaviour
{
    public Transform target1;//목표 위치  
    public Transform target2;//플레이어 위치  
    public bool isit;//플레이어를 노릴 수 있는 위치에 도달했는가?
    public float combackSpeed;
    public float fallSpeed;
    public int Waitingtime;
    public float timer;
    Vector3 velo = Vector3.zero;
    
    void Awake()
    {
        isit = false;
        timer = 0;
    }

    void Update()
    {
        if (isit == false)//플레이어를 노릴 수 없는 위치가 아니라면
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, combackSpeed * Time.deltaTime);//플레이어를 노릴 수 있는 위치로 이동

        }
        else//플레이어를 노릴 수 있는 위치라면
        {
            timer += Time.deltaTime;
            if (timer > Waitingtime)// 설정시간만큼 대기
            {
            transform.position = Vector3.SmoothDamp(transform.position, target2.position, ref velo, fallSpeed * Time.deltaTime);//플레이어를 향해 돌진(선형보간)
                
            }
        }
    }
    void OnTriggerEnter(Collider other) //닿았을 때 호출 함수
    {
        if (other.tag == "Target")//플레이어에 닿았다면
        {
            isit = true;
        }
        else if(other.tag == "TargetFail")
        {
            timer = 0;
            isit = false;
        }
    }
}
