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
        if(other.tag == "Player")//플레이어와 닿았다면
        {
            if (this.tag == "DoubleJump")//아이템이 더블점프 태그라면
            {
                Player player = other.GetComponent<Player>();//플레이어 컴포넌트 가져오기
                player.howJump = 2;//점프 가능 개수 올리기
                gameObject.SetActive(false);//아이템 없애기
            }
            else if(this.tag == "Health")//아이템이 생명 태그라면
            {
                Player player = other.GetComponent<Player>();//플레이어 컴포넌트 가져오기
                player.Health++;//생명 개수 올리기
                gameObject.SetActive(false);//아이템 없애기
            }
            else if(this.tag == "SpeedUp")//아이템이 속도증가 태그라면
            {
                Player player = other.GetComponent<Player>();//플레이어 컴포넌트 가져오기
                player.speed += 5;//속도 올리기
                gameObject.SetActive(false);//아이템 없애기
            }
        }
    }
}
