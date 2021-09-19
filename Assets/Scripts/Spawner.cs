using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] arr_pos;
    public Aircraft_Enemy prefab_aircraft;
    public GameObject pos_Player;

    public float second_spawn_interval=3.5f;
    private float timer = 0f;

    private void Update()
    {
        if (GameManager.instance.flag_gameover || UIManager.instance.flag_menu_opened) return;

        timer += Time.deltaTime;
        if(second_spawn_interval <= timer)
        {
            timer = 0f;
            Aircraft_Enemy tmp;
            tmp = Instantiate(prefab_aircraft, arr_pos[Random.Range(0, arr_pos.Length)].position, Quaternion.identity);
            tmp = null;      
        }
    }
}
