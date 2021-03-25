using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class B_test
    {
        [UnityTest]
        public IEnumerator B_Test()
        {
            var gameObject = new GameObject();
            var GameManager = gameObject.AddComponent<GameManager>();
            var door = new GameObject();

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
