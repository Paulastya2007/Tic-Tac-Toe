using UnityEngine.SceneManagement;
using UnityEngine;

public class ai_script : MonoBehaviour
{
    public GameObject m ,s;
    void Start() {
       m.SetActive(false); s.SetActive(false);
        Time.timeScale = 1;
    }
    
    void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            m.SetActive(true); s.SetActive(true);
        }
    }
  public  void pressed() {
        m.SetActive(false); s.SetActive(false);
    }
   public void restart() {
        SceneManager.LoadScene("1Player");
    }
    public void ManinMenu() {
        SceneManager.LoadScene("unt");
    
    }
}
