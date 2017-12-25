﻿using System;
using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework.Constraints;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameObjectPool : MonoBehaviour
{
    public static GameObjectPool current;
    private List<GameObject> islandPool;
    private List<GameObject> ringPool;
    private List<GameObject> shipPool;

    void Awake()
    {
        current = this;
    }

    // Use this for initialization
	void Start ()
	{
        islandPool = new List<GameObject>();
	    ringPool = new List<GameObject>();
	    shipPool = new List<GameObject>();
        

        ///Pool islands
	    Object[] list = Resources.LoadAll("Islands");

	    for (int i = 0; i < list.Length; i++)
	    {
	        for (int j = 0; j < 3; j++)
	        {
	            GameObject obj = (GameObject) list[i];
	            obj.SetActive(false);
	            islandPool.Add(Instantiate(obj));
	        }
	    }


	    //Pool rings
	    list = Resources.LoadAll("Rings");

	    for (int i = 0; i < list.Length; i++)
	    {
	        for (int j = 0; j < 10; j++)
	        {
	            GameObject obj = (GameObject)list[i];
	            obj.SetActive(false);
	            ringPool.Add(Instantiate(obj));
	            Debug.Log(list[i].name);
            }
	    }

        //Pool ships
	    list = Resources.LoadAll("Ships");

	    for (int i = 0; i < list.Length; i++)
	    {
	        for (int j = 0; j < 3; j++)
	        {
	            GameObject obj = (GameObject)list[i];
	            obj.SetActive(false);
	            shipPool.Add(Instantiate(obj));
	            //Debug.Log(list[i].name);
	        }
	    }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetPooledIsland(string desiredObj)
    {
        foreach (var ob in islandPool)
        {
            //Debug.Log("Object in pool loop" + ob.name);

            if (desiredObj == ob.name && !ob.activeInHierarchy)
            {
                return ob;
            }
        }

        return null;
    }

    public GameObject GetPooledRing(string desiredObj)
    {
        foreach (var ob in ringPool)
        {   
            if (desiredObj == ob.name && !ob.activeInHierarchy)
            {
                return ob;
            }
            
        }

        return null;
    }

    public GameObject GetPooledShip(int index)
    {
        Debug.Log("Trying to spawn : " + shipPool[index] + "Out of "  + shipPool.Count );
        Debug.Log(index);

        return shipPool[index];
    }
}
