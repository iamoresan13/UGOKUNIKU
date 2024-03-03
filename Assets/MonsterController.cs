using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator myAnimator;

    //�ړ�������R���|�[�l���g������i�ǉ��j
    Rigidbody2D myRigidbody;

    //�v���C���[
    private GameObject Player;

    //�^�C�}�[
    private float timeCounter = 0f;

    //�U������
    public GameObject AttackPrefab;
    
    //�A�j���[�V�����C�x���g�i�U���j
    public void Attack()
    {
        //Debug.Log("�U��");
        //����
        GameObject attack = Instantiate(AttackPrefab, transform.position + new Vector3(-0.5f*Mathf.Sign(transform.localScale.x), 0, 0), Quaternion.identity);

        Destroy(attack, 0.1f);

    }

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
        //�^�C�}�[
        timeCounter += Time.deltaTime;

        //�Ƃ肠����1�b�����Ƀ`�F�b�N
        if (timeCounter > 1.0f)
        {
            //�N���A�[
            timeCounter = 0f;

            //�v���C���[���߂��H
            if (getLength2D(transform.position, Player.transform.position) < 2.2f)
            {
                //�v���C���[�̈ʒu
                if(transform.position.x > Player.transform.position.x)
                {
                    //�v���C���[�����ɂ����@���摜��scale�T�C�Y�ɍ��킹�鎖
                    this.transform.localScale = new Vector2(0.7f, 0.7f);
                }
                else
                {
                    //�v���C���[���E�ɂ���
                    this.transform.localScale = new Vector2(-0.7f, 0.7f);
                }


                //�A�j���[�V����
                myAnimator.SetTrigger("Attack");
            }
        }
    }
}