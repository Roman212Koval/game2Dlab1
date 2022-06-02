using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public Text scoreText;
    private int totalScore;
    public int scoreMultiplier;

    // Update is called once per frame
    /*  private void Update()
      {
          Debug.Log("Score");
          scoreText.text = ((int)(70 - totalScore / 2)).ToString();

      }*/
    private void FixedUpdate()
    {

        totalScore += scoreMultiplier;
        scoreText.text = totalScore.ToString();
    }

}
