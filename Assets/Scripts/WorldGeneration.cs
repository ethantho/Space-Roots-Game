using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public Sprite bg;
    public int planets, asteroids;
    public SpriteRenderer sr;
    public GameObject planetPrefab, asteroidPrefab;
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
        SpawnAsteroids();
        
    }

    void SpawnPlanets()
    {
        int planetCount = 0;
        while (planetCount < planets)
        {
            float enemyRadius = 10;
            float x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
            float y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
            Vector2 spawnPoint = new Vector2(x, y);
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, enemyRadius, LayerMask.GetMask("Objects"));
            int count = 0;
            if (CollisionWithEnemy == false)
            {
                GameObject temp = Instantiate(planetPrefab, new Vector3(x, y, 0), Quaternion.identity);
                float size = Random.Range(1f, 5f);
                //size = 1f;
                temp.GetComponent<Rigidbody2D>().mass = 10 * size;
                temp.transform.localScale = new Vector3(size, size, 0);
                x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
                y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
                spawnPoint = new Vector2(x, y);
                count++;
                planetCount++;
                if (count > 10)
                {
                    Destroy(temp);
                    break;
                }
            }
        }
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < asteroids; i++)
        {
            float enemyRadius = 30;
            float x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
            float y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20);
            Vector2 spawnPoint = new Vector2(x, y);
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, enemyRadius, LayerMask.GetMask("Objects"));
            int count = 0;
            while (CollisionWithEnemy == false)
            {

                int asteroidsToSpawn = Random.Range(1, 1);
                for (int a = 0; a < asteroidsToSpawn; a++)
                {
                    Vector2 asteroidSpawnPoint = spawnPoint + new Vector2(Random.Range(0f, 15f), Random.Range(0f, 15f));
                    Collider2D CollisionWithAsteroid = Physics2D.OverlapCircle(spawnPoint, 2, LayerMask.GetMask("Objects"));
                    if (CollisionWithAsteroid == false)
                    {
                        GameObject temp = Instantiate(asteroidPrefab, new Vector3(asteroidSpawnPoint.x, asteroidSpawnPoint.y, 0), Quaternion.identity);
                        float size = Random.Range(0.3f, 1.5f);
                        temp.GetComponent<Rigidbody2D>().mass = 5 * size;
                        temp.transform.localScale = new Vector3(size, size, 0);

                    }
                }
                count++;
                if (count > 10)
                {
                    break;
                }
            }
        }
    }

}