using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class HighScoreScreen : MonoBehaviour
{
    TextMeshProUGUI highscore;
    private void Start()
    {
       highscore = GameObject.Find("HighScoreDisplay").GetComponent<TextMeshProUGUI>();
       highscore.SetText(PlayerPrefs.GetInt("HighScore", 0).ToString());
       Invoke("LoadScene", 5f);
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
