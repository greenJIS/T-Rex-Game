using UnityEngine;
using System.Collections;


public class IsColliderEnemies : MonoBehaviour {

	private bool _lock;

	void OnCollisionEnter2D(Collision2D other){
		if (_lock)
			return;

		_lock = true;

		var App =  GameObject.Find (Constants.CLASS_APP);
		var main = App.GetComponent<Main> ();
		var context = main.context; 

		this.Player (context,other);
		this.IsBird ();
		this.OnTiggers (context);
	}

	private void Player(IContext context,Collision2D other){
		var player = other.gameObject;

		var animator = player.GetComponent<Animator> ();
		animator.SetBool(Constants.ANIMATOR_IS_DIE, true);

		var playerController = (IPlayerController)context.Get (typeof(PlayerAdapter).Name);
		var grouned = GameObject.FindGameObjectsWithTag (Constants.TAG_GROUND_GENERATOR);
		playerController.LastCollision (this.gameObject);

	}

	private void IsBird(){
		if (this.tag == Constants.TAG_BIRD) {
			var pajaro = this.GetComponent<Animator> ();
			pajaro.Stop();
		}
	}

	private void OnTiggers(IContext context){
		this.Stop (context);
		this.GameOverControllerShow (context);
		this.SystemActiveTouch ();
		this.StopVelocityBird<BirdAdapter> (context);
		this.PlayerSoundDie (context);
		this.GeneratorResetCactus (context);
	}

	private void GeneratorResetCactus (IContext context)
	{
		var generators = context.GetExtension<SwitchConstructorCactusExtension> (Constants.EXTENSION_SWITCH_CONSTRUCTOR_CACTUS);
		generators.Reset ();
	}

	private void PlayerSoundDie (IContext context)
	{
		var player = context.Get (typeof(PlayerAdapter).Name);
		var playerAdapter = (IPlayerAdapter)player.adapter;
		playerAdapter.PlaySound (Constants.INDEX_SOUND_PLAYER_DIE);
	}

	private void SystemActiveTouch ()
	{
		var systemClass = GameObject.Find (Constants.CLASS_SYSTEM);
		var initCheckTouch = (IInitCheckTouch)systemClass.GetComponent<InitCheckTouch> ();
		initCheckTouch.isActive = true;
	}

	private void GameOverControllerShow (IContext context)
	{
		var gameOverController = (IGameOverController)context.Get (typeof(GameOverAdapter).Name);
		gameOverController.Visible ();
	}

	private void Stop (IContext context)
	{
		var timerScoreController = (ITimerScoreController)context.Get (typeof(TimerScoreAdapter).Name);
		timerScoreController.Stop ();
	}

	private void StopVelocityBird<T>(IContext context) where T : BirdAdapter{
		var listObjects = GameObject.FindObjectsOfType<T> ();
		foreach (var element in listObjects) {
			var name = element.gameObject.name;
			var birdModule = (IBirdController)context.Get(name);
			birdModule.isStop();
		}
	}

}
