using System;
using UnityEngine;
    public class Cloud: MonoBehaviour
    {
        public float speed;
        public float forceRate = 100;
        internal bool StopToForce = false;
        public int direction = 1;
        public Rigidbody rigidbody;
        public bool scoreGetting = false;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            force();

        }

        private void Update()
        {
          if(scoreGetting)
          {
            GameManager.Instance.GetScore();
            this.gameObject.SetActive(false);
            scoreGetting = false;
          }

        }

        void move()
        {
            if (!StopToForce)
            {
                if (direction == 1)
                {

                    rigidbody.velocity = Vector3.right * speed * Time.deltaTime;

                } else if (direction == -1)
                {
                    rigidbody.velocity = Vector3.left * speed * Time.deltaTime;
                }
            }
            else
            {
                rigidbody.velocity = Vector3.zero;

            }

        }

       public void force()
        {
            if (direction == 1)
            {

                rigidbody.AddForce(Vector3.right * speed * Time.deltaTime);

            } else if (direction == -1)
            {
                rigidbody.AddForce(Vector3.left * speed * Time.deltaTime);
            }
        }

       private void OnCollisionEnter(Collision other)
       {
           if (other.collider.CompareTag("character"))
           {
             Debug.Log("Collisin with character Happened");
             if(GameManager.Instance.energyHealthValue > 0)
             {
               Debug.Log("Decrese Heal");
               GameManager.Instance.HealingGone();
               this.gameObject.SetActive(false);
             }
             else
             FindObjectOfType<GameOver>().GOver();
           }
       }
    }
