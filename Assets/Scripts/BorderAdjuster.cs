using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderAdjuster : MonoBehaviour
{
    private Terrain _terrain;

    private Vector3 _terrainTerrainDataVector3;

    private Vector3 _terrainGameObjectVector3;

    [SerializeField] private GameObject _gameObject;
    [SerializeField] private BoxCollider[] _colliders;
    [SerializeField] private float _areaSize;
    void Start()
    {
        setCenters();
        setSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void moveToCenter()
    {
        _terrain = FindObjectOfType<Terrain>();
        _terrainTerrainDataVector3 = _terrain.terrainData.size;
        _terrainGameObjectVector3 = _terrain.gameObject.transform.position;
        if (_gameObject != null)
        {
            Vector3 tempVector = new Vector3(_terrainTerrainDataVector3.x / 2, _terrainTerrainDataVector3.y / 2, _terrainTerrainDataVector3.z / 2);
            _gameObject.transform.position = _terrainGameObjectVector3 + tempVector;
        }
            
    }

    private void setCenters()
    {
        _colliders[0].center = new Vector3(0, 0, _areaSize);
        _colliders[1].center = new Vector3(0, 0, -_areaSize);
        _colliders[2].center = new Vector3(_areaSize, 0, 0);
        _colliders[3].center = new Vector3(-_areaSize, 0, 0);
    }

    private void setSize()
    {
        _colliders[0].size = new Vector3(2*_areaSize, _areaSize, 1);
        _colliders[1].size = new Vector3(2*_areaSize, _areaSize, 1);
        _colliders[2].size = new Vector3(1, _areaSize, 2*_areaSize);
        _colliders[3].size = new Vector3(1, _areaSize, 2*_areaSize);
    }
}
