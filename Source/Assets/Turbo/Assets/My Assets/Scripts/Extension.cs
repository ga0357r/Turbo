using System.Collections;
using UnityEngine;

namespace Turbo
{
    public struct Extension
    {
        /// <summary>
        /// Wait for a few seconds before completely loading the scene
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static IEnumerator WaitForSecondsBeforeCompletelyLoadingTheScene(int seconds)
        {
            yield return new WaitForSeconds(seconds);

            LoadingScreen.loading_screen.scene_has_loaded = true;
        }

        /// <summary>
        /// Wait for a few seconds before disbling gameobjects
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="animator"></param>
        /// <param name="animator_state_name"></param>
        /// <param name="go"></param>
        /// <returns></returns>
        public static IEnumerator WaitForSecondsBeforedisablingGameobjects(float seconds, Animator animator, string animator_state_name, GameObject[] go)
        {
            //wait for some seconds
            yield return new WaitForSeconds(seconds);

            //is the correct animation playing
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(animator_state_name) && animator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                //turn the gameobjects off
                for (int i = 0; i < go.Length; i++)
                {
                    go[i].SetActive(false);
                }
            }

        }

        /// <summary>
        /// Enable gameobjects
        /// </summary>
        /// <param name="go"></param>
        public static void EnableGameobjects(GameObject[] go)
        {
            for (int i = 0; i < go.Length; i++)
            {
                go[i].SetActive(true);
            }
        }

        /// <summary>
        /// Disable Gameobjects
        /// </summary>
        /// <param name="go"></param>
        public static void DisableGameobjects(GameObject[] go)
        {
            for (int i = 0; i < go.Length; i++)
            {
                go[i].SetActive(false);
            }
        }

        /// <summary>
        /// return to idle state after some seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="animator"></param>
        /// <param name="animator_trigger_name"></param>
        /// <returns></returns>
        public static IEnumerator WaitForSecondsBeforeReturningToIdleState(float seconds, Animator animator, string animator_trigger_name)
        {
            // wait for some seconds
            yield return new WaitForSeconds(seconds);

            //if the animation has completed of finished playing
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
            {
                //return to the idle state

                //set trigger
                animator.SetTrigger(animator_trigger_name);
            }

        }

        /// <summary>
        /// modify the color parameter of an image component
        /// </summary>
        /// <param name="color"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public static void ModifyColorComponent(Color color, float r, float g, float b, float a)
        {
            color = new Color(r, g, b, a);
        }

        /// <summary>
        /// modify the color parameter of an image component
        /// </summary>
        /// <param name="color"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public static void ModifyColorComponent(Color[] color, float r, float g, float b, float a)
        {
            for (int i = 0; i < color.Length; i++)
            {
                color[i] = new Color(r, g, b, a);
            }
            
        }

        
    }

   
}
