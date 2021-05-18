using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IADamageTitan : MonoBehaviour
{
    public int lives = 100;
    private float _tempoInvocacao = 2f;
    private float _tempoIntervalo = 0f;
    private float _tempoUltima = 0f;
    private float _tempoAtaqueSeq1 = 2f;
    private float _tempoIntervaloSeq1 = 0f;
    private float _tempoUltimaSeq1 = 0f;
    private float _tempoAtaqueSeq2 = 2f;
    private float _tempoIntervaloSeq2 = 0f;
    private float _tempoUltimaSeq2 = 0f;
    private bool _portalOn = false;
    [SerializeField] Animator anim;
    // [SerializeField] GameObject item;
    [SerializeField] Transform _tfTitan;
    [SerializeField] Rigidbody _rbTitan;
    [SerializeField] GameObject _fxTeleporte;
    [SerializeField] private GameObject _minionsTitan;
    public GameObject projetil;
    public float timer = 1.0f;
    public float timer2 = 1f;
    public float velocidade = 0.007f;
    void Start()
    {
        anim.SetBool("Die", false);
        anim.SetBool("Ataque2",false);
        anim.SetBool("Ataque1",false);
    }
    void Update()
    {
        if (lives < 95 && lives > 80)
        {
            if (!_portalOn)
            {
                GameObject portal = Instantiate(_fxTeleporte, _tfTitan.position + Vector3.forward + Vector3.up * 2,
                    Quaternion.identity);
                _portalOn = true;
            }
            _rbTitan.constraints = RigidbodyConstraints.FreezePosition;
            _tempoIntervalo = Time.time - _tempoUltima;
            if (_tempoIntervalo >= _tempoInvocacao)
            {
                Instantiate(_minionsTitan, _tfTitan.position + Vector3.forward * 2 + Vector3.up * 2, Quaternion.identity);
                _tempoUltima = Time.time;
            }
        }

        if (lives < 80 && lives > 65)
        {
            if (_tempoIntervalo >= _tempoInvocacao)
            {
                if (_tempoIntervalo >= _tempoInvocacao)
                {
                    float dist = Vector3.Distance(_tfTitan.position,
                        GameObject.FindGameObjectWithTag("Player").transform.position);
                    if (dist < 5f && dist > 1f)
                    {
                        _tfTitan.position = new Vector3(Random.Range(-4.5f, 4.5f), 100f, Random.Range(350f, 450f));
                    }
                }
                _tempoUltima = Time.time;
            }
        }

        if (lives < 65 && lives > 50)
        {
            _tempoIntervaloSeq1 = Time.time - _tempoUltimaSeq1;
            if(_tempoIntervaloSeq1>=_tempoAtaqueSeq1)
            {
                if(_tempoIntervaloSeq1>=_tempoAtaqueSeq1)
                {
                    anim.SetBool("Attack",false);
                    anim.SetBool("Ataque1",true);
                }
                _tempoUltimaSeq1 = Time.time;
            }

        }

         if (lives < 50 && lives > 45)
        {
            _tempoIntervaloSeq2 = Time.time - _tempoUltimaSeq2;
            if(_tempoIntervaloSeq2>=_tempoAtaqueSeq2)
            {
                if(_tempoIntervaloSeq2>=_tempoAtaqueSeq2)
                {
                    anim.SetBool("Attack",false);
                    anim.SetBool("Ataque2", true);
                }
                _tempoUltimaSeq2 = Time.time;
            }

        }

        if (lives < 45 && lives > 30)
        {
            if (Time.timeScale == 1)
        {
            timer -= Time.deltaTime;

            //transform.Translate(Vector3.forward * velocidade);



            if (timer <= 0.0f)
            {
                GameObject currentball = Instantiate(projetil, transform.position + transform.forward, projetil.transform.rotation);
                currentball.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                transform.Rotate(0, 45, 0);

                GameObject currentball1 = Instantiate(projetil, transform.position + transform.forward, projetil.transform.rotation);
                currentball1.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                transform.Rotate(0, 45, 0);

                GameObject currentball2 = Instantiate(projetil, transform.position + transform.forward, projetil.transform.rotation);
                currentball2.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                transform.Rotate(0, 45, 0);

                GameObject currentball3 = Instantiate(projetil, transform.position + transform.forward, projetil.transform.rotation);
                currentball3.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                transform.Rotate(0, 45, 0);

                GameObject currentball4 = Instantiate(projetil, transform.position + transform.forward, projetil.transform.rotation);
                currentball4.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                transform.Rotate(0, 45, 0);

                GameObject currentball5 = Instantiate(projetil, transform.position + transform.forward, projetil.transform.rotation);
                currentball5.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                transform.Rotate(0, 45, 0);

                GameObject currentball6 = Instantiate(projetil, transform.position + transform.forward, projetil.transform.rotation);
                currentball6.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                transform.Rotate(0, 45, 0);

                GameObject currentball7 = Instantiate(projetil, transform.position + transform.forward, projetil.transform.rotation);
                currentball7.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                transform.Rotate(0, 45, 0);






                timer = 1.0f;

            }
        }
        }

        if (lives <= 0)
        {
            //Destroy(gameObject);
            anim.SetBool("Die", true);
            //StartCoroutine(PlayOneShot());
            //Instantiate(item, _tfTitan.position + Vector3.up * 2, Quaternion.identity);
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
}