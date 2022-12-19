using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMainUI : MonoBehaviour
{
    [SerializeField] private StatusUI _status;
    [SerializeField] private LobbyMenuUI _menu;

    private void StatusUI(bool Active)
    {
        _status.gameObject.SetActive(Active);
    }

    private void LobbyMenuUI(bool Active)
    {
        _menu.gameObject.SetActive(Active);
    }

    



}
