using UnityEngine;
using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
    public class NavigationRound : MonoBehaviour
    {
        public bool isEnemy = false;
        public float m_Scale = 1f;
        public Transform[] goals = new Transform[3];
        public Transform[] secondGoals = new Transform[3];
        public float runningSpeed = 14.0f;
        public float walkingSpeed = 5f;
        public GameObject footStepsObject;
        public GameObject cryObject;

    
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
        private GameObject target;
        private AudioSource m_footStepsSource;
        private AudioSource m_crySource;

        private GameObject targetRef;
        private Transform[] currentGoals = new Transform[3];

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            m_fov = GetComponent<FieldOfView>();
            
            m_footStepsSource = footStepsObject.GetComponent<AudioSource>();
            if (cryObject != null)
            {
                m_crySource = cryObject.GetComponent<AudioSource>();
            }
            
            currentGoals = goals;
            m_Agent.speed = walkingSpeed;
        }
    
        void Update()
        {   if (isEnemy)
            {
                if (SceneLoadData.isPlayerInCimetery)
                {
                    currentGoals = goals;
                }
                else
                {
                    currentGoals = secondGoals;
                }
            }

            if (isWaiting)
            {
                if (m_crySource != null)
                {
                    m_crySource.enabled = true;
                }
                m_footStepsSource.enabled = false;
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
                if (m_crySource != null)
                {
                    // m_crySource.enabled = false;
                    m_crySource.enabled = true;
                }
                m_footStepsSource.enabled = true;
                
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
            float distance = Vector3.Distance(m_Agent.transform.position, currentGoals[m_NextGoal].position);

            if (distance < 1f*m_Scale)
            {
                int previousGoal = m_NextGoal;
                do
                {
                    m_NextGoal = Random.Range(0, currentGoals.Length);
                } while (m_NextGoal == previousGoal);
                isWaiting = true;
            }
            m_Agent.destination = currentGoals[m_NextGoal].position;
        }

        public void StartChase(GameObject target)
        {
            targetRef = target;
            m_Agent.speed = runningSpeed;
            isRunning = true;
            waitTime = 0;
            pauseRound = true;
        }
        public void GetThatKid()
        {

            m_Agent.destination = targetRef.transform.position;
            float distance = Vector3.Distance (m_Agent.transform.position, targetRef.transform.position);
            
            if (distance < 1.5f*m_Scale)
            {
                // Destroy(m_fov.playerRef);
                Die die = targetRef.GetComponent<Die>();
                if (die != null)
                {
                    die.die();
                }else 
                {
                    targetRef.transform.parent.GetComponent<Die>().die();
                }	
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