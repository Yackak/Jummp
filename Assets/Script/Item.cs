using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float rotateSpeed;

    // Start is called before the first frame update
    void Awake()
    {

    }   


    // Update is called once per frame
    void Update( )//������ ȸ��
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);//���� ������ ������ �ӵ��� ȸ��
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")//�÷��̾�� ��Ҵٸ�
        {
            Player player = other.GetComponent<Player>();
            if (this.tag == "DoubleJump")//�������� �������� �±׶��
            {
                //player.ItemReset();
                player.howJump = 2;//���� ���� ���� �ø���
                gameObject.SetActive(false);//������ ���ֱ�
                player.isItem = true;
            }
            else if (this.tag == "Shield")//�������� ���� �±׶��
            {
                //player.ItemReset();
                player.isShield = true;//���� ���� �ø���
                gameObject.SetActive(false);//������ ���ֱ�
                player.isItem = true;
            }
            else if (this.tag == "SpeedUp")//�������� �ӵ����� �±׶��
            {
                player.basicSpeed = player.speed;//���� �ӵ� ����
                //player.ItemReset();
                player.speed += 20;//�ӵ� �ø���
                gameObject.SetActive(false);//������ ���ֱ�
                player.isItem = true;
            }
            else if (this.tag == "CoinX2")//�������� �ӵ����� �±׶��
            {
                //player.ItemReset();
                player.isX2 = true;
                gameObject.SetActive(false);//������ ���ֱ�
                player.WaitingTime = 10;
                player.isItem = true;
            }
            else if (this.tag == "Coin")
            {
                if (player.isX2 == false)
                {
                    player.coin++;
                    gameObject.SetActive(false);//������ ���ֱ�
                }
                else
                {
                    player.coin += 2;//���� 2���� ����
                    gameObject.SetActive(false);//������ ���ֱ�
                }
            }
        }
    }

}
