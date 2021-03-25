using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Spawner_Test
    {
        [UnityTest]
        public IEnumerator Spawner_Test_One()
        {
            var gameObject = new GameObject();
            var spawner = gameObject.AddComponent<Enemy_Spawning>();

            yield return new WaitForSeconds(0);

            Assert.AreEqual(spawner.count, 0);

            yield return null;
        }
    }
}
