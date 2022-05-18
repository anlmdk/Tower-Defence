using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public float speed;
    public float damage;
    public GameObject target, explosion;

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
            // other.GetComponent<EnemyHP>().TakeDamage(damage);
            Destroy (Instantiate(explosion, transform.position, Quaternion.identity), 2);
            Destroy(gameObject);
            Collider[] colls = Physics.OverlapSphere(transform.position, 7);
            foreach (var item in colls)
            {
                if (item.tag == "Enemy")
                {
                    item.GetComponent<EnemyHP>().TakeDamage(damage);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 7);
    }
}
