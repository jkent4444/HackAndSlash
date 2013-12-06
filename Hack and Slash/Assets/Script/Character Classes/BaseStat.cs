public class BaseStat{
	private int _baseValue;
	private int _buffValue;
	private int _expToLevel;
	private float _levelModifier;
	
#region Basic setters and getters
	public BaseStat(){
		_baseValue = 0;
		_buffValue = 0;
		_levelModifier = 1.1f;
		_expToLevel = 100;
	}
	public int BaseValue{
		get{return _baseValue;}
		set{ _baseValue = value;}
	}
	public int BuffValue{
		get{return _buffValue;}
		set{ _buffValue = value;}
	}
	public int ExpToLevel{
		get{return _expToLevel;}
		set{ _expToLevel = value;}
	}
	public float LevelModifier{
		get{return _levelModifier;}
		set{ _levelModifier = value;}
	}
#endregion
	
	private int CalculateExpToLevel(){
		return (int)(_expToLevel*_levelModifier);	
	}
	public void LevelUp(){
		_expToLevel = CalculateExpToLevel();
		_baseValue++;
	}
	public int AdjustedBaseValue{
		get{return _baseValue + _buffValue;}
	}
}
