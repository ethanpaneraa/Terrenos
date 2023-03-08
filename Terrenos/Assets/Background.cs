using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float raiseVal;
    public GameObject player;
    private Vector2 playerPos;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {

        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        tr.position = new Vector2(0, playerPos.y+raiseVal);
    }
}
