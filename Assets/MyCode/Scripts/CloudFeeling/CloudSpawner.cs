using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class CloudSpawner: MonoBehaviour
    {
        public GameObject parent;
        public Vector2 HightOffset;
        public float startForce = 600;
        public float forceOffset = 200;
        public float forceRate;
        public int forceFactor = 0;
        public int dir;
        public float spwnRate;
        public float mAXspwnRate;
        public Transform[] spwnPoint;
        public GameObject[] clouds;

        private void OnEnable()
        {
            StartCoroutine(spwn());
        }

        public IEnumerator spwn()
        {
            while (true)
            {
                yield return new WaitForSeconds(spwnRate);
                var rand = Random.Range(0, clouds.Length-1);
                var spwn = spwnPoint[Random.Range(0, spwnPoint.Length - 1)];
                var cloud =  Instantiate(clouds[rand], new Vector3(spwn.position.x, spwn.position.y, 0), Quaternion.identity);
                cloud.transform.parent = parent.transform;
                cloud.GetComponent<Cloud>().speed = startForce + Random.Range(400, forceOffset) +(forceRate *  forceFactor++) ;
                cloud.GetComponent<Cloud>().direction = dir;
                cloud.GetComponent<Cloud>().force();
                spwnRate = Random.Range(0, mAXspwnRate);
                Random.seed = System.DateTime.Now.Millisecond;
            }


        }
    }
}
