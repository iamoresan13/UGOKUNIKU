using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderControllor : MonoBehaviour
{  
    //アニメーションするためのコンポーネントを入れる
    Animator myAnimator;

    //移動させるコンポーネントを入れる（追加）
    Rigidbody2D myRigidbody;

    //プレイヤー
    private GameObject Player;


    //距離を求める（2D）
    float getLength2D(Vector2 current, Vector2 target)
    {
        return Mathf.Sqrt(((current.x - target.x) * (current.x - target.x)) + ((current.y - target.y) * (current.y - target.y)));
    }

    //方向を求める（2D） ※オイラー（-180～0～+180)
    float getEulerAngle2D(Vector2 current, Vector2 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg; //ラジアン→オイラー
    }

    //方向を求める（2D） ※ラジアン
    float getRadian2D(Vector2 current, Vector2 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.y);
    }

    // Start is called before the first frame update
    void Start()
    {

        // アニメータのコンポーネントを取得する
        this.myAnimator = GetComponent<Animator>();
        // Rigidbody2Dのコンポーネントを取得する
        this.myRigidbody = GetComponent<Rigidbody2D>();

        //プレイヤーの取得
        Player = GameObject.Find("Meet");

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが近づいたら移動
        if (getLength2D(transform.position, Player.transform.position) < 7.5f)
        {
            myRigidbody.velocity = new Vector3(-0.5f, myRigidbody.velocity.y, 0);
        }


          
        
    }
}
