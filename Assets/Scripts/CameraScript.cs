using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;

    private float CameraSizeX = 14;
    private float CameraSizeY = 8;

    [SerializeField] private float Xmax;
    [SerializeField] private float Xmin;
    [SerializeField] private float Ymax;
    [SerializeField] private float Ymin;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (player)
        {
            Vector3 temp = transform.position;

            if (player.position.x + CameraSizeX < Xmax &&
                    player.position.x - CameraSizeX > Xmin)
                temp.x = player.position.x;

            if (player.position.y + CameraSizeY < Ymax &&
                    player.position.y - CameraSizeY > Ymin)
                temp.y = player.position.y;

            transform.position = temp;

        }
    }
}
