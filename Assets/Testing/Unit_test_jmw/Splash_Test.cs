using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Missile_explode_test
    {
        [UnityTest]
        public IEnumerator Missile_Explosion_Test()
        {
            var gameObject = new GameObject();
            var missile = gameObject.AddComponent<Missile>();

            var expected_splash = 2;

            int splash = missile.SplashCalc(1, 10);
            Assert.AreEqual(expected_splash, splash);

            yield return null;
        }
    }
}
