using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class EnemyManager : MonoBehaviour
    {
        public List<Enemy> EnemiesInScene { get; private set; }
        public int NumberOfEnemies { get; private set; }
        public int EnemiesRemaining => EnemiesInScene.Count;

        private void Awake()
        {
            EnemiesInScene = new();
        }

        public void RegisterEnemy(Enemy t_instance)
        {
            EnemiesInScene.Add(t_instance);
            NumberOfEnemies++;
        }

        public void UnregisterEnemy(Enemy t_instance)
        {
            // Handles removing of killed enemies.
            EnemiesInScene.Remove(t_instance);
        }
    }
}