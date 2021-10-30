using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevelView : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemapGround;
    [SerializeField] private Tile _tileMap;
    [SerializeField] private bool _isActiveGenerator;
    private GenerateLevelController _generateLevelController;

    public Tilemap TilemapGround => _tilemapGround;
    public Tile TileMap => _tileMap;
    


    
    void Awake()
    {
        if (_isActiveGenerator)
        {
            _generateLevelController = new GenerateLevelController(_tileMap,_tilemapGround);
            _generateLevelController.Createlevel();
        }
        
    }
}
