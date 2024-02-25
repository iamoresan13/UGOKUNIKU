using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	//�v���C���[
	private GameObject Player;

	//�ړ���
	private float delta = 0.0f;

	//�J�����I�t�Z�b�g
	private float offset = 0.0f;

	//�J�����̑��x
	private float speed = 3.0f;

	// Start is called before the first frame update
	void Start()
	{
		//�v���C���[�̎擾
		Player = GameObject.Find("Meet");
	}

	// Update is called once per frame
	void Update()
	{
		// ���W�̎擾
		Vector3 position = this.transform.position;

		// �J�����̈ړ�
		delta = ((Player.transform.position.x + offset) - position.x) * speed;

		// �f���^���Z
		position.x += (delta * Time.deltaTime);

		// ���W�̍X�V
		this.transform.position = position;
	}
}












