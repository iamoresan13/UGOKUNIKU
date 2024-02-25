using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	//プレイヤー
	private GameObject Player;

	//移動量
	private float delta = 0.0f;

	//カメラオフセット
	private float offset = 0.0f;

	//カメラの速度
	private float speed = 3.0f;

	// Start is called before the first frame update
	void Start()
	{
		//プレイヤーの取得
		Player = GameObject.Find("Meet");
	}

	// Update is called once per frame
	void Update()
	{
		// 座標の取得
		Vector3 position = this.transform.position;

		// カメラの移動
		delta = ((Player.transform.position.x + offset) - position.x) * speed;

		// デルタ加算
		position.x += (delta * Time.deltaTime);

		// 座標の更新
		this.transform.position = position;
	}
}












