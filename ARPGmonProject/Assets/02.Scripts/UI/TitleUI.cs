using UnityEngine;

public class TitleUI : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.Scene.Change("02.Lobby");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
