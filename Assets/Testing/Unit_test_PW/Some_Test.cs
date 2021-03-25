using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


namespace Tests
{
    public class Some_test
    {
        GameObject bulletPrefab = Resources.Load("Bullet_Y") as GameObject;
        Shooting shooting;

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("Test_Level");
        }

        [UnityTest]
        [Timeout(1875)]
        public IEnumerator Some_Test()
        {
            int i, bulletAmount = 1159;

           for(i = 0; i < bulletAmount; i++)
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                rb.velocity = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)).normalized * 5f;
            }

            yield return new WaitForSeconds(1.2f);

            yield return null;
        }
    }
}
