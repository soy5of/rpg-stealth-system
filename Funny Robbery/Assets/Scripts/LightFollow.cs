using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    void Update()
    {
        Vector3 playerPosition = _player.transform.position;
        transform.position = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
        transform.LookAt(_player.transform);
    }
}
