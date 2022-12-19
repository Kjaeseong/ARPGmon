using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenuUI : MonoBehaviour
{
    private LobbyMainUI _main;

    private void Start() 
    {
        _main = GetComponentInParent<LobbyMainUI>();
    }

    public void InfoActivate()
    {
        _main.MonsterInfo.gameObject.SetActive(true);
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
        _main.Option.gameObject.SetActive(true);
    }

    public void InventoryActivate()
    {
        _main.Inventory.gameObject.SetActive(true);
    }

    public void StartAdventure()
    {
        GameManager.Instance.Scene.Change("03.Adventure");
    }
}
