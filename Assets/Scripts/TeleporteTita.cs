using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporteTita : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //teste usando colisão pra ver se funciona; teria que substituir pela vida  
    private void OnTriggerEnter(Collider other) 
    {
        Teleporte();
    }

    public GameObject ParticleSystemTeleporte;
    public GameObject Titan;
    float espera = 5f;
        void Teleporte()
    {
        Instantiate(ParticleSystemTeleporte, transform.position, transform.rotation);
        ParticleSystemTeleporte.transform.parent = Titan.transform;
        espera -= Time.deltaTime; 
        transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
        espera -= Time.deltaTime;
        Destroy(ParticleSystemTeleporte);
    }
}
