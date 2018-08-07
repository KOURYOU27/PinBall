using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    
    
    //タッチポジション宣言
    private static Vector2 TouchPosition;




    // Use this for initialization
    void Start () {

        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

    }
	
	// Update is called once per frame
	void Update () {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }


        //タッチがあるかどうか？
        if (Input.touchCount > 0)
        {

            for (int i = 0; i < Input.touchCount; i++)
            {

                Touch[] myTouches = Input.touches;

                //左半分タッチ直後
                if (myTouches[i].phase == TouchPhase.Began && myTouches[i].position.x < Screen.width / 2 && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                //左半分離した瞬間
                if (myTouches[i].phase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }

                //右半分タッチ直後
                if (myTouches[i].phase == TouchPhase.Began && myTouches[i].position.x >= Screen.width / 2 && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }

                //右半分離した瞬間
                if (myTouches[i].phase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }

        }


    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
