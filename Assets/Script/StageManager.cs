using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int isFirst;//처음 시작했는가? 1 == (처음 시작함), 0 == (해본적 있음)
    public int ClearStage;//깬 스테이지
    public int CurrentStage;//현재 내가 있는 스테이지
    Player player;


    void Awake()
    {
        isFirst = PlayerPrefs.GetInt("isFirst");//처음시작했는지 알아보기
        CurrentStage = 0;//현재 스테이지 초기화
        if(isFirst == 0)//처음 시작이 아니라면
        {
            ContinueGame();
        }

    }

    void GameQuit()//저장하기
    {
        if (isFirst == 1 && CurrentStage == 0) {//처음 시작했고 아직 아무 스테이지도 들어가지 않았으면
            PlayerPrefs.SetInt("ClearStage", 0);//깬 스테이지는 0이다.
        }
        else//처음 시작하지 않았거나 어떤 스테이지를 들어갔다면
        {
            PlayerPrefs.SetInt("ClearStage", ClearStage);//클리어 스테이지를 저장
            PlayerPrefs.SetInt("Coin", player.coin);//클리어 스테이지를 저장
        }
        PlayerPrefs.SetInt("isFirst", 0);//게임을 했다는 것을 저장
    }
    void ContinueGame()//게임 정보 불러오기
    {
        ClearStage = PlayerPrefs.GetInt("ClearStage");//최종 클리어 스테이지 불러오기
    }
    void StageClear()//스테이지를 클리어 했다면
    {
        if(CurrentStage == ClearStage)//최종 클리어 스테이지와 현재 스테이지가 같다면
        {
            ClearStage++;//최종 클리어 스테이지 증가
            CurrentStage++;//다음 스테이지로 이동
        }
    }
}
