using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStateWater : TileState
{
    public override TileType retrieveTileType()
    {
        return TileType.WATER;
    }
}
