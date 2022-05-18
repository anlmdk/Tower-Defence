using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public float attackDistance;
    GameObject target = null;
    public GameObject head, bulletTip;
    public GameObject bulletPrefab;
    public float attackSpeed, attackTimer;
    public ParticleSystem particleSystem;

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (target == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var item in enemies)
            {
                if (Vector3.Distance(transform.position, item.transform.position) < attackDistance)
                {
                    target = item;
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
            {
                head.transform.LookAt(target.transform.position + Vector3.up);
                Shoot();
            }
            else
            {
                target = null;
            }
        }
    }
    void Shoot()
    {
        if (attackTimer > attackSpeed)
        {
            attackTimer = 0;
            if (particleSystem != null)
            {
                particleSystem.Play();
            }
            GameObject insteadPrefab = Instantiate(bulletPrefab, bulletTip.transform.position, bulletTip.transform.rotation);
            if (insteadPrefab.TryGetComponent(out BulletBehaviour bBehav))
            {
                bBehav.target = target;
            }
            else if (insteadPrefab.TryGetComponent(out RocketBehaviour rBehav))
            {
                rBehav.target = target;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
