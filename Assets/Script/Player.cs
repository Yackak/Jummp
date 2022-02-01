using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    Transform playerTransform;//�÷��̾� ������ġ ����
    public int howJump;
    public int jumpCnt;
    public float speed;
    public float jumpPower;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//Player ��ġ ã��
        jumpCnt = howJump;

    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCnt < howJump && Input.GetButtonDown("Jump"))//����Ű�� ������ �� ����(������ fixedupdate���� ó���ϸ� �ȵ�)
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            jumpCnt++;
        }
        Vector3 moveVec = new Vector3(1, 0, 0).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)// �ѿ� ������� 
    {
        if (other.gameObject.tag == "Floor")//�ٴڿ� ������� ���� Ƚ�� �ʱ�ȭ
        {
            jumpCnt = 0;
        }
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Example1");
        }

    }

}
