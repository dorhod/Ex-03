using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A17_Ex03_Logic
{
    public class PhotosHolder<T>
    {
        public Dictionary<T, List<Photo>> m_PhotosByList;
    }
}
