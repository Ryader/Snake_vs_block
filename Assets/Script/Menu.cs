using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int index, nextIndex;
    public void Restart()
    {
        SceneManager.LoadScene(index);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Next()
    {
        SceneManager.LoadScene(nextIndex);
    }
}
