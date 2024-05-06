using UnityEngine;
public class GroundTile : MonoBehaviour {

    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject firePrefab;

	 
    private void Start () {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
	}

    private void OnTriggerExit (Collider other)
    {
        
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    private void Update () {

	}
    public void SpawnObstacle ()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
     public void SpawnFire ()
    {
     int fireToSpawn = 1;
        for (int i = 0; i < fireToSpawn; i++) {
            GameObject temp = Instantiate(firePrefab, transform);
            temp.transform.position = GetRandomPointInColliders(GetComponent<Collider>());
        }
    }
 Vector3 GetRandomPointInColliders (Collider collider)
    {
        Vector3 points = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (points != collider.ClosestPoint(points)) {
            points = GetRandomPointInColliders(collider);
        }

        points.y = 0;
        return points;
    }


    public void SpawnCoins ()
    {
        int coinsToSpawn = 3;
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}

