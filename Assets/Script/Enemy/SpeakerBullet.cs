using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioClip Attack;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        //attackCount++;
        //Debug.Log("공격");
        //공격

        int roundNumA = 50;
        AudioSource.PlayClipAtPoint(Attack, transform.position);
        for (int index = 0; index < roundNumA; index++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundNumA), Mathf.Sin(Mathf.PI * 2 * index / roundNumA));
            rb.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        }

        Destroy(gameObject);
    }
}
