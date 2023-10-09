using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab = null;
    [SerializeField] private GameStateController fsm = null;

    private Enemy enemy;

    public void CreateEnemy(string name)
    {
        enemy = Instantiate(enemyPrefab);
        enemy.Initialize(Random.Range(50, 100), name);
        enemy.IsDead.AddListener(RemoveEnemy);
    }


    private void RemoveEnemy()
    {
        Destroy(enemy.gameObject);
        fsm.SwitchState();
    }
}
