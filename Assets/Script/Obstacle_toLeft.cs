using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_toLeft : MonoBehaviour
{
    public float obstacleSpeed;//��ֹ� �ӵ� ����
    bool isMove;
    Vector3 target;

    void Awake()
    {
        isMove = false;
    }

    void OnTriggerEnter(Collider other)//����� �� ȣ�� �Լ�
    {
        if (other.tag == "Player")//�÷��̾ ��Ҵٸ�
        {
            target = transform.position + new Vector3(500, 0, 0);
            isMove = true;
        }
    }
    void Update()
    {
        if (isMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, obstacleSpeed * Time.deltaTime);//����ϱ�
        }
    }
}
