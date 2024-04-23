using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPooler;

    public void SpawnCoins(Vector3 position, float groundWidht){

        int random = Random.Range(0,100);
        if(random < 50){return;}

        // генерация колличества монет по ширене платформы
        int numberOfCoins = (int) Random.Range(3f, groundWidht);

        // Создаем случайную высоту от земли для монет
        float y = Random.Range(0.5f, 3);

        for(int i = 0; i<numberOfCoins; i++){
            GameObject coin = coinPooler.GetPooledGameObject();

            //Расположение монет по платформе
            float x = position.x - (groundWidht/2) + 3;
            
            coin.transform.position = new Vector3(
                x + i,
                position.y + y,
                position.z
            );
            coin.SetActive(true);
        }
    }
}
