using UnityEngine;
using TMPro;
public class HighScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;
    void Start()
    {
        scoreText.SetText(score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        score += (int)(Time.fixedDeltaTime * 100);
        scoreText.SetText(score.ToString());
    }
    public void setHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
