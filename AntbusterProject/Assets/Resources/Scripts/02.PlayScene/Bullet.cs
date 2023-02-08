using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    void Update()
    {
        //transform.localPosition += Vector3.up * speed * Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Turret")
        {
            GFunc.Log($"Bullet Trigger Test : {other.tag}");
            if (other.tag == "Enemy")
            {
                other.GetComponent<Enemy_Ant>().Hit(damage);
            }
            ObjectPoolManager.Instance.ObjPush(GData.BULLET_NAME, gameObject);
        }

    }
}
