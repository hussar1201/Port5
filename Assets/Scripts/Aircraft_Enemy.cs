using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft_Enemy : MonoBehaviour
{
    public GameObject pos_Player;
    public float speed = 30f;
    private Vector3 vec_heading;
    private AudioSource audio;
    public AudioClip clip_Fire;

    private float time_after_play_audio = 1f;
    private float timer_for_audio = 0f;
    private bool flag_clip_played = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8f);
        audio = GetComponent<AudioSource>();
        Vector3 tmp_pos_player = GameManager.instance.pos_Camera.transform.position;
        tmp_pos_player.y = transform.position.y;
        vec_heading = tmp_pos_player - transform.position;
        transform.LookAt(vec_heading);


    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.instance.flag_menu_opened) return;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timer_for_audio += Time.deltaTime;
        if (!flag_clip_played && timer_for_audio >= time_after_play_audio)
        {
            audio.PlayOneShot(clip_Fire);

            flag_clip_played = true;
            audio.PlayOneShot(audio.clip);
        }
    }

        



}
