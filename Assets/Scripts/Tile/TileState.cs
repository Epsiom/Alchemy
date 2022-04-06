using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileState
{
    public virtual TileType retrieveTileType()
    {
        return TileType.UNSET;
    }
}
