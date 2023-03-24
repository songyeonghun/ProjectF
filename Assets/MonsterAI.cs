using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform target;
    public Transform firepoint;
    public Transform Target;
    public GameObject bulletPrefab;



    NavMeshAgent nav;

    float bulletForce = 20f;
    bool atack = false;
    bool AtkCool = false;



    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        nav = GetComponent<NavMeshAgent>();

        StartCoroutine("CoolDown");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, 2 * Time.deltaTime);

        // nav.SetDestination(target.position);
        if (atack == true && AtkCool == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);

            StartCoroutine("CoolDown");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            atack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            atack = false;
        }
    }

    void FollowTarget()
    {

                
    }

    IEnumerator CoolDown()
    {
        AtkCool = true;
        yield return new WaitForSeconds(1f);
        AtkCool = false;
    }


}
