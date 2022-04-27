using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Enum of all different tile types, each matching a state class
/// </summary>
public enum TileType
{
    UNSET,
    AETHER,
    AIR,
    EARTH,
    FIRE,
    WATER
}

[System.Serializable] public class _UnityEventVector2:UnityEvent<Vector2> {}

public class Tile : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private GameObject _highlight;
    public Vector2 coordinates;
    public _UnityEventVector2 stateChange;
    private TileState _tileState;       // Status pattern

    public void Init()
    {
        this.RandomlyAssignTileStateToTile();
        this._material = gameObject.GetComponent<Renderer>().material;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
	
	
    void OnMouseUp()
    {
    	ChangeTileType(TileType.AETHER);
    	stateChange.Invoke(coordinates);
    }
    /// <summary>
    /// Randomly picks an element for the tile (except UNSET and AETHER)
    /// </summary>
    /// <param name="tile"></param>
    public void RandomlyAssignTileStateToTile()
    {
        TileType randomTileType = (TileType)Random.Range(2, 6);     // Does not pick UNSET ans AETHER
        this.ChangeTileType(randomTileType);
    }

    /// <summary>
    /// Changes the tile's element, which means changing its associated state instance
    /// </summary>
    /// <param name="newTileType">The new type of the tile</param>
    public void ChangeTileType(TileType newTileType)
    {
        switch (newTileType)
        {
            case TileType.AETHER:
                _tileState = new TileStateAether();
                _material.color = new Color(0.2f, 0.074f, 0.52f);
                break;
            case TileType.AIR:
                _tileState = new TileStateAir();
                _material.color = new Color(0.68f, 0.76f, 0.82f);
                break;
            case TileType.EARTH:
                _tileState = new TileStateEarth();
                _material.color = new Color(0.64f, 0.37f, 0.19f);
                break;
            case TileType.FIRE:
                _tileState = new TileStateFire();
                _material.color = new Color(0.86f, 0.48f, 0.41f);
                break;
            case TileType.WATER:
                _tileState = new TileStateWater();
                _material.color = new Color(0.34f, 0.5f, 0.81f);
                break;
            case TileType.UNSET:
            default:
                throw new System.ArgumentOutOfRangeException(nameof(newTileType), newTileType, null);
        }
    }

    public TileType retrieveTileType()
    {
        return _tileState.retrieveTileType();
    }
}
