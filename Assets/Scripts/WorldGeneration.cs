using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public Sprite bg;
    public int planets, asteroids;
    public SpriteRenderer sr;
    public GameObject planetPrefab;
    public GameObject spawner;
    public BoxCollider2D[] borders;

    // Start is called before the first frame update
    void Start()
    {
        int root = (int)Mathf.Sqrt((float)planets);
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = bg;

        float width = Mathf.Abs(bg.vertices[3].x - bg.vertices[2].x);
        float height = Mathf.Abs(bg.vertices[3].y - bg.vertices[2].y);

        borders[0].size = new Vector2(10, height);
        borders[1].size = new Vector2(10, height);
        borders[2].size = new Vector2(width, 10);
        borders[3].size = new Vector2(width, 10);

        borders[0].offset = new Vector2(width/2 - 5, 0);
        borders[1].offset = new Vector2(-width/2 + 5, 0);
        borders[2].offset = new Vector2(0, height/2 - 5);
        borders[3].offset = new Vector2(0, -height/2 + 5);

        

        SpawnPlanets();
        
    }

    void SpawnPlanets()
    {
        for (int i = 0; i < planets; i++)
        {
            float enemyRadius = 30;
            float x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
            float y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
            Vector2 spawnPoint = new Vector2(x, y);
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, enemyRadius, LayerMask.GetMask("Objects"));
            if (CollisionWithEnemy == false)
            {
                GameObject temp = Instantiate(planetPrefab, new Vector3(x, y, 0), Quaternion.identity);
                float size = Random.Range(0.5f, 5f);
                size = 1f;
                temp.GetComponent<Rigidbody2D>().mass = 10 * size;
                temp.transform.localScale = new Vector3(size, size, 0);
            }
        }
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < asteroids; i++)
        {
            float enemyRadius = 40;
            float x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
            float y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
            Vector2 spawnPoint = new Vector2(x, y);
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, enemyRadius, LayerMask.GetMask("Objects"));
            if (CollisionWithEnemy == false)
            {
                GameObject temp = Instantiate(planetPrefab, new Vector3(x, y, 0), Quaternion.identity);
                float size = Random.Range(0.5f, 5f);
                size = 1f;
                temp.GetComponent<Rigidbody2D>().mass = 10 * size;
                temp.transform.localScale = new Vector3(size, size, 0);
            }
        }
    }

}
