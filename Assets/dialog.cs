using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLine
{
    public string text = "DEFAULT";
    public Color color = Color.white;

    public DialogLine(string text, Color color)
    {
        this.text = text;
        this.color = color;
    }
}

public class dialog : MonoBehaviour
{
    private static Color sensibleColor = new Color(0.5137f, 0.1098f, 0.1255f);
    private static Color lawmakerColor = new Color(0.2117f, 0.5961f, 0.8902f);
    private static Color NRAColor = new Color(0.8901f, 0.8471f, 0.2118f);

    public static DialogLine hail = new DialogLine("\"Howdy there cowpoke, mind relieving yourself of that weapon? We've had a rash of young'uns getting murdered.\"", sensibleColor);
    public static DialogLine hailResponse = new DialogLine("\"Ahh geeze I don't know.\"", lawmakerColor);
    public static DialogLine intervention = new DialogLine("Oh man I gotta step in.", NRAColor);

    // Set the help text appropriately.

    public static DialogLine sweetNothing0 = new DialogLine("\"There's nothing you can do about school shootings.\"", NRAColor);
    public static DialogLine sweetNothing1 = new DialogLine("\"Here's some money.\"", NRAColor);
    public static DialogLine sweetNothing2 = new DialogLine("\"It's a consitituonal right.\"", NRAColor);

}
