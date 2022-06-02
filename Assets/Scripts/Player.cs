using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



    public class Player : MonoBehaviour
    {
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private Score scoreScript;
    [SerializeField] private GameObject scoreText;
    private Score score;
    public Rigidbody rb;
    public GameManager gm;
    private bool isOpenMenu = false;
    public GameObject CanvMenu;
    public GameObject Victory;

    public AudioSource audioGameOver, audioJump, audioVictory;//, audioMove;
    public float SpeedY = 0f;
    public float Speed = 0f;


    //*********************************************************************************************
    private Dictionary<Type, PlayerBehavior> behaviorsMap;
        private PlayerBehavior behaviorCurrent;

        private void Start()
        {
            this.InitBehaviors();
            this.SetBehaviorByDefault();
            score = scoreText.GetComponent<Score>();
        }

        private void InitBehaviors()
        {
            this.behaviorsMap = new Dictionary<Type, PlayerBehavior>();

            this.behaviorsMap[typeof(PlayerBehaviorOffRoad)] = new PlayerBehaviorOffRoad();
            this.behaviorsMap[typeof(PlayerBehaviorFly)] = new PlayerBehaviorFly();
            this.behaviorsMap[typeof(PlayerBehaviorRoad)] = new PlayerBehaviorRoad();
        }

        private void SetBehavior(PlayerBehavior newBehavior)
        {
            if (this.behaviorCurrent != null)
                this.behaviorCurrent.Exit();

            this.behaviorCurrent = newBehavior;
            Speed = this.behaviorCurrent.Enter();
        }

        private void SetBehaviorByDefault()
        {
            this.SetBehaviorRoad();
        }

        private PlayerBehavior GetBehavior<T>() where T : PlayerBehavior
        {
            var type = typeof(T);
            return this.behaviorsMap[type];
        }


        public void SetBehaviorRoad()
        {
            var behavior = this.GetBehavior<PlayerBehaviorRoad>();
            this.SetBehavior(behavior);
        }

        public void SetBehaviorOffRoad()
        {
            var behavior = this.GetBehavior<PlayerBehaviorOffRoad>();
            this.SetBehavior(behavior);
        }

        public void SetBehaviorFly()
        {
            var behavior = this.GetBehavior<PlayerBehaviorFly>();
            this.SetBehavior(behavior);
        }
    //*************************************************************************************

        private void GoMenu()
        {
       
            CanvMenu.SetActive(true);
            Time.timeScale = 0f;
        

    }

        private void GoVictory()
        {
            int lastRunScore = int.Parse(scoreScript.scoreText.text.ToString());
            PlayerPrefs.SetInt("lastRunScore", lastRunScore);
            Victory.SetActive(true);
            Time.timeScale = 0f;
        }


        // Update is called once per frame
        void Update()
        {
            CaptureInput();

    }


        private void CaptureInput()
        {

            SpeedY = rb.velocity.y * 1000;

            if (SpeedY < -3500)
            {
                this.SetBehaviorFly();                
            }
            if (this.behaviorCurrent != null)
                this.behaviorCurrent.Update(_movement, rb);


            if (transform.position.y < -5f)
            {
                audioGameOver.Play();
                gm.EndGame();
                GoMenu();
            }

            if (transform.position.z < -80f)
            {
                audioVictory.Play();
                gm.EndGame();
                GoVictory();
            }
            if (Input.GetKey(KeyCode.Escape) && !isOpenMenu)
                {
                    GoMenu();
                }
        }

        void OnCollisionEnter(Collision collision)
        {

            if (collision.collider.tag == "Obstacle")
            {
                gm.EndGame();
                audioGameOver.Play();
                int lastRunScore = int.Parse(scoreScript.scoreText.text.ToString());
                PlayerPrefs.SetInt("lastRunScore", lastRunScore);
                Debug.Log("Зiткнення");
                GoMenu();
            
        }

            if (collision.collider.tag == "Mine")
            {
            //this.SetBehaviorFly();
                score.scoreMultiplier = -10;
                audioJump.Play();
                rb.AddForce(Vector3.up * 30, ForceMode.Impulse);
                 this.SetBehaviorFly();
            }

            if (collision.collider.tag == "Floor")
            {
            score.scoreMultiplier = 3;
            this.SetBehaviorRoad();
            }

            if (collision.collider.tag == "no-road")
            {
            score.scoreMultiplier = 1;
            this.SetBehaviorOffRoad();
        }
        }
    }

