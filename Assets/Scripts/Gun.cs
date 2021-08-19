using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private ParticleSystem[] arr_ps;
    private Vector3 rotation_effect = new Vector3(0f, 0f, 15f);
    private AudioSource audio;



    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        arr_ps = GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem tmp in arr_ps)
        {
            tmp.Play();
            tmp.gameObject.SetActive(false);
        }


    }

    public void PlayEffect()
    {
        StartCoroutine(ShowEffect());
        audio.PlayOneShot(audio.clip);
    }

    IEnumerator ShowEffect()
    {
        foreach (ParticleSystem tmp in arr_ps)
        {
            tmp.gameObject.SetActive(true);
            tmp.gameObject.transform.Rotate(rotation_effect);
        }

        yield return new WaitForSeconds(0.2f);

        foreach (ParticleSystem tmp in arr_ps)
        {
            tmp.gameObject.SetActive(false);
        }
    }




}
