using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator_sh : MonoBehaviour {

	public GameObject prevCeiling;
	public GameObject prevFloor;
	public GameObject ceiling;
	public GameObject floor;
	public BoxCollider2D prevBackground;
	public BoxCollider2D currBackground;

	public GameObject player;

	public int frame;
	public int startFrame;
	public bool flag;

	public GameObject obstacle1;
	public GameObject obstacle2;
	public GameObject obstacle3;
	public GameObject obstacle4;
	public GameObject bladePrefab;
	public GameObject mace;
	public GameObject firePrefab;

	public GameObject character1, character2, character3;

	public GameObject hintObject, speedObject, autofillObject, healthUpObject, splitObject;
	public GameObject invisibleObject;

	public GameObject obstaclePrefab;
	public GameObject A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z;

  	public int count;
	public static int activateColorChange = 0;

	public static List<GameObject> displayCharacter = new List<GameObject>();
	public static List<GameObject> correctCharacters = new List<GameObject>();
	public static List<GameObject> healCharacters = new List<GameObject>();
	public static List<GameObject> goCharacters = new List<GameObject>();
	public static List<GameObject> obstaclesSpawn = new List<GameObject>();

	public float minObstacleY;
	public float maxObstacleY;

	public float minObstacleSpacing;
	public float maxObstacleSpacing;

	public float minObstacleScaleY;
	public float maxObstacleScaleY;


	// Use this for initialization
	void Start () {
		flag = true;
		displayCharacter.Clear();
		obstaclesSpawn.Clear();
		obstaclesSpawn.AddRange(new List<GameObject> {obstaclePrefab,obstaclePrefab,bladePrefab,firePrefab,mace});
		displayCharacter.AddRange(new List<GameObject> {A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z });
		obstacle1 = GenerateObstacle(player.transform.position.x + 10);
		obstacle2 = GenerateObstacle(obstacle1.transform.position.x);
		obstacle3 = GenerateObstacle(obstacle2.transform.position.x);
		obstacle4 = GenerateObstacle(obstacle3.transform.position.x);
		character1 = GenerateCharacter(obstacle1.transform.position.x, obstacle2.transform.position.x, obstacle1.transform.position.x, obstacle2.transform.position.x, obstacle3.transform.position.x, obstacle4.transform.position.x);
		character2 = GenerateCharacter(obstacle2.transform.position.x, obstacle3.transform.position.x, obstacle1.transform.position.x, obstacle2.transform.position.x, obstacle3.transform.position.x, obstacle4.transform.position.x);
		character3 = GenerateCharacter(obstacle3.transform.position.x, obstacle4.transform.position.x, obstacle1.transform.position.x, obstacle2.transform.position.x, obstacle3.transform.position.x, obstacle4.transform.position.x);	}

	GameObject GenerateObstacle(float referenceX) {
		GameObject obstacle = GameObject.Instantiate(obstaclesSpawn[Random.Range(0,obstaclesSpawn.Count)]);
		SetTransform(obstacle,referenceX);
		return obstacle;
	}

	GameObject GenerateCharacter(float start, float end, float obj1, float obj2, float obj3, float obj4) {
		
		count += 1;
		int num;
		GameObject obstacle;
		float start_obs = Random.Range(start, end);
		float end_obs = Random.Range(minObstacleY+1, maxObstacleY-1);

		float dist1 = Mathf.Abs(start_obs - obj1);
		float dist2 = Mathf.Abs(start_obs - obj2);
		float dist3 = Mathf.Abs(start_obs - obj3);
		float dist4 = Mathf.Abs(start_obs - obj4);

		if(dist1<1.25){
			// Debug.Log("1");
			return null;
		}
		else if(dist2<1.25){
			// Debug.Log("2");
			return null;
		}
		else if(dist3<1.25){
			// Debug.Log("3");
			return null;
		}
		else if(dist4<1.25){
			// Debug.Log("4");
			return null;
		}

		if(count%17==0){
			// Debug.Log("In split object generation");
			obstacle = GameObject.Instantiate(splitObject);
		}
		else if(count%14==0){
			// Debug.Log("In autofill object generation");
			obstacle = GameObject.Instantiate(autofillObject);
		}
		else if(count%13 == 0 && HealthBar.healthObj.slider.value<=75)
		{
			// Debug.Log("In Healthup object generation");
			obstacle = GameObject.Instantiate(healthUpObject);
		}
		else if(count%11==0){
			// Debug.Log("In speed object generation");
			obstacle = GameObject.Instantiate(speedObject);
		}
		else if(count%5==0 && goCharacters.Count>0){
			num = Random.Range(0,goCharacters.Count);
			obstacle = GameObject.Instantiate(goCharacters[num]);
		}
		else if(count%4==0 && healCharacters.Count>0){
			num = Random.Range(0,healCharacters.Count);
			obstacle = GameObject.Instantiate(healCharacters[num]);
		}
		else if (count%3==0 && correctCharacters.Count>0){
			num = Random.Range(0,correctCharacters.Count);
			obstacle = GameObject.Instantiate(correctCharacters[num]);
			// Change Color to Green
			if(activateColorChange > 0)
			{
				obstacle.GetComponent<Renderer>().material.color = new Color(0,255,0);
				Invoke(nameof(ResetEffect),10);
			}
		}
		else if((count==2 || count%5==0) && GameManager_sh.hints>0 && GameManager_sh.hints<=3){
			Debug.Log("In Hint object generation");
			obstacle = GameObject.Instantiate(hintObject);
		}
		else{
			num = Random.Range(0,displayCharacter.Count);
			obstacle = GameObject.Instantiate(displayCharacter[num]);
			// Change color to red
			if(activateColorChange > 0)
			{
				obstacle.GetComponent<Renderer>().material.color = new Color(255,0,0);
				Invoke(nameof(ResetEffect),10);
			}
		}

		SetTransformCharacter(obstacle,start_obs,end_obs);
		GameManager_sh gameMananger = GameObject.Find("GameManager").GetComponent<GameManager_sh>();
		gameMananger.HealPopup.SetActive(false);
		gameMananger.GoPopup.SetActive(false);
		return obstacle;
	}

	private void ResetEffect(){
        activateColorChange -= 1;
        // Debug.Log("Inside split timer  "+ activateColorChange);
    }

	void SetTransform(GameObject obstacle, float referenceX) {
		if(obstacle.tag == "blade"){
			obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObstacleY), 0);
			float scale_blade1 = Random.Range(1, 10);
			float scale_blade2 = Random.Range(scale_blade1+1, 3*scale_blade1);
			obstacle.transform.localScale = new Vector3(scale_blade1/scale_blade2, scale_blade1/scale_blade2, scale_blade1/scale_blade2);
		}
		else if(obstacle.tag == "rod"){
			obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObstacleY), 0);
			float random_size = Random.Range(1, 10);
			if(random_size==5 || random_size==6){
				obstacle.transform.localScale = new Vector3(1,2, 0);
			}
		}
		else if(obstacle.tag == "mace"){
			obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(-2, 2), 0);

		}
		else if(obstacle.tag == "fire"){
			obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(-2, 2), 0);
		}
	}

	void VanishObstacle(GameObject obstacle, float referenceX) {
		if(obstacle.tag == "blade"){
			obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), 40, 0);
			float scale_blade1 = Random.Range(1, 10);
			float scale_blade2 = Random.Range(scale_blade1+1, 3*scale_blade1);
			obstacle.transform.localScale = new Vector3(scale_blade1/scale_blade2, scale_blade1/scale_blade2, scale_blade1/scale_blade2);
		}
		else if(obstacle.tag == "rod"){
			obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), 40, 0);
			float random_size = Random.Range(1, 10);
			if(random_size==5 || random_size==6){
				obstacle.transform.localScale = new Vector3(1,2, 0);
			}
		}
		else if(obstacle.tag == "mace"){
			obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), 40, 0);

		}
		else if(obstacle.tag == "fire"){
			obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), 40, 0);
		}
	}

	void SetTransformCharacter(GameObject obstacle, float start, float end) {
		obstacle.transform.position = new Vector3(start, end, 0);
	}

	public void ResetGoCollected() {
		Debug.Log("gameMananger Inside reset");
		GameManager_sh gameMananger = GameObject.Find("GameManager").GetComponent<GameManager_sh>();
		gameMananger.goCollected = false;
	}

	// Update is called once per frame
	void Update () {
		GameManager_sh gameMananger = GameObject.Find("GameManager").GetComponent<GameManager_sh>();
		if (player.transform.position.x > floor.transform.position.x - 6) {
			var tempCeiling = prevCeiling;
			var tempFloor = prevFloor;
			var tempBackground = prevBackground;
			prevCeiling = ceiling;
			prevFloor = floor;
			prevBackground = currBackground;
			tempCeiling.transform.position += new Vector3(79.85f, 0, 0);
			tempFloor.transform.position += new Vector3(79.85f, 0, 0);
			tempBackground.transform.position += new Vector3(79.85f, 0, 0);
			ceiling = tempCeiling;
			floor = tempFloor;
			currBackground = tempBackground;
		}

		if (player.transform.position.x > obstacle2.transform.position.x) {
			var tempObstacle = obstacle1;
			obstacle1 = obstacle2;
			obstacle2 = obstacle3;
			obstacle3 = obstacle4;
			tempObstacle = GameObject.Instantiate(obstaclesSpawn[Random.Range(0,obstaclesSpawn.Count)]);
			// SetTransform(tempObstacle, obstacle3.transform.position.x);
			Debug.Log("gameMananger.goCollected: " + gameMananger.goCollected);
			if (gameMananger.goCollected == false) {
				SetTransform(tempObstacle, obstacle3.transform.position.x);
			} else {
				VanishObstacle(tempObstacle, obstacle3.transform.position.x);
				Invoke(nameof(ResetGoCollected), 5);
			}
			obstacle4 = tempObstacle;

			if(character1){
				float dist_obs4_1 = Mathf.Abs(obstacle4.transform.position.x - character1.transform.position.x);
				if(dist_obs4_1<1.25){
					Destroy(character1);
				}
			}

			if(character2){
				float dist_obs4_2 = Mathf.Abs(obstacle4.transform.position.x - character2.transform.position.x);
				if(dist_obs4_2<1.25){
					Destroy(character2);
				}
			}

			if(character3){
				float dist_obs4_3 = Mathf.Abs(obstacle4.transform.position.x - character3.transform.position.x);
				if(dist_obs4_3<1.25){
					Destroy(character3);
				}
			}

			bool character1_flag = false;
			bool character2_flag = false;
			bool character3_flag = false;

			float obj1_x = obstacle1.transform.position.x;
			float obj2_x = obstacle2.transform.position.x;
			float obj3_x = obstacle3.transform.position.x;
			float obj4_x = obstacle4.transform.position.x;

			// Debug.Log(obj1_x + " " + obj2_x + " " + obj3_x + " " + obj4_x);

			if (!character1){
				character1 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);
				character1_flag = true;
			}
			if (!character2){
				character2 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);
				character2_flag = true;
			}
			if (!character3){
				character3 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);
				character3_flag = true;
			}
			if (!character1_flag && player.transform.position.x > character1.transform.position.x){
				character1 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);

			}
			if (!character2_flag && player.transform.position.x > character2.transform.position.x){
		    	character2 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);
			}
			if (!character3_flag && player.transform.position.x > character3.transform.position.x){
		    	character3 = GenerateCharacter(obstacle3.transform.position.x+10, obstacle4.transform.position.x+10, obj1_x, obj2_x, obj3_x, obj4_x);
			}
		}
	}
}
