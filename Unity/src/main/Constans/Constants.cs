using UnityEngine;
using System.Collections;

public class Constants 
{
	public static float WAIT_FOR_SECONDS_ASYNC_50MILLI = 0.050f;
	public static float WAIT_FOR_SECONDS_ASYNC_60FPS = 0.01667f;

	public static string RESET_GAME = "T-Rex";

	public static string ANIMATOR_VELOCITY_X = "Vel_X";
	public static string ANIMATOR_IS_GROUND = "IsGround";
	public static string ANIMATOR_IS_BEND = "IsBend";
	public static string ANIMATOR_IS_DIE = "IsDie";

	public static int INDEX_SOUND_PLAYER_JUMP = 0;
	public static int INDEX_SOUND_PLAYER_DIE = 1;

	private static string VIEW = "_View";
	private static string ADAPTER = "Adapter";

	public static string CLASS_TIMER_SCORE = "TimerScore";
	public static string CLASS_PLAYER = "Player";
	public static string CLASS_FOLLOW_PLAYER = "Follow"+CLASS_PLAYER;
	public static string CLASS_GAME_OVER = "GameOver";
	public static string CLASS_FPS = "FPS";
	public static string CLASS_CHECK_CACTUS_IN_CACHE ="checkCactusInCache";

	public static string CLASS_CONSTRUCTOR = "Constructor";

	/*public static string CLASS_PLAYER_ADAPTER = CLASS_PLAYER + ADAPTER;
	public static string CLASS_TIMER_SCORE_ADAPTER = CLASS_TIMER_SCORE + ADAPTER;
	public static string CLASS_GROUND_ADAPTER = CLASS_CONSTRUCTOR + ADAPTER;
	public static string CLASS_FOLLOW_PLAYER_ADAPTER = CLASS_FOLLOW_PLAYER + ADAPTER;
	public static string CLASS_GAME_OVER_ADAPTER = CLASS_GAME_OVER + ADAPTER;
	public static string CLASS_FPS_ADAPTER = CLASS_FPS + ADAPTER;*/

	public static string CLASS_ACTIVATOR_VIEW = "Activator" + VIEW;
	public static string CLASS_FPS_VIEW = CLASS_FPS+VIEW;
	public static string CLASS_TIMER_SCORE_VIEW = CLASS_TIMER_SCORE+VIEW;
	public static string CLASS_GAME_OVER_VIEW = CLASS_GAME_OVER+VIEW;
	public static string CLASS_MAIN_CAMERA_VIEW = "MainCamera"+VIEW;
	public static string CLASS_FOLLOW_PLAYER_VIEW = CLASS_FOLLOW_PLAYER+VIEW;
	public static string CLASS_BIRD_VIEW = "Bird" + VIEW;
	public static string CLASS_PLAYER_VIEW  = CLASS_PLAYER+VIEW;
	public static string CLASS_DESTRUCTOR_VIEW  = "Destructor"+VIEW;
	public static string CLASS_GROUND_CONSTRUCTOR_VIEW = "GroundGenerator"+VIEW;
	public static string CLASS_CLOUD_VIEW = "Cloud"+VIEW;

	public static string EXTENSION_SWITCH_CONSTRUCTOR_CACTUS = "extensionCactus";

	public static string CLASS_CACTUS_GENERATOR_EASY_VIEW =  "CactusGeneratorEasy"+VIEW;
	public static string CLASS_CACTUS_GENERATOR_MEDIUM_VIEW =  "CactusGeneratorMedium"+VIEW;
	public static string CLASS_CACTUS_GENERATOR_HARD_VIEW =  "CactusGeneratorHard"+VIEW;
	public static string CLASS_CLOUD_GENERATOR_VIEW ="CloudGenerator"+VIEW;
	public static string CLASS_BIRD_GENERATOR_VIEW ="BirdGenerator"+VIEW;

	public static string TAG_CACTUS_GENERATOR_EASY =  "Easy";
	public static string TAG_CACTUS_GENERATOR_MEDIUM =  "Medium";
	public static string TAG_CACTUS_GENERATOR_HARD =  "Hard";
	public static string TAG_GROUND_GENERATOR = "GeneradorSuelo";
	public static string TAG_BIRD = "BirdGenerator";

	public static string CLASS_INIT_CHECK_TOUCH = "InitCheckTouch";
	public static string CLASS_SYSTEM ="System";
	public static string CLASS_APP = "App";

	public static string FACTORY_METHOD = "Create";

	public const string CONTEXT_GET_OBSOLETE = "'IController Get(string key)' is deprecated.\nPlease use 'T Get<T> (string key) where T : IController' instead.";
}

