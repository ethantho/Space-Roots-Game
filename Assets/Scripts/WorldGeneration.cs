using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldGeneration : MonoBehaviour
{
    public Sprite bg;
    public int planetstoSpawn, asteroidstoSpawn, enemiestoSpawn;
    public SpriteRenderer sr;
    public GameObject planetPrefab, asteroidPrefab;//, enemyPrefab;
    public KamikazeAI enemyPrefab;
    public BoxCollider2D[] borders;
    public GameObject enemyTarget;

    public List<GameObject> planets;
    [SerializeField] private Window_QuestPointer wqp;
    public ScoreBoard sb;

    // Start is called before the first frame update
    void Start()
    {
        int root = (int)Mathf.Sqrt((float)planetstoSpawn);
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = bg;

        float width = Mathf.Abs(bg.vertices[3].x - bg.vertices[2].x);
        float height = Mathf.Abs(bg.vertices[3].y - bg.vertices[2].y);

        borders[0].size = new Vector2(10, height);
        borders[1].size = new Vector2(10, height);
        borders[2].size = new Vector2(width, 10);
        borders[3].size = new Vector2(width, 10);

        borders[0].offset = new Vector2(width/2 - 20, 0);
        borders[1].offset = new Vector2(-width/2 + 20, 0);
        borders[2].offset = new Vector2(0, height/2 - 20);
        borders[3].offset = new Vector2(0, -height/2 + 20);

        //width /= 2;
        //height /= 2;

        enemyPrefab.target = enemyTarget.transform;

        SpawnPlanets();
        SpawnAsteroids();
        Debug.Log("Got past SpawnAsteroids()!");
        SpawnEnemies(0f);

        
        sb.totalPlanets = planets.Count;

        
        
        //sb.totalPlanets = planets.Length;
    }

    void SpawnPlanets()
    {
        int planetCount = 0;
        while (planetCount < planetstoSpawn)
        {
            float enemyRadius = 40;
            float x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 2.5f;
            float y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 2.5f;
            Vector2 spawnPoint = new Vector2(x, y);
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, enemyRadius, LayerMask.GetMask("Objects"));
            int count = 0;
            if (CollisionWithEnemy == false)
            {
                GameObject temp = Instantiate(planetPrefab, new Vector3(x, y, 0), Quaternion.identity);
                //(Planet)temp.
                float size = Random.Range(1.5f, 3.5f); //used to be 0.7f 2f

                //size = 1f;
                planets.Add(temp);
                Window_QuestPointer.QuestPointer qp = wqp.CreatePointer(temp.transform.position, temp.GetComponent<Planet>());
                temp.GetComponent<Rigidbody2D>().mass = 100 * size;
                temp.transform.localScale = new Vector3(size, size, 0);
                x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 2.5f;
                y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 2.5f;
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
        Debug.Log("Asteroids Spawning!");
        for (int i = 0; i < asteroidstoSpawn; i++)
        {
            float enemyRadius = 10;
            float x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 1;
            float y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 1;
            Vector2 spawnPoint = new Vector2(x, y);
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, enemyRadius, LayerMask.GetMask("Objects"));
            int count = 0;
            while (CollisionWithEnemy == false)
            {
                Debug.Log("SPAWN ASTEROID");
                int asteroidsToSpawn = Random.Range(1, 1);
                for (int a = 0; a < asteroidsToSpawn; a++)
                {
                    Vector2 asteroidSpawnPoint = spawnPoint + new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f)) * 0.5f;
                    Collider2D CollisionWithAsteroid = Physics2D.OverlapCircle(spawnPoint, 1, LayerMask.GetMask("Objects"));
                    //if (CollisionWithAsteroid == false)
                    //{
                        GameObject temp = Instantiate(asteroidPrefab, new Vector3(asteroidSpawnPoint.x, asteroidSpawnPoint.y, 0), Quaternion.identity);
                        float size = Random.Range(0.3f, 1.5f);
                        temp.GetComponent<Rigidbody2D>().mass = 5 * size;
                        temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)));
                        temp.transform.localScale = new Vector3(size, size, 0);
                        temp.SetActive(true);
                        temp.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, Random.Range(-180, 180)));
                    //}
                }
                count++;
                if (count > 10)
                {
                    break;
                }
            }
        }
        Debug.Log("Asteroids Spawned!");
    }

    public void SpawnEnemies(float mult)
    {
        int enemyCount = 0;
        while (enemyCount < enemiestoSpawn * mult)
        {
            float enemyRadius = 50;
            float x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 3;
            float y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 3;
            Vector2 spawnPoint = new Vector2(x, y);
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, enemyRadius, LayerMask.GetMask("Objects"));
            int count = 0;
            //if (CollisionWithEnemy == false)
            //{
                KamikazeAI temp = Instantiate(enemyPrefab, new Vector3(x, y, 0), Quaternion.identity);
                temp.target = enemyTarget.transform;
                //float size = Random.Range(0.7f, 2f);
                //size = 1f;
                //temp.GetComponent<Rigidbody2D>().mass = 100 * size;
                //temp.transform.localScale = new Vector3(size, size, 0);
                x = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 3;
                y = Random.Range(bg.vertices[3].x + 20, bg.vertices[2].x - 20) / 3;
                spawnPoint = new Vector2(x, y);
                count++;
                enemyCount++;
                if (count > 10)
                {
                    Destroy(temp);
                    break;
                }
            //}

        }
    }
}
