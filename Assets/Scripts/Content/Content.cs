using System.Collections.Generic;

namespace Content
{
    public static class Content
    {
        private static List<IContent> _contentList;
    
        public static void Init()
        {
            _contentList = new List<IContent>();
            _contentList.AddRange(Block.GetAll());
            _contentList.AddRange(Floor.GetAll());
            _contentList.AddRange(Item.GetAll());
        }

        public static List<T> GetByType<T>() where T : IContent
        {
            var matchingList = new List<T>();

            _contentList.ForEach(content =>
            {
                if (content is T c)
                    matchingList.Add(c);
            });

            return matchingList;
        }
    }
}