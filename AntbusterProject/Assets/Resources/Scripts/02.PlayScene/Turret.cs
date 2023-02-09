using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject AttackRangeObject = default;
    public List<Transform> targets = default;
    public Transform target = default;
    public float frequency = default;
    public float attackRange = default;
    public int attackDamage = default;
    public float bulletSpeed = default;
    public float distance = default;
    void Start()
    {
        AttackRangeObject = transform.GetChild(0).gameObject;
        AttackRangeObject.ImageActive(false);
        AttackRangeObject.SetRectSizeDelta(attackRange * 2, attackRange * 2);
        AttackRangeObject.SetCircleColliderSize(attackRange);
        targets = new List<Transform>();
        StartCoroutine(Shoot());
    }
    void Update()
    {
        Targeting();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GFunc.Log($"TriggerTest : {other.tag}/{other.name} Enter");
        if (other.tag.Equals("Enemy"))
        {
            targets.Add(other.transform);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        GFunc.Log($"TriggerTest : {other.tag}/{other.name} Exit");
        if (other.tag.Equals("Enemy"))
        {
            targets.Remove(other.transform);
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {

            yield return new WaitForSeconds(1 / frequency);
            if (targets.Count < 1) continue;

            GameObject bullet = ObjectPoolManager.Instance.ObjPop("Bullet");
            GFunc.Log($"bullet shoot test : {bullet.name}");
            bullet.GetComponent<Bullet>().speed = bulletSpeed;
            bullet.GetComponent<Bullet>().damage = attackDamage;
            bullet.transform.localPosition = transform.localPosition;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }

    }
    public virtual void Targeting()
    {
        if (targets.Count < 1) return;
        float MaxDistance = 1000000;
        for (int i = 0; i < targets.Count; i++)
        {
            float distance = Vector3.SqrMagnitude(targets[i].localPosition - transform.localPosition);
            if (distance <= MaxDistance)
            {
                MaxDistance = distance;
                target = targets[i];
            }
        }
        transform.LookAt2D(target.localPosition, 10f);
    }

}