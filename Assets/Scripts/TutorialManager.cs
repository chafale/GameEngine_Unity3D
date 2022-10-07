using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using gs = goldScript;


public class TutorialManager : MonoBehaviour
{
    public GameObject character;
    public GameObject[] popUps;
    public GameObject obstacle1;
    public GameObject character1;
    public GameObject character2;
    public GameObject character3, temp_chr;
    public GameObject prevCeiling;
	public GameObject prevFloor;
	public GameObject ceiling;
	public GameObject floor;
	public BoxCollider2D prevBackground;
	public BoxCollider2D currBackground;
    public GameObject player;
    public GameObject obstaclePrefab;
    public GameObject A, D, E, G, O;
    public  GameObject letterPrefab;
    public GameObject hintObj;
    public GameObject hintData;
    public GameObject speedUp;
    public GameObject speedUpData;
    public GameObject autofill;
    public GameObject autofillData;
    public GameObject PopUp05;

    public static List<GameObject> chars = new List<GameObject>();

    public  TMP_Text hint;
    public  Transform letterHolder;


    public  static List<TMP_Text> letterHolderList = new List<TMP_Text>();

    public  static string[] wordList = {"DOG"};
    public  static string[] hintList = {"Most Adopted Pet"};
    public static List<char> solvedList = new List<char>();


    private int popUpIndex = 0;
    private int flag = 0;
    public static int hints;
    public static int index;

	public float minObstacleY;
	public float maxObstacleY;

    public float minObstacleSpacing;
	public float maxObstacleSpacing;

	public float minObstacleScaleY;
	public float maxObstacleScaleY;

    public static List<GameObject> displayCharacter = new List<GameObject>();
	public static List<GameObject> correctCharacters = new List<GameObject>();


    void Start(){
        correctCharacters.Clear();
        chars.Clear();
        hints = 2;
        chars.AddRange(new List<GameObject> {A, D, E, G, O});
        index = 0;
        hint.text = "Hint: " + hintList[index].ToString();
        string tempWord = wordList[index];
        Debug.Log("Tutorial"+tempWord);
        string[] splittedWord = tempWord.Split(' ', tempWord.Length);
        char[] splitWord = tempWord.ToCharArray();
        Debug.Log(tempWord);
        foreach (char letter in splitWord){
            solvedList.Add(letter);
            foreach(GameObject letter_prefab in chars){
              char inputLetter = char.Parse(letter_prefab.tag);
              if(inputLetter == letter){
                correctCharacters.Add(letter_prefab);
              }
            }
        }
        Debug.Log("Length of correct characters are"+correctCharacters.Count);
        for (int i = 0; i < tempWord.Length; i++)
        {
            GameObject temp = Instantiate(letterPrefab, letterHolder, false);
            letterHolderList.Add(temp.GetComponent<TMP_Text>());
        }
       // hintObj=GameObject.FindWithTag("HintObj");
        hintObj.SetActive(false);
        hintData.SetActive(false);
        speedUp.SetActive(false);
        speedUpData.SetActive(false);
        autofill.SetActive(false);
        autofillData.SetActive(false);
        PopUp05.SetActive(false);
    }


    public void updateGameHint()
    {
        hint.text = "Hint: " + gs.goldList[gs.goldIndex].ToString();
    }


    GameObject GenerateObstacle(float referenceX) {
		GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
		SetTransform(obstacle,referenceX);
		return obstacle;
	}

      GameObject GenerateCharacter(float referenceX,int i) {
        float y;
        if (i == 1){
            character = GameObject.Instantiate(correctCharacters[0]);
            y = 1.5f;
        }
        else if (i ==2){
            character = GameObject.Instantiate(correctCharacters[1]);
            y = -1.5f;
        }
        else{
            character = GameObject.Instantiate(correctCharacters[2]);
            y = 1.5f;
        }
		SetTransformCharacter(character,referenceX,y);
        Debug.Log(i + " " + character.transform.position.x + " " + character.transform.position.y);
		return character;
	}

    void SetTransform(GameObject obstacle, float referenceX) {
		obstacle.transform.position = new Vector3(referenceX, Random.Range(minObstacleY, maxObstacleY), 0);
		obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, Random.Range(minObstacleScaleY, maxObstacleY), obstacle.transform.localScale.z);
	}

    void SetTransformCharacter(GameObject obstacle, float referenceX, float y) {
		obstacle.transform.position = new Vector3(referenceX, y, 0);
	}

    IEnumerator SetCountText()
    {
        Debug.Log("hi inside SetCountText");
        yield return new WaitForSeconds(5);
    }
    void Update(){
        if (player.transform.position.x > floor.transform.position.x-5) {
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
        
        for(int i = 0;i<popUps.Length; i++){
            //Debug.Log("PopUpIndex"+popUpIndex);
            //Debug.Log("value of i"+i);
            if(i == popUpIndex){
                popUps[i].transform.position = new Vector3(player.transform.position.x+10, 0, 0);
                popUps[i].SetActive(true);
            } else {
                popUps[i].SetActive(false);
            }
        }
        if(popUpIndex == 0){
            Time.timeScale = 0;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Sapce Bar was pressed");
                GameObject arrow1=GameObject.FindWithTag("ArrowKey1");
                GameObject arrow2=GameObject.FindWithTag("ArrowKey2");
                if (arrow1 != null){
                    Debug.Log("Arrow 1 is not null");
                    arrow1.SetActive(false);
                }
                if (arrow2 != null){
                     arrow2.SetActive(false);
                }
                Time.timeScale = 1;
                popUpIndex++;
            }
        } else if (popUpIndex == 1) {
             if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                popUpIndex++;
                flag = 1;
            }

        } else if (popUpIndex == 2 ){
                if (flag == 1){
                obstacle1 = GenerateObstacle(player.transform.position.x + 25);
                }
                Time.timeScale = 1;
                if (player.transform.position.x > obstacle1.transform.position.x)
                {
                    popUpIndex++;
                    
                }
                flag = 0;
        } else if (popUpIndex == 3 ){
                Debug.Log("Waiting");
                popUps[3].SetActive(true);
                StartCoroutine(SetCountText());
                popUpIndex++;
        } else if (popUpIndex == 4 )
            {
                if (flag == 0)
                    {
                    Debug.Log("Move to Character Generation");
                    popUps[4].SetActive(true);
                    character1 = GenerateCharacter(player.transform.position.x + 20,1);
                    character2 = GenerateCharacter(player.transform.position.x + 30,2);
                    character3 = GenerateCharacter(player.transform.position.x + 40,3);
                    temp_chr = GenerateCharacter(player.transform.position.x + 45,3);
                    temp_chr.SetActive(false);
                    flag = 1;
                    }
                if(temp_chr && player.transform.position.x > temp_chr.transform.position.x){
                    player.SetActive(false);
                    popUps[4].SetActive(false);
                    popUpIndex++;
                    hintObj.SetActive(true);
                    hintData.SetActive(true);
                    speedUp.SetActive(true);
                    speedUpData.SetActive(true);
                    autofill.SetActive(true);
                    autofillData.SetActive(true);
                    PopUp05.SetActive(true);
                    Time.timeScale = 0;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log("Check if the Space bar was pressed ");
                        Time.timeScale = 1;
                        Camera.GameEnd();
                        Player.body.isKinematic = true;
                    }
                    else{
                        popUpIndex--;
                    }
                    
                }
            }
    }
}
