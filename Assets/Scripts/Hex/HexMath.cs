using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class HexMath
{
    private const float INNER_RADIUS_OFFSET = 0.55f;
    private const float OUTER_RADIUS_OFFSET = 0.9f;

    //Make Double pointer array
    public static string[] cardinalDirections = {
        "north", "north-east", "east", "south-east",
        "south", "south-west", "west", "north-west"
    };

    public static Dictionary<string, Vector2> cardinalDistances = new Dictionary<string, Vector2>()
    {
        { "north-east", new Vector2(INNER_RADIUS_OFFSET, OUTER_RADIUS_OFFSET) },
        { "east", new Vector2(OUTER_RADIUS_OFFSET, 0) },
        { "south-east", new Vector2(INNER_RADIUS_OFFSET, -OUTER_RADIUS_OFFSET) },
        { "south-west", new Vector2(-INNER_RADIUS_OFFSET, -OUTER_RADIUS_OFFSET) },
        { "west", new Vector2(-OUTER_RADIUS_OFFSET, 0) },
        { "north-west", new Vector2(-INNER_RADIUS_OFFSET, OUTER_RADIUS_OFFSET) }
    };

    // Returns the oposite direction, by summing half the number of directions and wrapping around the array.
    public static string GetOpositeCardinalDirection(int directionIndex)
    {
        int opositeIndex = directionIndex + 4 > cardinalDirections.Length ? 
            Math.Abs(cardinalDirections.Length - (directionIndex + 4)) : 
            directionIndex + 4;

        return cardinalDirections[opositeIndex];
    }
}
