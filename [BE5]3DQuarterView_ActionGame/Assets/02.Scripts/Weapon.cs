using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type {Melee, Range};
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;

    public void Use()
    {
        if(type == Type.Melee)
        {
            if(type == Type.Melee)
            {
                StopCoroutine("Swing");
                StartCoroutine("Swing");
            }
        }
    }

    //Use() ���η�ƾ -> Swing() �����ƾ -> Use() ���η�ƾ
    //Use() ���η�ƾ + Swing() �ڷ�ƾ
    IEnumerator Swing()
    {
        // 1��
        yield return new WaitForSeconds(0.3f); // 0.1�� ���
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        // 2��
        yield return new WaitForSeconds(0.3f); // 0.1�� ���
        meleeArea.enabled = false;

        // 3��
        yield return new WaitForSeconds(0.3f); // 0.1�� ���
        trailEffect.enabled = false;

        // yield break; // �ڷ�ƾ Ż��
    }
}