using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    void Update()
    {
        //transform.localPosition += Vector3.up * speed * Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        ObjectPoolManager.Instance.ObjPush(GData.BULLET_NAME, gameObject);
    }
}
