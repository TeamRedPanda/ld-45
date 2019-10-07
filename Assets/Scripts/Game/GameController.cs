using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[System.Serializable]
public class RoundSpawnInfo
{
    public int FistCount;
    public int SwordCount;
    public int BowCount;
    public int WandCount;
}

public class GameController : MonoBehaviour
{
    [SerializeField] private WeaponAsset[] m_WeaponAssets;
    [SerializeField] private RoundSpawnInfo[] m_SpawnInfos;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] m_EnemyPrefabs;

    [Header("Spawn points")]
    [SerializeField] private GameObject[] m_EnemySpawnPoints;
    [SerializeField] private GameObject m_PlayerSpawnPoint;

    [Header("References")]
    [SerializeField] private GameObject m_Player;
    [SerializeField] private GameObject m_WeaponSelectWindow;
    [SerializeField] private GameObject m_GameOverWindow;
    [SerializeField] private GameObject m_EnemySpawnParent;

    private int CurrentAliveEnemies = 0;
    private int CurrentRound = 0;

    void Awake()
    {
        StartRound();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGameOverScreen()
    {
        m_GameOverWindow.SetActive(true);
    }

    void SpawnEnemies()
    {
        var roundSpawnInfo = m_SpawnInfos[CurrentRound];

        int currentSpawnPoint = 0;

        // Fist enemies
        for (int i = 0; i < roundSpawnInfo.FistCount; i++) {
            SpawnEnemy(m_WeaponAssets[0], m_EnemySpawnPoints[currentSpawnPoint]);
            currentSpawnPoint++;
            CurrentAliveEnemies++;
        }

        // Sword enemies
        for (int i = 0; i < roundSpawnInfo.SwordCount; i++) {
            SpawnEnemy(m_WeaponAssets[1], m_EnemySpawnPoints[currentSpawnPoint]);
            currentSpawnPoint++;
            CurrentAliveEnemies++;
        }

        // Bow enemies
        for (int i = 0; i < roundSpawnInfo.BowCount; i++) {
            SpawnEnemy(m_WeaponAssets[2], m_EnemySpawnPoints[currentSpawnPoint]);
            currentSpawnPoint++;
            CurrentAliveEnemies++;
        }

        // Wand enemies
        for (int i = 0; i < roundSpawnInfo.WandCount; i++) {
            SpawnEnemy(m_WeaponAssets[3], m_EnemySpawnPoints[currentSpawnPoint]);
            currentSpawnPoint++;
            CurrentAliveEnemies++;
        }

        Debug.Log($"Current stage has {CurrentAliveEnemies} enemies.");
    }

    void SpawnEnemy(WeaponAsset weapon, GameObject spawnPoint)
    {
        int enemyPrefab = Random.Range(0, m_EnemyPrefabs.Length);

        var enemyGO = Instantiate(m_EnemyPrefabs[enemyPrefab], spawnPoint.transform.position, spawnPoint.transform.rotation, m_EnemySpawnParent.transform);
        enemyGO.GetComponent<ActorWeapon>().EquipWeapon(weapon);
        enemyGO.GetComponent<ActorHealth>().OnDeath.AddListener(OnEnemyDeath);
        enemyGO.GetComponent<ActorAI>().Player = m_Player;
        enemyGO.GetComponent<ActorAI>().Agent = weapon.AIAgent;
    }

    void OnEnemyDeath()
    {
        CurrentAliveEnemies--;

        Debug.Log($"Enemy died, {CurrentAliveEnemies} remaining.");

        if (CurrentAliveEnemies == 0) {
            m_WeaponSelectWindow.SetActive(true);
            CurrentRound++;
        }
    }

    void ClearEnemies()
    {
        foreach (Transform child in m_EnemySpawnParent.transform) {
            Destroy(child.gameObject);
        }

        CurrentAliveEnemies = 0;
    }

    public void OnWeaponSelected()
    {
        StartRound();
    }

    private void StartRound()
    {
        ClearEnemies();
        SpawnEnemies();

        // Reset player position
        m_Player.transform.position = m_PlayerSpawnPoint.transform.position;
        m_Player.transform.rotation = m_PlayerSpawnPoint.transform.rotation;
    }
}
