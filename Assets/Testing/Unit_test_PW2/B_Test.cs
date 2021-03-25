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
            var door = new GameObject();
            var gameObject = new GameObject();
<<<<<<< HEAD
            var GameManager = gameObject.AddComponent<GameManager>();
            var door = new GameObject();
            
            int i, eNum = GameManager.enemiesLeft;
=======
            var OpenDoor = gameObject.AddComponent<OpenDoor>();

            int i, eNum = OpenDoor.enemiesLeft;
>>>>>>> 33c1fd03d3c101aa4200f3d04e5891e85ff09611

            for(i = 4; i < 0; i--)
            {
                var eEnemiesLeft = i;
                Assert.AreEqual(eEnemiesLeft, eNum);
            }

            yield return null;
        }
    }
}
