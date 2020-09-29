using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controllers")]
    public bool canMove = true;

    [Header("Player Settings")]
    [Range(0, 100)] public int hp = 100;
    [Range(1, 5)] public float speed = 4;
    
    [Header("Player Stacks")]
    public int coins;
    public int keys;

    void Update()
    {
        // solo nos moveremos si (canMove igual a true) y (hp mayor a 0).
        if (canMove && hp > 0)
        {
           Move(); 
        }
    }

    void Move()
    {
        var hMove = Input.GetAxis("Horizontal");
        var vMove = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(hMove, 0, vMove) * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            coins++;
            Destroy(other.gameObject);
        }

        /*if (other.CompareTag("Keys"))
        {
            keys++;
            Destroy(other.gameObject);
        }*/
    }
}