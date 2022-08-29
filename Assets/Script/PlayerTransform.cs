using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    Transform playerTransform;
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//Player 위치 찾기

    }
    void LateUpdate()//카메라 위치 == 플레이어의 위치
    {
        transform.position = playerTransform.position;
        //카메라는 점프 안함
        /*transform.position = playerTransform.position;//카메라도 같이 점프*/
    }
}
