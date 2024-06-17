using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private GameObject rockPrefab;
    private float xMax;
    private float yMax;
    // Start is called before the first frame update
    void Start()
    {
        yMax = Camera.main.orthographicSize;
        xMax = yMax * Camera.main.aspect;

        Instantiate(rockPrefab, new Vector2(xMax, yMax), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
