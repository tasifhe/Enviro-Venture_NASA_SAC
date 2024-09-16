using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnimator : MonoBehaviour
{
    [SerializeField]
    private Transform[] Positions;
    [SerializeField]
    private int currentTargetIndex;
    private Transform currentTarget;
    [SerializeField]
    private float speed=1f;
    void Start()
    {
        currentTarget = Positions[0];
    }

    void Update()
    {
        AnimatePlatform();
    }
    void AnimatePlatform()
    {
        if(transform.position == currentTarget.position)
        {
            currentTargetIndex++;
            if(currentTargetIndex >= Positions.Length)
            {
                currentTargetIndex = 0;
            }
            currentTarget = Positions[currentTargetIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
