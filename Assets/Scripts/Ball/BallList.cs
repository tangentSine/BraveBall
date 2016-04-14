using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallList : ScriptableObject {

	public List<BallAsset> ballList;

	public BallAsset GetBallById(int id)
	{
		foreach(BallAsset ball in ballList)
		{
			if(ball.ball_id == id)
			{
				return ball;
			}
		}
		return null;
	}
}
