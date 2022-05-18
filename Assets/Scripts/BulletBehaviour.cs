using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float damage;
    public GameObject target;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
