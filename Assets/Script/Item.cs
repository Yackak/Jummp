using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//������ ȸ��
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);//���� ������ ������ �ӵ��� ȸ��
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
            else if(this.tag == "Coin")
            {
                Player player = other.GetComponent<Player>();//�÷��̾� ������Ʈ ��������
                player.coin++;
                gameObject.SetActive(false);//������ ���ֱ�
            }
        }
    }
}
