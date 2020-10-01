﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]

public class AvoidanceBehaviour : FilteredFlockBehaviour
{

    public float avoidanceMultiplier;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbours, return no adjustement
        if (context.Count == 0)
            return Vector2.zero;

        //add all points --> average
        Vector2 avoidanceMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {

            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius * avoidanceMultiplier)
            {
                nAvoid++;
                avoidanceMove += (Vector2)(agent.transform.position - item.position);
            }

        }

        if (nAvoid > 0)
        {
            avoidanceMove /= nAvoid;
        }

        avoidanceMove = Vector2.Lerp(agent.transform.up, avoidanceMove, context.Count/5f);
        return avoidanceMove;
    }
}
