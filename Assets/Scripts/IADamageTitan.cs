using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IADamageTitan : MonoBehaviour
{
    public int lives = 100;
    private float _tempoInvocacao = 2f;
    private float _tempoIntervalo = 0f;
    private float _tempoUltima = 0f;
    private bool _portalOn = false;
    [SerializeField] Animator anim;
    // [SerializeField] GameObject item;
    [SerializeField] Transform _tfTitan;
    [SerializeField] Rigidbody _rbTitan;
    [SerializeField] GameObject _fxTeleporte;
    [SerializeField] private GameObject _minionsTitan;
    void Start()
    {
        anim.SetBool("Die", false);
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

        if (lives < 80)
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