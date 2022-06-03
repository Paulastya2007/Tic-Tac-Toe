using UnityEngine;

public class MouseEvents : MonoBehaviour
{

    private GameObject parent;
    private ColorControl colorControl;
    private Position parentPosition;

    private void Awake()
    {
        //get parent
        parent = GameObject.Find(gameObject.transform.parent.gameObject.name);
        parentPosition = parent.GetComponent<Position>();
        //get renderer
        colorControl = GetComponent<ColorControl>();
    }

    private void OnMouseEnter()
    {
        if (parentPosition.isClicked == false && !colorControl.IsPositionInvisible())
        {
            colorControl.SetColor(colorControl.BaseColor);
        }
    }

    private void OnMouseExit()
    {
        if (parentPosition.isClicked == false && !colorControl.IsPositionInvisible())
        {
            colorControl.SetColor(colorControl.AlphaColor);
        }
    }

    private void OnMouseDown()
    {
        if (!isPositionAlreadyClicked())
        {
            GameObject scripts = GameObject.Find("Scripts");
            GameController gameController = (GameController)scripts.GetComponent(typeof(GameController));
            if (parentPosition.isClicked == false)
            {
                setPlayerXorCircleChoice();
                if (isCurrentSelectionPlayersChoice())
                {
                    renderPositionClicked(gameObject);
                    gameController.IncrementPositionScore(parent.name, gameController.playerBoard);
                }
                int aiPosition = gameController.PlayAiTurn(gameObject);
                gameController.IncrementPositionScore(gameController.boardIntegerStringMapper[aiPosition], gameController.opponentBoard);
                gameController.IsGameOver();
            }
        }
    }

    private bool isPositionAlreadyClicked()
    {
        return colorControl.InvisibleColor.ToString().Equals(colorControl.GetColor().ToString());
    }


    public void renderPositionClicked(GameObject position)
    {
        position.GetComponent<ColorControl>().SetColor(position.GetComponent<ColorControl>().BaseColor);
        parent = GameObject.Find(position.transform.parent.gameObject.name);
        parent.GetComponent<Position>().isClicked = true;
    }

    private bool isCurrentSelectionPlayersChoice()
    {
        return GameController.playersChoice == gameObject.name;
    }

    private void setPlayerXorCircleChoice()
    {
        if (GameController.playersChoice == "")
        {
            GameController.playersChoice = gameObject.name;
            colorControl.ClearBoardOfNonePlayerAvailableChoices();
        }
    }

}
