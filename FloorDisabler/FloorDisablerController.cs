using IPA.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using BS_Utils.Utilities;
using System.Configuration;
using FloorDisabler.Settings;

namespace FloorDisabler
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class FloorDisablerController : MonoBehaviour
    {
        public static FloorDisablerController Instance { get; private set; }

        // These methods are automatically called by Unity, you should remove any you aren't using.
        #region Monobehaviour Messages
        /// <summary>
        /// Only ever called once, mainly used to initialize variables.
        /// </summary>
        private void Awake()
        {
            // For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
            //   and destroy any that are created while one already exists.
            if (Instance != null)
            {
                Plugin.Log?.Warn($"Instance of {GetType().Name} already exists, destroying.");
                GameObject.DestroyImmediate(this);
                return;
            }
            GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
            Instance = this;
            Plugin.Log?.Debug($"{name}: Awake()");
        }
        /// <summary>
        /// Only ever called once on the first frame the script is Enabled. Start is called after any other script's Awake() and before Update().
        /// </summary>
        /// 
        public GameObject obj;
        private void Start()
        {

            BSEvents.gameSceneLoaded += BSEvents_gameSceneLoaded;
        }

        public static GameObject defaultEnvObj;

        private static void BSEvents_gameSceneLoaded()
        {
            Plugin.Log.Info("test BSEvent gamescene loaded");
            if (!Settings.Configuration.Instance.Enabled) return;

            var scenes = SceneManager.GetAllScenes();
            var defaultEnvObj = scenes[2].GetRootGameObjects()[0];

            Plugin.Log.Info(defaultEnvObj.name);
            foreach (Transform i in defaultEnvObj.transform)
            {
                Plugin.Log.Info(i.name);

                //Player Place
                if (i.name.IndexOf("PlayersPlace") != -1 || i.name.IndexOf("Floor") != -1 || i.name.IndexOf("TopLightMesh") != -1)
                {
                    if (Settings.Configuration.Instance.PlayersPlace) i.gameObject.SetActive(false);
                    else i.gameObject.SetActive(true);
                }
                //Laser
                if (i.name.IndexOf("Laser") != -1 || i.name.IndexOf("Pillar") !=-1)
                {
                    if (Settings.Configuration.Instance.Laser) i.gameObject.SetActive(false);
                    else i.gameObject.SetActive(true);
                }
                //Ring
                if (i.name.IndexOf("Ring") != -1) 
                {
                    if (Settings.Configuration.Instance.Ring) i.gameObject.SetActive(false);
                    else i.gameObject.SetActive(true);
                }
                //Spectrograms
                if (i.name.IndexOf("Spectrograms") != -1)
                {
                    if (Settings.Configuration.Instance.Spectrograms) i.gameObject.SetActive(false);
                    else i.gameObject.SetActive(true);
                }

            }

        }


        string GetFullPath(Transform transform)
        {
            string path = transform.name;
            Transform parent = transform.parent;
            while (parent != null)
            {
                path = $"{parent.name}/{path}";
                parent = parent.parent;
            }
            return path;
        }
        /// <summary>
        /// Called every frame if the script is enabled.
        /// </summary>
        private void Update()
        {

        }

        /// <summary>
        /// Called every frame after every other enabled script's Update().
        /// </summary>
        private void LateUpdate()
        {

        }

        /// <summary>
        /// Called when the script becomes enabled and active
        /// </summary>
        private void OnEnable()
        {

        }

        /// <summary>
        /// Called when the script becomes disabled or when it is being destroyed.
        /// </summary>
        private void OnDisable()
        {

        }

        /// <summary>
        /// Called when the script is being destroyed.
        /// </summary>
        private void OnDestroy()
        {
            Plugin.Log?.Debug($"{name}: OnDestroy()");
            if (Instance == this)
                Instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.

        }
        #endregion
    }
}
