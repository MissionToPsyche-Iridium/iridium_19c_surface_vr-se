using UnityEngine;

/// <summary>
/// Script for creating a play area of length and width 2 x _areaSize that is surrounded by colliders to keep the player in one area.
/// </summary>
public class BorderAdjuster : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject; //The object the play area is being made around.
    [SerializeField] private BoxCollider[] _colliders; //The 4 colliders that are meant to encapsulate the play area.
    [SerializeField] private float _areaSize; //This is the distance between the center of the area and the borders. AKA this is half the size of the length and width of the area.
    
    void Start()
    {
        setCenters();
        setSize();
    }

    /// <summary>
    /// Sets the center of the play area around the center of this object by setting the centers of the box colliders..
    /// </summary>
    private void setCenters()
    {
        _colliders[0].center = new Vector3(0, 0, _areaSize);
        _colliders[1].center = new Vector3(0, 0, -_areaSize);
        _colliders[2].center = new Vector3(_areaSize, 0, 0);
        _colliders[3].center = new Vector3(-_areaSize, 0, 0);
    }

    /// <summary>
    /// Sets the perimeters of the play area with the 4 colliders.
    /// </summary>
    private void setSize()
    {
        _colliders[0].size = new Vector3(2*_areaSize, 2*_areaSize, 1);
        _colliders[1].size = new Vector3(2*_areaSize, 2*_areaSize, 1);
        _colliders[2].size = new Vector3(1, 2*_areaSize, 2*_areaSize);
        _colliders[3].size = new Vector3(1, 2*_areaSize, 2*_areaSize);
    }
}
