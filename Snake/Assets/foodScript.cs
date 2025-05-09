using UnityEngine;

public class foodScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BoxCollider2D box;
    void Start()
    {
        RandomizePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomizePosition()
    {
        Bounds bounds=this.box.bounds;
        float x=Random.Range(bounds.min.x,bounds.max.x);
        float y=Random.Range(bounds.min.y,bounds.max.y);
        this.transform.position=new Vector3(Mathf.Round(x),Mathf.Round(y),0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RandomizePosition();
        }

    }
}
