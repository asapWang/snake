using UnityEngine;
using System.Collections.Generic;
public class snakeScript : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments = new List<Transform>();

    public Transform segmentTransform;

    public int initiateSize = 8;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Restart();

    }

    void Restart()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);
        for (int i = 1; i < this.initiateSize; i++)
        {
            _segments.Add(Instantiate(this.segmentTransform));
        }

        this.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }

    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );
    }

    public void grow()
    {
        Transform segment = Instantiate(this.segmentTransform);

        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food")
        {
            grow();
        }
        if (collision.tag == "obstacle")
        {
            Restart();
        }
    }
}

