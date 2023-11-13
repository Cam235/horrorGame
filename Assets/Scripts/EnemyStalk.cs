using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStalk : MonoBehaviour
{
    public Transform player;
    public float followDistance = 5f;
    public float runAwayDistance = 2f;
    public float moveSpeed = 3f;

    void Update()
    {
        // Calculate the squared distance between the player and the enemy
        float sqrDistanceToPlayer = (player.position - transform.position).sqrMagnitude;

        // Check if the player is too close
        if (sqrDistanceToPlayer > runAwayDistance * runAwayDistance)
        {
            // Run away from the player
            Vector3 runDirection = transform.position - player.position;
            runDirection.Normalize();
            transform.Translate(runDirection * moveSpeed * Time.deltaTime);
        }
        else if (sqrDistanceToPlayer < followDistance * followDistance)
        {
            // Follow the player
            Vector3 moveDirection = player.position - transform.position;
            moveDirection.Normalize();
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
