using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    float y;
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//Player 위치 찾기
        y = playerTransform.position.y;

    }
    void LateUpdate()//카메라 위치 == 플레이어의 위치
    {
        float x = playerTransform.position.x;
        float z = playerTransform.position.z;
        y = playerTransform.position.y;
        transform.position = new Vector3(x, y + 1, z);
        //카메라는 점프 안함
        /*transform.position = playerTransform.position;//카메라도 같이 점프*/
    }
}
