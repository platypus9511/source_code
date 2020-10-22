using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    public Switch _switch;
    public int _cubeCount = 0;
    public int _cubeCountMax = 1;


    void Update()
    {
        
    }



    public void pipeTurnOn()
    {   
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        if (_cubeCount < _cubeCountMax)
        {
            GameObject CubePrefab = Resources.Load("cube") as GameObject;
            GameObject cube = Instantiate(CubePrefab);
            Vector2 pipePos = gameObject.transform.position;
            CubePrefab.transform.position = new Vector2(pipePos.x, pipePos.y);
            _cubeCount++;

            cube c = cube.GetComponent<cube>();
            TrapManager.Instance._cubes.Add(c);
        }

        //TrapManager의 리스트에 넣어주기
        // cube c = cube.GetComponent<cube>();
        //TrapManager.Instance._cubes.Add(c);
    }

 
    public void pipeTurnOff()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;     
    }

}
