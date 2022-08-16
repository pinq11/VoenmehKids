using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public PlayerData player;

    private void Start()
    {
        player = FindObjectOfType<PlayerData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // если в хитбокс попал враг
        // помечаем его как доступного для атаки
        if (other.CompareTag("Enemy"))
        {
            player.AddEnemyForHit(other.transform.parent.gameObject.GetComponent<Skeleton>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // если врга вышел из хитбокса
        // помечаем его как недоступного для атаки
        if (other.CompareTag("Enemy"))
        {
            player.RemoveEnemyForHit(other.transform.parent.gameObject.GetComponent<Skeleton>());
        }
    }
}
