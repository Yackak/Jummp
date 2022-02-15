using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int isFirst;//ó�� �����ߴ°�? 1 == (ó�� ������), 0 == (�غ��� ����)
    public int ClearStage;//�� ��������
    public int CurrentStage;//���� ���� �ִ� ��������
    Player player;


    void Awake()
    {
        isFirst = PlayerPrefs.GetInt("isFirst");//ó�������ߴ��� �˾ƺ���
        CurrentStage = 0;//���� �������� �ʱ�ȭ
        if(isFirst == 0)//ó�� ������ �ƴ϶��
        {
            ContinueGame();
        }

    }

    void GameQuit()//�����ϱ�
    {
        if (isFirst == 1 && CurrentStage == 0) {//ó�� �����߰� ���� �ƹ� ���������� ���� �ʾ�����
            PlayerPrefs.SetInt("ClearStage", 0);//�� ���������� 0�̴�.
        }
        else//ó�� �������� �ʾҰų� � ���������� ���ٸ�
        {
            PlayerPrefs.SetInt("ClearStage", ClearStage);//Ŭ���� ���������� ����
            PlayerPrefs.SetInt("Coin", player.coin);//Ŭ���� ���������� ����
        }
        PlayerPrefs.SetInt("isFirst", 0);//������ �ߴٴ� ���� ����
    }
    void ContinueGame()//���� ���� �ҷ�����
    {
        ClearStage = PlayerPrefs.GetInt("ClearStage");//���� Ŭ���� �������� �ҷ�����
    }
    void StageClear()//���������� Ŭ���� �ߴٸ�
    {
        if(CurrentStage == ClearStage)//���� Ŭ���� ���������� ���� ���������� ���ٸ�
        {
            ClearStage++;//���� Ŭ���� �������� ����
            CurrentStage++;//���� ���������� �̵�
        }
    }
}
