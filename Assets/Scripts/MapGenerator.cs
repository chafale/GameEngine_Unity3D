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
	public GameObject B;	
	public GameObject C;
	public GameObject D;
	public GameObject E;
	public GameObject F;
	public GameObject G;
	public GameObject H;
	public GameObject I;
	public GameObject J;
	public GameObject K;
	public GameObject L;
	public GameObject M;
	public GameObject N;
	public GameObject O;
	public GameObject P;
	public GameObject Q;
	public GameObject R;
	public GameObject S;
	public GameObject T;
	public GameObject U;
	public GameObject V;
	public GameObject W;
	public GameObject X;
	public GameObject Y;
	public GameObject Z;
	
	
	public static List<GameObject> displayCharacter = new List<GameObject>();

	public float minObstacleY;
	public float maxObstacleY;

	public float minObstacleSpacing;
	public float maxObstacleSpacing;

	public float minObstacleScaleY;
	public float maxObstacleScaleY;

	// Use this for initialization
	void Start () {
		displayCharacter.Add(A);
		displayCharacter.Add(B);
	    displayCharacter.Add(C);
	    displayCharacter.Add(D);
		displayCharacter.Add(E);
		displayCharacter.Add(F);
		displayCharacter.Add(G);
        displayCharacter.Add(H);
	    displayCharacter.Add(I);
        displayCharacter.Add(J);
        displayCharacter.Add(K);
		displayCharacter.Add(L);
        displayCharacter.Add(M);
	    displayCharacter.Add(N); 
	    displayCharacter.Add(O);
	    displayCharacter.Add(P);
		displayCharacter.Add(Q);
        displayCharacter.Add(R);
	    displayCharacter.Add(S);
        displayCharacter.Add(T);
        displayCharacter.Add(U);
		displayCharacter.Add(V);
		displayCharacter.Add(W);
        displayCharacter.Add(X);
        displayCharacter.Add(Y);
		displayCharacter.Add(Z);
		obstacle1 = GenerateObstacle(player.transform.position.x + 10);
		obstacle2 = GenerateObstacle(obstacle1.transform.position.x);
		obstacle3 = GenerateObstacle(obstacle2.transform.position.x);
		obstacle4 = GenerateObstacle(obstacle3.transform.position.x);
		character1 = GenerateCharacter(obstacle1.transform.position.x, obstacle2.transform.position.x, obstacle1.transform.position.x, obstacle2.transform.position.x, obstacle3.transform.position.x, obstacle4.transform.position.x);
		character2 = GenerateCharacter(obstacle3.transform.position.x, obstacle4.transform.position.x, obstacle1.transform.position.x, obstacle2.transform.position.x, obstacle3.transform.position.x, obstacle4.transform.position.x);
	}

	GameObject GenerateObstacle(float referenceX) {
		GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
		SetTransform(obstacle,referenceX);
		return obstacle;
	}

	GameObject GenerateCharacter(float start, float end, float obj1, float obj2, float obj3, float obj4) {
		int num = Random.Range(0,displayCharacter.Count);
		GameObject obstacle = GameObject.Instantiate(displayCharacter[num]);
		SetTransformCharacter(obstacle,start,end);

		//Debug.Log(obstacle.transform.position.x + " " +  obj1 + " " + obj2 + " " + obj3 + " " + obj4);
		// Debug.Log(obstacle.transform.position.x + " " + dist1 + " " + dist2 + " " + dist3 + " " + dist4);

	  float dist1 = Mathf.Abs(obstacle.transform.position.x - obj1);
		float dist2 = Mathf.Abs(obstacle.transform.position.x - obj2);
		float dist3 = Mathf.Abs(obstacle.transform.position.x - obj3);
		float dist4 = Mathf.Abs(obstacle.transform.position.x - obj4);

		if(dist1<1){
			Debug.Log("1 " + obstacle.tag);
			Destroy(obstacle);
			return null;
		}
		else if(dist2<1){
			Debug.Log("2" + obstacle.tag);
			Destroy(obstacle);
			return null;
		}
		else if(dist3<1){
			Debug.Log("3" + obstacle.tag);
			Destroy(obstacle);
			return null;
		}
		else if(dist4<1){
			Debug.Log("4" + obstacle.tag);
			Destroy(obstacle);
			return null;
		}

		return obstacle;

		// var checkCollider = Physics2D.OverlapCircle(obstacle.transform.position, 1);
		// if (checkCollider != null && checkCollider.transform != obstacle.transform)
		// {
		// 	Destroy(obstacle);
		// 	return null;
		// }
		// SetTransformCharacter(obstacle,start,end);
		// return obstacle;

		// Collider2D[] neighbours = Physics2D.OverlapCircleAll(obstacle.transform.position, 4);
		// if (neighbours.Length>0){
		// 	Debug.Log(neighbours.Length);
		// 	Destroy(obstacle);
		// 	return null;
		// }
		// else{
		// 	SetTransformCharacter(obstacle,start,end);
		// 	return obstacle;
		// }
	}

	void SetTransform(GameObject obstacle, float referenceX) {
		obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObstacleY), 0);
		obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, Random.Range(minObstacleScaleY, maxObstacleY), obstacle.transform.localScale.z);
	}

	void SetTransformCharacter(GameObject obstacle, float start, float end) {
		obstacle.transform.position = new Vector3(Random.Range(start, end), Random.Range(minObstacleY+1, maxObstacleY-1), 0);
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

			if(character1){
				float dist_obs4_1 = Mathf.Abs(obstacle4.transform.position.x - character1.transform.position.x);
				if(dist_obs4_1<1){
					Destroy(character1);
				}
			}

			if(character2){
				float dist_obs4_2 = Mathf.Abs(obstacle4.transform.position.x - character2.transform.position.x);
				if(dist_obs4_2<1){
					Destroy(character2);
				}
			}

			bool character1_flag = false;
			bool character2_flag = false;

			float obj1_x = obstacle1.transform.position.x;
			float obj2_x = obstacle2.transform.position.x;
			float obj3_x = obstacle3.transform.position.x;
			float obj4_x = obstacle4.transform.position.x;

			// Debug.Log(obj1_x + " " + obj2_x + " " + obj3_x + " " + obj4_x);

			if (!character1){
				// Debug.Log("Character 1 not set");
				character1 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);
				character1_flag = true;
			}
			else{
				// Debug.Log("Character 1 present");
			}
			if (!character2){
				// Debug.Log("Character 2 not set");
				character2 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);
				character2_flag = true;
			}
			else{
				// Debug.Log("Character 2 present");
			}
			if (!character1_flag && player.transform.position.x > character1.transform.position.x){
				character1 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);

			}
			if (!character2_flag && player.transform.position.x > character2.transform.position.x){
		    	character2 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);
			}
		}
	}
}
