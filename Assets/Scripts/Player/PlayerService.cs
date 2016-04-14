using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerService : CSingleton {

	Player m_player;

	BallList m_balltype;
	void Awake()
	{
		// TODO: Save player state and load player state
		m_player = new Player();
		m_player.Name = "Default";
		m_player.Level = 99;
		m_player.Energy = 3;
		m_player.Gold = 99999;
		m_player.Gems = 99999;

		m_balltype = Resources.Load("Ball/Ball") as BallList;
	}

	public void AddBall(int ball_id)
	{
		m_player.AddBall(m_balltype.GetBallById(ball_id));
	}
	public void RemoveBall(int ball_id)
	{
		m_player.RemoveBall(ball_id);
	}

	public List<BallAsset> GetListOfBalls()
	{
		return m_player.BallList;
	}

}
