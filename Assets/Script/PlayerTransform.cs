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
        transform.position = playerTransform.position;
        //ī�޶�� ���� ����
        /*transform.position = playerTransform.position;//ī�޶� ���� ����*/
    }
}
