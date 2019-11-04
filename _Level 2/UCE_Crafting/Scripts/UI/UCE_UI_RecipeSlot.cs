// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#if _iMMOCRAFTING

// ===================================================================================
// CRAFTING SLOT
// ===================================================================================
public class UCE_UI_RecipeSlot : MonoBehaviour
{
    public Text nameText;
    public Image image;
    public UIShowToolTip tooltip;

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show(string recipeName)
    {

        UCE_Tmpl_Recipe recipe;

        UCE_Tmpl_Recipe.dict.TryGetValue(recipeName.GetStableHashCode(), out recipe);

        nameText.text = recipe.name;
        image.sprite = recipe.image;
        tooltip.enabled = true;
        tooltip.text = recipe.ToolTip();
    }

    // -----------------------------------------------------------------------------------
    // ToolTip
    // -----------------------------------------------------------------------------------
    public string ToolTip(UCE_Tmpl_Recipe tpl)
    {
        StringBuilder tip = new StringBuilder();

        tip.Append(tpl.name + "\n");
        tip.Append(tpl.toolTip + "\n");

        return tip.ToString();
    }

    // -----------------------------------------------------------------------------------
}

#endif
