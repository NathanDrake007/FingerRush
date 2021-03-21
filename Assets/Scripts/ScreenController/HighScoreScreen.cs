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
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
        ScreenInfo.isRestarted = true;
    }
    public void back()
    {
        SceneManager.LoadScene(0);
        ScreenInfo.isRestarted = false;
    }
}
