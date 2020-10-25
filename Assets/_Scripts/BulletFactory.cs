using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fatBullet;
    public GameObject pulsingBullet;

    public GameObject createBullet(BulletType type)
    {
        if (type == BulletType.RANDOM)
        {
            var randomBullet = Random.Range(0, 3);
            type = (BulletType)randomBullet;
        }

        GameObject tempBullet = null;
        switch (type)
        {
            case BulletType.REQULAR:
                tempBullet = Instantiate(bullet);
                break;
            case BulletType.FAT:
                tempBullet = Instantiate(fatBullet);
                break;
            case BulletType.PULSING:
                tempBullet = Instantiate(pulsingBullet);
                break;
        }

        tempBullet.transform.parent = transform;
        tempBullet.SetActive(false);
        return tempBullet;
    }
}

