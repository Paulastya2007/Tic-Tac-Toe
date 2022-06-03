using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour
{public void easyAI() {
        SceneManager.LoadScene("ai");
    }
    public void LocalMl()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void qit() {
        Application.Quit();
    }
    public void rettomen() {
        SceneManager.LoadScene("unt");
    }
    public void harai() {
        SceneManager.LoadScene("1Player");
    }
}
