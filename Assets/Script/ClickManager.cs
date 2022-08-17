using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private float clickTime;//Ŭ�� ���� �ð�
    public float minClickTime = 1; //�ּ� Ŭ���ð�
    private bool isClick = false;
    public Player player;

    // Start is called before the first frame update
    public void ButtonDown()
    {
        isClick = true;
    }
    public void ButtonUp()
    {
        isClick = false;
        
        if(clickTime >= minClickTime)
        {
            //�� ��ư
        }
        else
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isClick)
        {
            clickTime += Time.deltaTime;
        }
        else
        {
            clickTime = 0;
        }
    }
}
