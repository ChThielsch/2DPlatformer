using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Range(0, 1)]
    [Tooltip("The ammount of parallax effect on a scale from 0-1")]
    public float parallaxEffect = 0;

    [Tooltip("The value of the sprites y position")]
    public float spriteHight = 0;

    private float _length;
    private float _startpos;

    /// <summary>
    /// Reference to the main camera
    /// </summary>
    private GameObject _camera;

    void Start()
    {
        _startpos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _camera = GameObject.Find("MainCamera");
    }

    void FixedUpdate()
    {
        //1 - parallaxEffect because its relative to the camera
        float temp = _camera.transform.position.x * (1 - parallaxEffect);
        float distance = _camera.transform.position.x * parallaxEffect;

        transform.position = new Vector3(_startpos + distance, spriteHight, transform.position.z);

        //repeats the sprite if out of bounds
        if (temp > _startpos + _length)
        {
            _startpos += _length;
        }
        else if(temp < _startpos - _length)
        {
            _startpos -= _length;
        }
    }
}
