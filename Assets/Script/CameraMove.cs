using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    float y;
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//Player ��ġ ã��
        y = playerTransform.position.y;

    }
    void LateUpdate()//ī�޶� ��ġ == �÷��̾��� ��ġ
    {
        float x = playerTransform.position.x;
        float z = playerTransform.position.z;
        y = playerTransform.position.y;
        transform.position = new Vector3(x, y + 1, z);
        //ī�޶�� ���� ����
        /*transform.position = playerTransform.position;//ī�޶� ���� ����*/
    }
}
