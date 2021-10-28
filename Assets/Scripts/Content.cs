using System.Collections.Generic;

public static class Content
{
    public static void Init()
    {
        var items = new List<IContent>();
        items.AddRange(Block.GetAll());
        items.AddRange(Floor.GetAll());
         
        for (var i = 0; i < items.Count; i++)
        {
            items[i].SetID(i);
        }
    }
}