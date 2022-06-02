using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreRecord : MonoBehaviour
{

    [SerializeField] public Text recordText;
    // Start is called before the first frame update

    void Start()
    {
        int lastRunScore = PlayerPrefs.GetInt("lastRunScore");
        int recordScore = PlayerPrefs.GetInt("recordScore");
        
        if (lastRunScore > recordScore)
        {
            recordScore = lastRunScore;
            PlayerPrefs.SetInt("recordScore", recordScore);

            recordText.text = "Record: " + recordScore.ToString();
        }
        else
        {
            recordText.text = "Record: " + recordScore.ToString();
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
