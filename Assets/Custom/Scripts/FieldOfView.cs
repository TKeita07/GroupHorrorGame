using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;
    public GameObject[] children;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    NavigationRound nav;

    private void Start()
    {
        nav = GetComponent<NavigationRound>();
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        if (nav.PauseRound){
            return;
        }
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        
        if (rangeChecks.Length != 0)
        {
            List<GameObject> visibleChildren = new List<GameObject>();

            foreach (Collider rangeCheck in rangeChecks)
            {
                Transform target = rangeCheck.transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    {
                        visibleChildren.Add(target.gameObject);
                    }
                }
            }

            if (visibleChildren.Count > 0)
            {
                canSeePlayer = true;
                children = visibleChildren.ToArray();
                print("Visible children count: " + children.Length);

                // Example: Chase the first visible child
                playerRef = children[0];
                nav.GetThatKid();
            }
            else
            {
                canSeePlayer = false;
                children = null;
            }
        }
        else
        {
            canSeePlayer = false;
            children = null;
        }

    }
}