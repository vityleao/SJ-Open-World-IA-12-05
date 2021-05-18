using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaDamageSlimeFogo : MonoBehaviour
{
    public int lives = 10;
    //public IAStarFPS iastar;
    //public Animator anim;
    // Start is called before the first frame update
    public GameObject Drop;
    public Transform SlimeFogo;
    void Start()
    {
        //anim.SetBool("Die", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            Destroy(gameObject);
            //anim.SetBool("Die", true);
            Instantiate(Drop, SlimeFogo.position + Vector3.up * 2, Quaternion.identity);
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
