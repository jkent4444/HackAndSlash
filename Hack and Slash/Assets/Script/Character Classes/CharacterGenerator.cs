using UnityEngine;
using System.Collections;
using System;					//used for the Enum class

public class CharacterGenerator : MonoBehaviour {
	private PlayerCharacter _toon;
	private const int STARTING_POINTS =  350;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
	private const int STARTING_VALUE = 50;
	private int pointsLeft;
	
	private const int OFFSET =	5;
	private const int LINE_HEIGHT = 20;
	
	private const int STAT_LABEL_WIDTH = 	100;
	private const int BASEVALUE_LABEL_WIDTH = 	30;
	
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;
	
	private const int STAT_STARTING_POS = 40;

	public GUIStyle myStyle;
	
	public GameObject playerPrefab;
	// Use this for initialization
	void Start () {
		GameObject pc = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		pc.name = "pc";
		
//		_toon = new PlayerCharacter();
//		_toon.Awake();
		
		_toon  = pc.GetComponent<PlayerCharacter>();
		
		pointsLeft = STARTING_POINTS;
		for(int cnt=0; cnt< Enum.GetValues(typeof(AttributeName)).Length; cnt++){
			_toon.GetPrimaryAttribute(cnt).BaseValue = STARTING_VALUE;
			pointsLeft -= (STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE);
			
		}
		_toon.StatUpdate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		DisplayName();
		DisplayPointsLeft();
		DisplayAttributes();
		DisplayVitals();
		DisplaySkills();
		
		DisplayCreateButton();
	}
	
	private void DisplayName(){
		GUI.Label(new Rect(10,10,50,25), "Name:");
		_toon.Name = GUI.TextField(new Rect(65,10,100,25),_toon.Name);	
	}
	private void DisplayAttributes(){
		for(int cnt=0; cnt< Enum.GetValues(typeof(AttributeName)).Length; cnt++){
			GUI.Label (new Rect(OFFSET,STAT_STARTING_POS + (cnt*LINE_HEIGHT),STAT_LABEL_WIDTH,LINE_HEIGHT),((AttributeName)cnt).ToString(), myStyle);
			GUI.Label (new Rect(STAT_LABEL_WIDTH + OFFSET,STAT_STARTING_POS + (cnt*LINE_HEIGHT),BASEVALUE_LABEL_WIDTH,LINE_HEIGHT), _toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString());
			if(GUI.Button(new Rect(OFFSET+STAT_LABEL_WIDTH+BASEVALUE_LABEL_WIDTH,STAT_STARTING_POS + (cnt*BUTTON_HEIGHT),BUTTON_WIDTH,BUTTON_HEIGHT),"-")){
				if(_toon.GetPrimaryAttribute(cnt).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE){	
					_toon.GetPrimaryAttribute(cnt).BaseValue--;
					pointsLeft++;
					_toon.StatUpdate();
				}
			}
			if(GUI.Button(new Rect(OFFSET+STAT_LABEL_WIDTH+BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH,STAT_STARTING_POS + (cnt*BUTTON_HEIGHT),BUTTON_WIDTH,BUTTON_HEIGHT),"+")){
				if(pointsLeft > 0){	
					_toon.GetPrimaryAttribute(cnt).BaseValue++;
					pointsLeft--;
					_toon.StatUpdate();
				}
			}
		}
	}
	private void DisplayVitals(){
		for(int cnt=0; cnt< Enum.GetValues(typeof(VitalName)).Length; cnt++){
			GUI.Label (new Rect(OFFSET,STAT_STARTING_POS + ((cnt+7)*LINE_HEIGHT),STAT_LABEL_WIDTH,LINE_HEIGHT),((VitalName)cnt).ToString());
			GUI.Label (new Rect(OFFSET + STAT_LABEL_WIDTH,STAT_STARTING_POS + ((cnt+7)*LINE_HEIGHT),BASEVALUE_LABEL_WIDTH,LINE_HEIGHT), _toon.GetVital(cnt).AdjustedBaseValue.ToString());
		}
	}
	private void DisplaySkills(){
		for(int cnt=0; cnt< Enum.GetValues(typeof(SkillName)).Length; cnt++){
			GUI.Label (new Rect((OFFSET*3)+STAT_LABEL_WIDTH+BASEVALUE_LABEL_WIDTH+ BUTTON_WIDTH*2,STAT_STARTING_POS + (cnt*LINE_HEIGHT),STAT_LABEL_WIDTH,LINE_HEIGHT),((SkillName)cnt).ToString());
			GUI.Label (new Rect((OFFSET*3)+(STAT_LABEL_WIDTH*2)+BASEVALUE_LABEL_WIDTH+BUTTON_WIDTH*2,STAT_STARTING_POS + (cnt*LINE_HEIGHT),BASEVALUE_LABEL_WIDTH,LINE_HEIGHT), _toon.GetSkill(cnt).AdjustedBaseValue.ToString());
		}
	}
	private void DisplayPointsLeft(){
		GUI.Label(new Rect(250,10,100,LINE_HEIGHT), "Points Left: " + pointsLeft.ToString());	
	}
	private void DisplayCreateButton() {
		if(GUI.Button(new Rect(Screen.width/2 - 50,STAT_STARTING_POS + (10*LINE_HEIGHT),STAT_LABEL_WIDTH,LINE_HEIGHT),"Create")){
			GameObject gs = GameObject.Find("__GameSettings");
			GameSettings gsScript = gs.GetComponent<GameSettings>();
			gsScript.SaveCharacterData();
			Application.LoadLevel("Targetting Example");
		}	
	}
}
