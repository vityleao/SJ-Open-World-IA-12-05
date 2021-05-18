using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyParado : MonoBehaviour
{
    public float DistanciaTiro;
    void Start()
    {
        Destroy(gameObject, DistanciaTiro);
    }

    // Update is called once per frame
    void Update()
    {

    }

  //  private void OnCollisionEnter(Collision collision)
  //  {
  //      if (!collision.gameObject.CompareTag("Bala") && !collision.gameObject.CompareTag("Boss"))
  //      {
  //          Destroy(gameObject);
  //      }
  //  }
}
