using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void LoadScene(string Hole1)
    {
        SceneManager.LoadScene(Hole1);
    }
}
