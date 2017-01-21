using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A17_Ex03_Logic
{
    public interface IPhotosHolderBuilder<T>
    {
        void CreateList(List<Photo> i_Photos);

        void AddPhotosToList(List<Photo> i_Photos);

        PhotosHolder<T> GetPhotosHolderFrom(List<Photo> i_Photos);
    }
}
