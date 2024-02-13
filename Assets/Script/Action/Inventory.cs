using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if(controller.player.inventory.Count > 0)
        {
            controller.currentText.text = "You are carrying: ";
            foreach (Item item in controller.player.inventory)
            {
                controller.currentText.text += "\n" + item.itemName;
            }
        }
        else
        {
            controller.currentText.text = "You are not carrying anything";
        }
    }
}
