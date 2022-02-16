using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    Transform playerTransform;
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//Player ��ġ ã��

    }
    void LateUpdate()//ī�޶� ��ġ == �÷��̾��� ��ġ
    {
        float x = playerTransform.position.x;
        float z = playerTransform.position.z;
        float y = playerTransform.position.y;
        transform.position = new Vector3(x, y, z);
        //ī�޶�� ���� ����
        /*transform.position = playerTransform.position;//ī�޶� ���� ����*/
    }
}
