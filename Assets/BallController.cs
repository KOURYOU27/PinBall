using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコア文を表示するテキスト
    private GameObject scoreText;
    //スコアの変数
    int score = 0;

    // Use this for initialization
    void Start () {

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //スコアの初期化
        score = 0;
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

    }
	
	// Update is called once per frame
	void Update () {

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

        }

    }

    void OnCollisionEnter(Collision collision)
    {

        // タグによって得点を変える
        if (collision.gameObject.tag == "SmallStarTag")
        {
            score += 1;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            score += 2;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            score += 3;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            score += 4;
        }


        //ScoreTextに表示
        this.scoreText.GetComponent<Text>().text = "SCORE = " + score;

    }


}
