using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
	
	public GameObject prevCeiling;
	public GameObject prevFloor;
	public GameObject ceiling;
	public GameObject floor;
	
	public GameObject player;
	
	public GameObject obstacle1;
	public GameObject obstacle2;
	public GameObject obstacle3;
	public GameObject obstacle4;

	public GameObject character1;
	public GameObject character2;
	
	public GameObject obstaclePrefab;
	public GameObject A;
	public GameObject C;
	public GameObject E;

	public List<GameObject> displayCharacter = new List<GameObject>();
	
	public float minObstacleY;
	public float maxObstacleY;
	
	public float minObstacleSpacing;
	public float maxObstacleSpacing;
	
	public float minObstacleScaleY;
	public float maxObstacleScaleY;

	// Use this for initialization
	void Start () {
		displayCharacter.Add(A);
	    displayCharacter.Add(C);
	    displayCharacter.Add(E);
		obstacle1 = GenerateObstacle(player.transform.position.x + 10);
		obstacle2 = GenerateObstacle(obstacle1.transform.position.x);
		obstacle3 = GenerateObstacle(obstacle2.transform.position.x);
		obstacle4 = GenerateObstacle(obstacle3.transform.position.x);
		character1 = GenerateCharacter(obstacle1.transform.position.x);
		character2 = GenerateCharacter(obstacle4.transform.position.x);

	}
	
	GameObject GenerateObstacle(float referenceX) {
		GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
		SetTransform(obstacle,referenceX);
		return obstacle;
	}

	GameObject GenerateCharacter(float referenceX) {
		int num = Random.Range(0,3);
		GameObject obstacle = GameObject.Instantiate(displayCharacter[num]);
		SetTransformCharacter(obstacle,referenceX);
		return obstacle;
	}
	
	void SetTransform(GameObject obstacle, float referenceX) {
		obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObstacleY), 0);
		obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, Random.Range(minObstacleScaleY, maxObstacleY), obstacle.transform.localScale.z);
	}

	void SetTransformCharacter(GameObject obstacle, float referenceX) {
		obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObstacleY), 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > floor.transform.position.x) {
			var tempCeiling = prevCeiling;
			var tempFloor = prevFloor;
			prevCeiling = ceiling;
			prevFloor = floor;
			tempCeiling.transform.position += new Vector3(80, 0, 0);
			tempFloor.transform.position += new Vector3(80, 0, 0);
			ceiling = tempCeiling;
			floor = tempFloor;
		}
		
		if (player.transform.position.x > obstacle2.transform.position.x) {
			var tempObstacle = obstacle1;
			obstacle1 = obstacle2;
			obstacle2 = obstacle3;
			obstacle3 = obstacle4;
			SetTransform(tempObstacle, obstacle3.transform.position.x);
			obstacle4 = tempObstacle;
			if (player.transform.position.x > character2.transform.position.x){
				character1 = GenerateCharacter(obstacle2.transform.position.x);
		    	character2 = GenerateCharacter(obstacle4.transform.position.x);
			}
		}
	}
}
