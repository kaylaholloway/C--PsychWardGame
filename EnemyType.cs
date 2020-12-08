using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class EnemyType
    {
        //EnemyType class provides access to all the Enemies in the game, providing a new instance 
        //of them whenever needed. 
        private Dictionary<int, IEnemy> allEnemies;
        public Dictionary<int,IEnemy> AllEnemies { get { return allEnemies; } }

        //private IEnemy[] enemyList = { new Rat(), new ZombiePatient(), new InfectedDoctor(), new InfectedNurse() }; 
        private IEnemy[] enemyList = { new Rat(), new InfectedDoctor(), new InfectedNurse(), new SecurityGuard(), new ZombiePatient() };
        
        public EnemyType()
        {
            allEnemies = new Dictionary<int, IEnemy>();
            for(int i = 0; i < enemyList.Length; i++)
            {
                allEnemies[i] = enemyList[i]; 
            }

        }
    }
}
