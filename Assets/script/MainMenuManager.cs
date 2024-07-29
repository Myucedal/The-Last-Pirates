using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene(1);
    }
}
