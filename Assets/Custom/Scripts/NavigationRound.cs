using UnityEngine;
using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
    public class NavigationRound : MonoBehaviour
    {
        public bool isEnemy = false;
        public float m_Scale = 1f;
        public Transform[] goals = new Transform[3];
    
        NavMeshAgent m_Agent;

        private bool isWaiting = false;
        private bool isRunning = false;
        private bool isLooking = false;
        private int randomIdle = 0;
        private bool pauseRound = false;    
        private int m_NextGoal = 0;
        FieldOfView m_fov;
        private float waitTime = 10.0f;
        private float timeCounter = 0.0f;
        private float runTimer = 5.0f;
        private float idleTimer = 3.0f;
        private float runningSpeed = 14.0f;
        private float walkingSpeed = 5f;
        private GameObject target;

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            m_fov = GetComponent<FieldOfView>();
        }
    
        void Update()
        {   
            if (isWaiting)
            {
                timeCounter += Time.deltaTime;
                idleTimer -= Time.deltaTime;
                m_Agent.isStopped = true;
                if (timeCounter >= waitTime)
                {
                    ResetWaitTimer();
                }
                
                if (idleTimer <= 0)
                {
                    randomIdle = Random.Range(0, 7);
                    idleTimer = 3.0f;
                }

                if (5.0f < timeCounter && timeCounter < 8.0f)
                {
                    isLooking = true;
                } else
                {
                    isLooking = false;
                }
            }
            else
            {
                if (pauseRound)
                {
                    GetThatKid();
                }
                else
                {
                    MoveRound();
                }
            }

        }

        void MoveRound()
        {   
            float distance = Vector3.Distance(m_Agent.transform.position, goals[m_NextGoal].position);

            if (distance < 1f*m_Scale)
            {
                m_NextGoal = (m_NextGoal + 1) % goals.Length;
                isWaiting = true;
            }
            m_Agent.destination = goals[m_NextGoal].position;
        }

        public void GetThatKid()
        {
            print(m_fov.playerRef);
            m_Agent.speed = runningSpeed;
            isRunning = true;
            waitTime = 0;
            m_Agent.destination = m_fov.playerRef.transform.position;
            pauseRound = true;
            float distance = Vector3.Distance (m_Agent.transform.position, m_fov.playerRef.transform.position);
            
            if (distance < 1.5f*m_Scale)
            {
                Destroy(m_fov.playerRef);
                Debug.Log("You have been caught!");
                pauseRound = false;
                isRunning = false;
                m_Agent.speed = walkingSpeed;
                ResetWaitTimer();
            }
            
            runTimer -= Time.deltaTime;
            if (runTimer <= 0)
            {
                pauseRound = false;
                isRunning = false;
                runTimer = 5.0f;
                m_Agent.speed = walkingSpeed;
                ResetWaitTimer();
            }
        }

        private void ResetWaitTimer(){
            isWaiting = false;
            // waitTime = Random.Range(7, 20);
            waitTime = Random.Range(2, 8);
            m_Agent.isStopped = false;
            timeCounter = 0;
        }
        
        public bool IsWaiting
        {
            get => isWaiting;
            set => isWaiting = value;
        }

        public bool IsRunning
        {
            get => isRunning;
            set => isRunning = value;
        }

        public bool IsLooking
        {
            get => isLooking;
            set => isLooking = value;
        }

        public int RandomIdle
        {
            get => randomIdle;
            set => randomIdle = value;
        }

        public bool PauseRound
        {
            get => pauseRound;
            set => pauseRound = value;
        }
    }