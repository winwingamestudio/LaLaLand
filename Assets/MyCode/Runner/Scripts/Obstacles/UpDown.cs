using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
  public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
      maxSpeed = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
      this.transform.position = new Vector3(this.transform.position.x, Mathf.Sin(Time.time * maxSpeed), this.transform.position.z);

    }
}
