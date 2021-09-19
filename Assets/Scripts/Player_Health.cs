using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    private AudioSource audio;
    public List<AudioClip> list_audioclips;
    public int hp
    {
        get;
        private set;
    }
   
    void Start()
    {
        audio = GetComponent<AudioSource>();
        hp = 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Aircraft_Enemy"))
        {
            StartCoroutine(PlayAudioClips());
            hp -= 10;
            if (hp <= 0)
            {
                hp = 0;
                GameManager.instance.GameOver();
            }
            UIManager.instance.ChangePlayerHP(hp);
        }
    }

    IEnumerator PlayAudioClips()
    {
        foreach (AudioClip tmp in list_audioclips)
        {
            audio.PlayOneShot(tmp);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
