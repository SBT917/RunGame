using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    [SerializeField] BoxCollider attackCollider; //攻撃判定用のコライダー

    private void Awake()
    {
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable;
        if (other.TryGetComponent(out damageable)) {
            damageable.TakeDamage(1);
        }
    }

    public void Attack()
    {
        StartCoroutine(AttackCo());
    }

    //攻撃判定をon/offするコルーチン
    IEnumerator AttackCo()
    {
        attackCollider.enabled = true;
        yield return new WaitForSeconds(0.1f); //攻撃判定がonになった0.1秒後にoffにする
        attackCollider.enabled = false;
    }
}
