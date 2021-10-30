using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class GenerateLevelController
{
    private int[,] _map;
    private Tile _tileGround;
    private Tilemap _tilemapGround;
    private int _LenghtArray;

    public GenerateLevelController(Tile tile,Tilemap tilemap)
    {
        _tileGround = tile;
        _tilemapGround = tilemap;
        Createlevel();
        _LenghtArray = 25;
    }

    public void Createlevel()
    {
        _map = new int[_LenghtArray, _LenghtArray];

        for (int x = 0; x < _LenghtArray; x++)
        {
            for (int y = 0; y < _LenghtArray; y++)
            {
                var seed = Time.time.GetHashCode();
                var psevdorand = new System.Random(seed);
                //_map[x, y] = (psevdorand.Next(0, 100) < 70 ? 1 : 0);
                _map[x, y] = Random.Range(0, 2);
            }

            DrawTileMap();
        }
    }

    public void DrawTileMap()
    {
        if(_map == null) return;

        for (int x = 0; x < _LenghtArray; x++)
        {
            for (int y = 0; y < _LenghtArray; y++)
            {
                var positionTile = new Vector3Int(-_LenghtArray / 2 + x, -_LenghtArray / 2 + y, 0);

                if (_map[x, y] == 1)
                {
                    _tilemapGround.SetTile(positionTile, _tileGround);
                }
                
            }
        }
        
    }
}
