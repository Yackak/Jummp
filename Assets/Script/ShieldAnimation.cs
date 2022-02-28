using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimation : MonoBehaviour
{
    private Animator anim;
    private bool isenter;
    public float ratateSpeed = 50;
    float timer = 0;
    float WaitingTime = 3;
 
    void Start()
    {
        anim = GetComponent<Animator>();
        isenter = false;
        anim.SetBool("Isdo", false);
    }

    void Update()
    {
        if(isenter == false)
        {
            transform.Rotate(Vector3.up * ratateSpeed * Time.deltaTime, Space.World);//월드 축으로 일정한 속도로 회전
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > WaitingTime - 0.5)
            {
                isenter = true;
                timer = 0;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            isenter = true;
            anim.SetBool("Isdo", true);
        }
    }
}
