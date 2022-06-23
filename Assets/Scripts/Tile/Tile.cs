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
    [SerializeField] private GameObject _highlight;

    private Material _material;
    public Vector2 coordinates;
    public _UnityEventVector2 stateChange;
    private TileState _tileState;       // Status pattern

    public void Init()
    {
        this._material = gameObject.GetComponent<Renderer>().material;
        _material.EnableKeyword("_EMISSION");
        this.RandomlyAssignTileStateToTile();
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        _material.DisableKeyword("_EMISSION");
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
    	var color = _material.color;
    	
        switch (newTileType)
        {
            case TileType.AETHER:
                _tileState = new TileStateAether();
                color = new Color(0.2f, 0.074f, 0.52f);
                break;
            case TileType.AIR:
                _tileState = new TileStateAir();
                color = new Color(0.68f, 0.76f, 0.82f);
                break;
            case TileType.EARTH:
                _tileState = new TileStateEarth();
                color = new Color(0.64f, 0.37f, 0.19f);
                break;
            case TileType.FIRE:
                _tileState = new TileStateFire();
                color = new Color(0.86f, 0.48f, 0.41f);
                break;
            case TileType.WATER:
                _tileState = new TileStateWater();
                color = new Color(0.34f, 0.5f, 0.81f);
                break;
            case TileType.UNSET:
            default:
                throw new System.ArgumentOutOfRangeException(nameof(newTileType), newTileType, null);
        }
        
        _material.color = color;
        _material.SetColor("_EmissionColor", new Color(0.2f, 0.074f, 0.52f, 0.00001f));
    }

    public TileType retrieveTileType()
    {
        return _tileState.retrieveTileType();
    }
}
