using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerController : MonoBehaviour
{
    [SerializeField] private CubeController CubePrefab;
    private List<CubeController> CubePool;
    private int InitPoolSize = 3;
    private float SpawnDelay = 0f;
    private float LastSpawnTime = 0f;
    private float SpawnInterval;
    private float CubeTargetDistance;
    private float CubeSpeed;
    Coroutine SpawnRoutine;
    
    public void SetSpawnInterval(float spawnInterval)
    {
        SpawnInterval = spawnInterval;
        StopCoroutine(SpawnRoutine);
        SpawnRoutine = StartCoroutine(Spawn());
    }

    public void SetCubeTargetDistance(float targetDistance)
    {
        CubeTargetDistance = targetDistance;
    }

    public void SetCubeSpeed(float cubeSpeed)
    {
        CubeSpeed = cubeSpeed;
    }

    private void Start()
    {
        CubePool = new List<CubeController>();

        CubeController cube;
        for(int i = 0; i < InitPoolSize; i++)
        {
            cube = Instantiate(CubePrefab, transform);
            cube.gameObject.SetActive(false);
            CubePool.Add(cube);
        }
    }

    private void OnEnable()
    {
        SpawnRoutine = StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        SpawnDelay = SpawnInterval - (Time.time - LastSpawnTime);
    }

    private CubeController GetCubeFromPool()
    {
        foreach (CubeController pooledCube in CubePool) 
        {
            if(pooledCube.gameObject.activeSelf == false)
            {
                return pooledCube;
            }
        }

        CubeController cube = Instantiate(CubePrefab, transform);
        cube.gameObject.SetActive(false);
        CubePool.Add(cube);
        return cube;
    }
    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(SpawnDelay);

        while(gameObject.activeSelf)
        {
            SpawnCube();
            LastSpawnTime = Time.time;
            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    private void SpawnCube()
    {
        CubeController cube = GetCubeFromPool(); 
        cube.transform.position = transform.position;
        cube.SetTarget(CubeTargetDistance, CubeSpeed);
        cube.gameObject.SetActive(true);
    }
}
