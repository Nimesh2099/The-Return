using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // check item in room 
        if(CheckItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        // check item in inventory
        if(CheckItems(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = "There is no " + noun + " here to examine.";

    }

    private bool CheckItems(GameController controller,List<Item> items, string noun)
    {
        foreach (Item item in items)
        {    
            if(item.itemName.ToLower() == noun)
            {
                if(item.InteractWith(controller,"examine"))
                {
                    return true;
                }
                controller.currentText.text = "You see " + item.description;

                return true;
            }
        }
        return false;
    }
}
