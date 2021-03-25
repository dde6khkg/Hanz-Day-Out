using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class B2_test
    {
        [UnityTest]
        public IEnumerator B2_Test()
        {
            var Player = new GameObject();
            Player.gameObject.tag = "Player";
            Player.AddComponent<Rigidbody2D>();

            var gameObject = new GameObject();
            var enemy = gameObject.AddComponent<Enemy>();

            int i, Health = enemy.currentHealth;

            for(i = 7; i < 0; i--)
            {
                var eHealth = i;
                Assert.AreEqual(Health, eHealth);
            }

            yield return null;
        }
    }
}