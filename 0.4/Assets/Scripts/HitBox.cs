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
        // ���� � ������� ����� ����
        // �������� ��� ��� ���������� ��� �����
        if (other.CompareTag("Enemy"))
        {
            player.AddEnemyForHit(other.transform.parent.gameObject.GetComponent<Skeleton>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���� ���� ����� �� ��������
        // �������� ��� ��� ������������ ��� �����
        if (other.CompareTag("Enemy"))
        {
            player.RemoveEnemyForHit(other.transform.parent.gameObject.GetComponent<Skeleton>());
        }
    }
}
