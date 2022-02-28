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
    void Update( )//아이템 회전
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);//월드 축으로 일정한 속도로 회전
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")//플레이어와 닿았다면
        {
            Player player = other.GetComponent<Player>();
            if (this.tag == "DoubleJump")//아이템이 더블점프 태그라면
            {
                //player.ItemReset();
                player.howJump = 2;//점프 가능 개수 올리기
                gameObject.SetActive(false);//아이템 없애기
                player.isItem = true;
            }
            else if (this.tag == "Shield")//아이템이 생명 태그라면
            {
                //player.ItemReset();
                player.isShield = true;//생명 개수 올리기
                gameObject.SetActive(false);//아이템 없애기
                player.isItem = true;
            }
            else if (this.tag == "SpeedUp")//아이템이 속도증가 태그라면
            {
                player.basicSpeed = player.speed;//본래 속도 저장
                //player.ItemReset();
                player.speed += 20;//속도 올리기
                gameObject.SetActive(false);//아이템 없애기
                player.isItem = true;
            }
            else if (this.tag == "CoinX2")//아이템이 속도증가 태그라면
            {
                //player.ItemReset();
                player.isX2 = true;
                gameObject.SetActive(false);//아이템 없애기
                player.WaitingTime = 10;
                player.isItem = true;
            }
            else if (this.tag == "Coin")
            {
                if (player.isX2 == false)
                {
                    player.coin++;
                    gameObject.SetActive(false);//아이템 없애기
                }
                else
                {
                    player.coin += 2;//코인 2개씩 증가
                    gameObject.SetActive(false);//아이템 없애기
                }
            }
        }
    }

}
