using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour {
	public GameObject health;
	public int _str;
	public int _dex;
	public int _hp;
	public int _ende;
	public int _movement;
	public int _healthR;
	public int _alignment;
	// Use this for initialization
	
	void Start () {
		Basestat();
		
	}
	public int strenght{
		get{return _str;}
		set{_str = value;}
	}
	public int dexterity{
		get{return _dex;}
		set{_dex = value;}
	}
	public int endurance{
		get{return _ende;}
		set{_ende = value;}
	}
	public int hitpoints{
		get{return _hp;}
		set{_hp= value;}
	}
	public int movement{
		get{return _movement;}
		set{_movement = value;}
	}
	public int healthRegen{
		get{return _healthR;}
		set{_healthR = value;}
	}
	public int alignment{
		get{return _alignment;}
		set{_alignment = value;}
	}
	private void Basestat(){
		this.strenght = 5;
		this.dexterity = 5;
		this.endurance = 5;
		this.hitpoints = 100;
		this.movement= 5;
		this.healthRegen = 5;
		this.alignment = 1;
	}

}
