using System.Collections.Generic;
using UnityEngine;

namespace Turbo
{
    /// <summary>
    /// Draw a path for the AI Cars 
    /// </summary>
    public class CarPath : MonoBehaviour
    {
        /// <summary>
        /// Color to use to visualise the path for the AI car
        /// </summary>
        public Color lineColour;

        /// <summary>
        /// Store the nodes 
        /// </summary>
        private List<Transform> nodes = new List<Transform>();

        /// <summary>
        /// Called when the scene is updated
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Path();
        }

        /// <summary>
        /// The path of the car AI
        /// </summary>
        public void Path()
        {
            //set the colour of the gizmo to the line colour
            Gizmos.color = lineColour;

            //return the transform of each node
            Transform[] path_transforms = GetComponentsInChildren<Transform>();

            //make the list empty in the begining
            nodes = new List<Transform>();

            //loop through each path_transform
            for (int i = 0; i < path_transforms.Length; i++)
            {
                //if the path transform is different from this transform 
                if (path_transforms[i] != transform)
                {
                    //add the transform to the nodes  
                    nodes.Add(path_transforms[i]);
                }
            }

            //loop through the nodes
            for (int i = 0; i < nodes.Count; i++)
            {
                //store position of the current node 
                Vector3 current_node = nodes[i].position;
                Vector3 previous_node = Vector3.zero;

                //if i is greater than zero
                if (i > 0)
                {
                    //store the previous node position
                    previous_node = nodes[i - 1].position;
                }
                //else if  i is zero and there is more than 1 element is the nodes list
                else if (i == 0 && nodes.Count > 1)
                {
                    //store the previous node by taking the last node in the array or list
                    previous_node = nodes[nodes.Count - 1].position;
                }
                Gizmos.DrawLine(previous_node, current_node);
                Gizmos.DrawWireSphere(current_node, 0.5f);
            }
        }
    }
}
