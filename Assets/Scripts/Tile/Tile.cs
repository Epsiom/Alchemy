using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    private TileState _tileState;       // Status pattern

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    /// <summary>
    /// Changes the tile's element, which means changing its associated state instance
    /// </summary>
    /// <param name="newTileType">The new type of the tile</param>
    public void changeTileType(TileType newTileType)
    {
        switch(newTileType)
        {
            case TileType.AETHER:
                _tileState = new TileStateAether();
                break;
            case TileType.AIR:
                _tileState = new TileStateAir();
                break;
            case TileType.EARTH:
                _tileState = new TileStateEarth();
                break;
            case TileType.FIRE:
                _tileState = new TileStateFire();
                break;
            case TileType.WATER:
                _tileState = new TileStateWater();
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
