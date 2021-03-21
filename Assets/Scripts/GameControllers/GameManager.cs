using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Background[] bg;
    public GameObject obstaclePositions;
    public GameObject highScoreSystem;
    public TextMeshProUGUI highscore;
    public GameObject MainScreen;
    public GameObject score;
    public bool isAlive = true;
    void Start()
    {
        highscore.SetText(PlayerPrefs.GetInt("HighScore", 0).ToString());
        Debug.Log(ScreenInfo.isRestarted);
        if (ScreenInfo.isRestarted)
            MainScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            obstaclePositions.GetComponent<ObstacleSpawner>().enabled = true;
            highScoreSystem.GetComponent<HighScoreSystem>().enabled = false;
            Invoke("LoadScene", 1f);
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void initializeScene()
    {
        for (int i = 0; i < 2; i++)
        {
            bg[i].setScroll(true);
        }
        MainScreen.SetActive(false);
        score.SetActive(true);
        obstaclePositions.GetComponent<ObstacleSpawner>().enabled = true;
        highScoreSystem.GetComponent<HighScoreSystem>().enabled = true;
        isAlive = true;
    }
    public void exit()
    {
        Application.Quit();
    }
    public void settings()
    {
        Debug.Log("Settings");
    }
}
