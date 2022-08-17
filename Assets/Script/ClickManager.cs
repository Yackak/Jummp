using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private float clickTime;//클릭 중인 시간
    public float minClickTime = 1; //최소 클릭시간
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
            //롱 버튼
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
