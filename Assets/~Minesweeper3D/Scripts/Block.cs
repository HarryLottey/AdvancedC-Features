using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper3D
{
    [RequireComponent(typeof(Renderer))]
    public class Block : MonoBehaviour
    {

        // Store x, y and z co-ords in arrya for later use
        public int x = 0;
        public int y = 0;
        public int z = 0;
        public bool isMine = false; // Is the current block a mine?
        private bool isRevealed = false; // Has the block already been revealed
        [Header("References")]
        public Color[] textColors;
        public TextMesh textElement; // Reference to the text element
        public Transform mine; // Reference to the mine


        private Renderer rend; // Reference to the renderer


        void Awake()
        {
            // Grab the reference to the renderer
            rend = GetComponent<Renderer>();
        }

        // Use this for initialization
        void Start()
        {
            // Detatch text Element from block
            textElement.transform.SetParent(null);
            // Randomly decide if it's a mine or not
            isMine = Random.value < .05f;
        }

        void UpdateText(int adjacentMines)
        {
            // Are there adjacent mines?
            if(adjacentMines > 0)
            {
                // Set text to amount of mines
                textElement.text = adjacentMines.ToString();
                // Check if adjacentMines are within textColors array
                if(adjacentMines >= 0 && adjacentMines < textColors.Length)
                {
                    // Set text color to whatever was present
                    textElement.color = textColors[adjacentMines];
                }

            }
        }

        public void Reveal(int adjacentMines)
        {
            // Flags the block as being revealed
            isRevealed = true;
            // Checks if block is a mine
            if (isMine)
            {
                // Activate the reference mine
                mine.gameObject.SetActive(true);
                // Detatch mine from children
                mine.SetParent(null);
            }
            else
            {
                // Updates the text to display adjacentMines
                UpdateText(adjacentMines);
            }
            // Deactivates the block
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
