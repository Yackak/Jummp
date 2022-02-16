using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonBoss : MonoBehaviour
{
    public Transform target1;//��ǥ ��ġ  
    public Transform target2;//�÷��̾� ��ġ  
    public bool isit;//�÷��̾ �븱 �� �ִ� ��ġ�� �����ߴ°�?
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
        if (isit == false)//�÷��̾ �븱 �� ���� ��ġ�� �ƴ϶��
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, combackSpeed * Time.deltaTime);//�÷��̾ �븱 �� �ִ� ��ġ�� �̵�

        }
        else//�÷��̾ �븱 �� �ִ� ��ġ���
        {
            timer += Time.deltaTime;
            if (timer > Waitingtime)// �����ð���ŭ ���
            {
            transform.position = Vector3.SmoothDamp(transform.position, target2.position, ref velo, fallSpeed * Time.deltaTime);//�÷��̾ ���� ����(��������)
                
            }
        }
    }
    void OnTriggerEnter(Collider other) //����� �� ȣ�� �Լ�
    {
        if (other.tag == "Target")//�÷��̾ ��Ҵٸ�
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
