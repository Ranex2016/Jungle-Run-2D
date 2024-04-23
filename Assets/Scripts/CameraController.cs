using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Player player;
    private Vector3 lastPosition;
    private float distance; 
    private float hight;
    void Start()
    {
        // Находим игрока
        player = FindObjectOfType<Player>();
        // Задаем исходное положение на сцене
        lastPosition = player.transform.position;
    }

    void Update()
    {
        // Считаем дистанцию пройденую игроком
        distance = player.transform.position.x - lastPosition.x;
        //hight = player.transform.position.y - lastPosition.y;
        
        // Обновляем положение камеры
        transform.position = new Vector3(
            transform.position.x+distance,
            transform.position.y,
            transform.position.z
            );
            lastPosition = player.transform.position;
    }
}
