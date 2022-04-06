using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStateAir : TileState
{
    public override TileType retrieveTileType()
    {
        return TileType.AIR;
    }
}
