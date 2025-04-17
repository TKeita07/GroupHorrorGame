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

    }

    void OnEnable()
    {
        nav = GetComponent<NavigationRound>();
        StartCoroutine(FOVRoutine());
        print("FOV started: ");
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            print("while loop");
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
         print("Range checks: " + nav.PauseRound);
        if (nav.PauseRound){
            return;
        }
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            print("Found something in range");
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
                        print("Found something in FOV: " + target.name);
                    }
                }
            }

            if (visibleChildren.Count > 0)
            {
                print("children found: " + visibleChildren.Count);
                canSeePlayer = true;
                children = visibleChildren.ToArray();

                // Example: Chase the first visible child
                playerRef = children[0];
                nav.StartChase(playerRef);
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