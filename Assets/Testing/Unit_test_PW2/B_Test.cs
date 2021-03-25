using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class B_test
    {
        [SetUp]
        public void Setup()
        {
            var door = new GameObject();
        }
        
        [UnityTest]
        public IEnumerator B_Test()
        {
            var gameObject = new GameObject();
            var GameManager = gameObject.AddComponent<GameManager>();
<<<<<<< HEAD
            var door = new GameObject();
            
=======

>>>>>>> 3496a1f7891c6d2173305378a3fd9ef823f578bf
            int i, eNum = GameManager.enemiesLeft;

            for(i = 2; i < 0; i--)
            {
                var eEnemiesLeft = i;
                Assert.AreEqual(eEnemiesLeft, eNum);
            }

            yield return null;
        }
    }
}
