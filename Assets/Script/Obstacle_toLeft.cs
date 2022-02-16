using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_toLeft : MonoBehaviour
{
    public float obstacleSpeed;//장애물 속도 지정
    bool isMove;
    Vector3 target;

    void Awake()
    {
        isMove = false;
    }

    void OnTriggerEnter(Collider other)//닿았을 때 호출 함수
    {
        if (other.tag == "Player")//플레이어에 닿았다면
        {
            target = transform.position + new Vector3(500, 0, 0);
            isMove = true;
        }
    }
    void Update()
    {
        if (isMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, obstacleSpeed * Time.deltaTime);//출발하기
        }
    }
}
