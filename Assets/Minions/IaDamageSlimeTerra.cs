using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaDamageSlimeTerra : MonoBehaviour
{
    public int lives = 10;
    //public Animator anim;
    public GameObject Drop;
    void Start()
    {
        //anim.SetBool("Die", false);
    }
    void Update()
    {
        if (lives == 2)
        {
            FindObjectOfType<IaWalkSlimeTerra>().Super();
            Debug.Log("Imortal kkk");
        }
        
        else;
        
        if (lives <= 0)
        {
            Destroy(gameObject);
            //anim.SetBool("Die", true);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            lives--;
            //iastar.Damage();
            //anim.SetTrigger("Damage");
            return;
        }
    }
    public void ExplosionDamage()
    {
        lives = -1;
    }
}