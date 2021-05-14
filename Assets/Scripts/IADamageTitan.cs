using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IADamageTitan : MonoBehaviour
{
    public int lives = 10;
    public Animator anim;
    // public GameObject item;
    public Transform titan;
    void Start()
    {
        anim.SetBool("Die", false);
    }
    void Update()
    {
        if (lives <= 0)
        {
            //Destroy(gameObject);
            anim.SetBool("Die", true);
            //StartCoroutine(PlayOneShot());
            //Instantiate(item, titan.position + Vector3.up * 2, Quaternion.identity);
        }
    }
    /*
    public IEnumerator PlayOneShot()
    {
        anim.SetBool("Die", true);
        yield return .5f;
        anim.SetBool("Die", false);
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            lives--;
            anim.SetTrigger("Damage");
            return;
        }
    }
    public void ExplosionDamage()
    {
        lives = -1;
    }
}