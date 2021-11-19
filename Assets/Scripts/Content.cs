using System.Collections.Generic;

public static class Content
{
    private static List<IContent> _contentList;
    
    public static void Init()
    {
        _contentList = new List<IContent>();
        _contentList.AddRange(Block.GetAll());
        _contentList.AddRange(Floor.GetAll());
        _contentList.AddRange(Item.GetAll());
         
        for (var i = 0; i < _contentList.Count; i++)
        {
            _contentList[i].SetID(i);
        }
    }
    
    public static T GetByID<T>(int id) where T : IContent
    {
        return (T) _contentList[id];
    }
}