using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> bullets = new List<GameObject>();

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private GameObject bulletPrefab;

    private void ChangeBullet()
    {
        if (bullets.Count > 0)
        {
            try
            {
                Destroy(bullets[0].gameObject);
                bullets.RemoveAt(0);
            }
            catch
            {

            }
           
            Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        }
        else if (bullets == null || bullets.Count == 0)
        {
            Actions.OnGameOver?.Invoke();
        }
    }

    private void OnEnable()
    {
        Actions.OnChangeBullet += ChangeBullet;
    }

    private void OnDisable()
    {
        Actions.OnChangeBullet -= ChangeBullet;
    }
}
