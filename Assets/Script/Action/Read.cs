using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        if (ReadItems(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = "You can't read " + noun;
    }

    private bool ReadItems(GameController controller, List<Item> items, string noun)
    {
        
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun)
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                    {
                        return true;
                    }
                }
                controller.currentText.text = "You can't read the " + noun;
                return true;
            }
        }
        return false;
    }
}
