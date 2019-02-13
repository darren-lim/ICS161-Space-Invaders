using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public static int Score;

    public TextMeshProUGUI HealthText;
    // Start is called before the first frame update
    void Start()
    {
        //ScoreText = GameObject.FindGameObjectWithTag("ScoreUI").GetComponent<TextMeshProUGUI>();
        Score = 0;
        ScoreText.text = "Score: " + Score;
    }
    
    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Lives: "+ShipLogic.lives.ToString();
    }
    
    public void AddScore(int points)
    {
        Score += points;
        ScoreText.text = "Score: " + Score;
    }
}
