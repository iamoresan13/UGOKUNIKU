using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderControllor : MonoBehaviour
{  
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator myAnimator;

    //�ړ�������R���|�[�l���g������i�ǉ��j
    Rigidbody2D myRigidbody;

    //�v���C���[
    private GameObject Player;


    //���������߂�i2D�j
    float getLength2D(Vector2 current, Vector2 target)
    {
        return Mathf.Sqrt(((current.x - target.x) * (current.x - target.x)) + ((current.y - target.y) * (current.y - target.y)));
    }

    //���������߂�i2D�j ���I�C���[�i-180�`0�`+180)
    float getEulerAngle2D(Vector2 current, Vector2 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg; //���W�A�����I�C���[
    }

    //���������߂�i2D�j �����W�A��
    float getRadian2D(Vector2 current, Vector2 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.y);
    }

    // Start is called before the first frame update
    void Start()
    {

        // �A�j���[�^�̃R���|�[�l���g���擾����
        this.myAnimator = GetComponent<Animator>();
        // Rigidbody2D�̃R���|�[�l���g���擾����
        this.myRigidbody = GetComponent<Rigidbody2D>();

        //�v���C���[�̎擾
        Player = GameObject.Find("Meet");

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[���߂Â�����ړ�
        if (getLength2D(transform.position, Player.transform.position) < 7.5f)
        {
            myRigidbody.velocity = new Vector3(-0.5f, myRigidbody.velocity.y, 0);
        }


          
        
    }
}
