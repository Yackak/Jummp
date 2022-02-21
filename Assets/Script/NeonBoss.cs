using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonBoss : MonoBehaviour
{
    public Transform target1;//��ǥ ��ġ  
    public Transform target2;//�÷��̾� ��ġ  
    public Transform target3;//���� ��ġ  
    public int isit;//�÷��̾ �븱 �� �ִ� ��ġ�� �����ߴ°�?
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
        if (isit == 0)//�÷��̾ �븱 �� ���� ��ġ�� �ƴ϶��
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, combackSpeed * Time.deltaTime);//�÷��̾ �븱 �� �ִ� ��ġ�� �̵�

        }
        else if(isit == 1)//�÷��̾ �븱 �� �ִ� ��ġ���
        {
            timer += Time.deltaTime;
            Right.eulerAngles = new Vector3(0, 270, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Right, Time.deltaTime * 200.0f);//ȸ��
            if (timer > Waitingtime)// �����ð���ŭ ���
            {
                animator.speed = 1.0f;
                transform.position = Vector3.SmoothDamp(transform.position, target2.position, ref velo, fallSpeed * Time.deltaTime);//�÷��̾ ���� ����(��������)
            }
        }
        else if(isit == 2)
        {
            Right.eulerAngles = new Vector3(0, 180, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Right, Time.deltaTime * 200.0f);//180�� ȸ��
            transform.position = Vector3.MoveTowards(transform.position, target3.position, 5 * combackSpeed * Time.deltaTime);//���� ��ġ�� �̵�

        }
    }
    void OnTriggerEnter(Collider other) //����� �� ȣ�� �Լ�
    {
        if (other.tag == "Target")//�÷��̾ ��Ҵٸ�
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
