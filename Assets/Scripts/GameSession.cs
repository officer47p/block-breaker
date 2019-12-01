using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(min: 0, max: 2)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] int totalPlayerScore = 0;

    private void Awake()
    {
        int numberOfGameStatus = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameStatus > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = totalPlayerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddScore()
    {
        totalPlayerScore += pointsPerBlock;
        scoreText.text = totalPlayerScore.ToString();
    }

    public void EndGame()
    {
        Destroy(gameObject);
    }
}
