using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Uses Tarodev's tutorial: https://www.youtube.com/watch?v=kkAjpQAM-jE

    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    void Start()
    {
        GenerateGrid();
        //_cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);  // Centers the camera on the grid
    }

    void GenerateGrid() {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int z = 0; z < _height; z++) {
                Tile spawnedTile = Instantiate(_tilePrefab, new Vector3(x, -0.5f, z), Quaternion.identity);                   // Instanciates the tile
                Vector2 coordinates = new Vector2(x, z);
                spawnedTile.name = $"Tile {x} {z}";
                spawnedTile.coordinates = coordinates;
		        spawnedTile.stateChange.AddListener(PropagateStateChange);
                spawnedTile.Init();

                _tiles[coordinates] = spawnedTile;                                                                // Adds the tile to the dictionnary
            }
        }
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
    
    public void PropagateStateChange(Vector2 coordinates) {
    	Tile target = _tiles[coordinates];
    	GetTileAtPosition(new Vector2(coordinates.x, coordinates.y-1))?.ChangeTileType(target.retrieveTileType());
    	GetTileAtPosition(new Vector2(coordinates.x, coordinates.y+1))?.ChangeTileType(target.retrieveTileType());
    	GetTileAtPosition(new Vector2(coordinates.x-1, coordinates.y))?.ChangeTileType(target.retrieveTileType());
    	GetTileAtPosition(new Vector2(coordinates.x+1, coordinates.y))?.ChangeTileType(target.retrieveTileType());
    }
}
