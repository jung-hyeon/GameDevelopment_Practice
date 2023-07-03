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

    //Use() 메인루틴 -> Swing() 서브루틴 -> Use() 메인루틴
    //Use() 메인루틴 + Swing() 코루틴
    IEnumerator Swing()
    {
        // 1번
        yield return new WaitForSeconds(0.3f); // 0.1초 대기
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        // 2번
        yield return new WaitForSeconds(0.3f); // 0.1초 대기
        meleeArea.enabled = false;

        // 3번
        yield return new WaitForSeconds(0.3f); // 0.1초 대기
        trailEffect.enabled = false;

        // yield break; // 코루틴 탈출
    }
}
