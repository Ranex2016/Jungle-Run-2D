using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private AudioSource coinPickSound;
    private float coinPoints = 15f;
    private ScoreManager scoreManager;
    void Start()
    {
        coinPickSound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Специальная функция для проверки столкновения
    void OnTriggerEnter2D(Collider2D other) {
        
        // Если объект столкновения - игрок, то деативируем монету
        if(other.gameObject.name == "Player"){
            gameObject.SetActive(false);

            // Проверим воспроизводится ли звук подбора монеты
            if(coinPickSound.isPlaying){
                coinPickSound.Stop();
            }
            coinPickSound.Play();
            // Добавить подсчет монет
            scoreManager.score += coinPoints;
        }
    }

}
