using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BollController : MonoBehaviour
{
    float visiblePosZ = -6.5f;
    GameObject gameoverText;
    Text scoreText;
    int point = 0;
    int lgStarPoint = 10;
    int smStarPoint = 3;
    int smCloudPoint = 5;
    int lgCloudPoint = 30;
    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "LargeStarTag")
        {
            AddPoint(lgStarPoint);
        }
        else if (collision.collider.tag == "SmallStarTag")
        {
            AddPoint(smStarPoint);
        }
        else if(collision.collider.tag == "LargeCloudTag")
        {
            AddPoint(lgCloudPoint);
            Debug.Log(lgCloudPoint);
        }
        else if(collision.collider.tag == "SmallCloudTag")
        {
            AddPoint(smCloudPoint);
        }
    }
    void AddPoint(int addpoint)
    {
        point += addpoint;
        SetPoint();
    }
    void SetPoint()
    {
        scoreText.text = "SCORE:" + point;
    }
}

