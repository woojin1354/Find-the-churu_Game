using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public float gameSpeed = 2f;

    [SerializeField]
    private TextMeshProUGUI ScoreText;

    [SerializeField]
    private TextMeshProUGUI FinalScoreText;

    [SerializeField]
    private GameObject GameOverPanel;

    private float score = 0f;

    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Scoring()
    {
        score++;
        ScoreText.SetText(score.ToString());
        if (score % 2 == 0)
        {
            gameSpeed++;
        }
    }

    public void Fail() // 게임 오버 처리
    {
        CoinGenerator coinGenerator = FindAnyObjectByType<CoinGenerator>();
        if (coinGenerator != null)
        {
            coinGenerator.stopCoinGen();
        }

        Invoke("showGameOverPanel", 2f);
    }

    void showGameOverPanel()
    {
        FinalScoreText.SetText(score.ToString());
        GameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
