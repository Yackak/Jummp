using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")//�÷��̾�� ��Ҵٸ�
        {
            if (this.tag == "DoubleJump")//�������� �������� �±׶��
            {
                Player player = other.GetComponent<Player>();//�÷��̾� ������Ʈ ��������
                player.howJump = 2;//���� ���� ���� �ø���
                gameObject.SetActive(false);//������ ���ֱ�
            }
            else if(this.tag == "Health")//�������� ���� �±׶��
            {
                Player player = other.GetComponent<Player>();//�÷��̾� ������Ʈ ��������
                player.Health++;//���� ���� �ø���
                gameObject.SetActive(false);//������ ���ֱ�
            }
            else if(this.tag == "SpeedUp")//�������� �ӵ����� �±׶��
            {
                Player player = other.GetComponent<Player>();//�÷��̾� ������Ʈ ��������
                player.speed += 5;//�ӵ� �ø���
                gameObject.SetActive(false);//������ ���ֱ�
            }
        }
    }
}
