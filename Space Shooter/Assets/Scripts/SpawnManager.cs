using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawing = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnRoutine());
    }

    // Coroutine
    IEnumerator spawnRoutine()
    {
        while(_stopSpawing == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 7, 0);

            GameObject newEnemy =  Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);

            newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5);
        }

    }

    public void onPLayerDeath()
    {
        _stopSpawing = true;
    }
}
