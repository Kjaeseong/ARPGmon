using UnityEngine;

public class TitleUI : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.Scene.Change("Lobby");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
