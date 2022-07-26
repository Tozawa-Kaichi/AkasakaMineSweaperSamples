using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // C# ���\�b�h�錾
    // �C���q �߂�l�^ ���\�b�h��(�p�����[�^���X�g) { �{�� }

    // �p�����[�^���󂯎�炸�A�߂�l��Ԃ��Ȃ����\�b�h
    // ���\�b�h���Ăяo�����ƁA�{�� { } �̃R�[�h�����s����
    // ���\�b�h���I������ƌĂяo�����ɐ��䂪�߂�
    private void M() { Debug.Log("M"); }

    void Start()
    {
        Debug.Log("Begin");
        M(); // M ���\�b�h�̌Ăяo��
        Debug.Log("End");


        // �Ăяo�����̓p�����[�^�ɑΉ�����l��n���K�v������
        M(1, 2);
        M(123, 456);

        // �߂�l�������\�b�h�̌Ăяo���́A���ʂ��󂯎���
        var r = Add(10, 20); // r �ϐ��ɖ߂�l������
        Debug.Log($"r={r}");

        // �������A�߂�l�𖳎����邱�Ƃ��ł���
        Add(123, 456); // OK

        M(10);//�ċN����
    }
    // �K�w�I�ȃ��\�b�h�̌Ăяo��
// ���\�b�h����A�ʂ̃��\�b�h�����R�ɌĂяo�����Ƃ��ł���
// ���\�b�h�𑽒i�K�ɌĂяo���Ă��A�K���ŏ��̌Ăяo�����܂ŕ��A����
    private void X()
    {
        Debug.Log("Begin X");
        Y();
        Debug.Log("End X");
    }
    private void Y()
    {
        Debug.Log("Begin Y");
        Z();
        Debug.Log("End Y");
    }
    private void Z() { Debug.Log("Z"); }

    // ���\�b�h �p�����[�^
    // ���\�b�h�͌Ăяo��������A�C�ӂ̒l���󂯎�邱�Ƃ��ł���B
    // �Ăяo�����́A���\�b�h�̎��s�ɕK�v�ȎQ�l�l�Ȃǂ�n����B
    // (�p�����[�^�^1 �p�����[�^��1, �p�����[�^�^2 �p�����[�^��2, ...)

    // int �^�̃p�����[�^ x �� y ���󂯎�郁�\�b�h
    private void M(int x, int y)
    {
        Debug.Log($"M x={x}, y={y}");
    }


    // ���\�b�h�̖߂�l
    // ���\�b�h�͏����̌��ʂ��Ăяo�����ɕԂ����Ƃ��ł���
    // �߂�l�^�� void �̏ꍇ�A�����Ԃ��Ȃ����Ƃ�\��
    // void �ȊO�̏ꍇ return ���Œl��Ԃ��Ȃ���΂Ȃ�Ȃ�
    private int Add(int x, int y)
    {
        Debug.Log($"Add x={x}, y={y}");
        return x + y; // x + y �����ʂƂ��ĕԂ�
    }

    //private void M()
    //{
    //    Debug.Log("M");

    //    // ���\�b�h�́A�������g���Ăяo�����Ƃ��ł���
    //    M(); // �������A���������Ɩ����Ɏ������Ăяo��������=>�������[�v
    //}

    private void M(int count)
    {
        if (count <= 0)
        {
            Debug.Log($"Return M: count={count}");
            return;
        }

        Debug.Log($"Begin M: count={count}");
        M(count - 1);
        Debug.Log($"End M: count={count}");
    }
}
