using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player{

	string 	m_name;
	public string Name
	{
		get{return m_name;}
		set{m_name = value;}
	}

	int 	m_level;
	public int Level
	{
		get{return m_level;}
		set{m_level = value;}
	}


	int		m_energy;
	public int Energy
	{
		get{return m_energy;}
		set{m_energy = value;}
	}

	int		m_gold;
	public int Gold
	{
		get{return m_gold;}
		set{m_gold = value;}
	}

	int		m_gems;
	public int Gems
	{
		get{return m_gems;}
		set{m_gems = value;}
	}

	List<BallAsset> m_ballContainer;
	public List<BallAsset> BallList
	{
		get{return m_ballContainer;}
	}

	public Player()
	{
		m_ballContainer = new List<BallAsset>();
	}

	public void AddBall(BallAsset ball)
	{
		if(ball != null)
		{
			m_ballContainer.Add(ball);
		}

	}

	public void RemoveBall(int ball_id)
	{
		foreach(BallAsset ball in m_ballContainer)
		{
			if(ball.ball_id == ball_id)
				m_ballContainer.Remove(ball);
		}
	}
}
