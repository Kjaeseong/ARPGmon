using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenuUI : MonoBehaviour
{
    public void InfoActivate()
    {

    }

    public void Feed()
    {
        // TODO : 먹이 먹는 연출 추가, 배고픔 수치 채우기
    }

    public void Training()
    {
        // TODO : 훈련하는 연출 추가, 경험치 증가
    }

    public void OptionActivate()
    {

    }

    public void InventoryActivate()
    {

    }

    public void StartAdventure()
    {
        GameManager.Instance.Scene.Change("03.Adventure");
    }
}
