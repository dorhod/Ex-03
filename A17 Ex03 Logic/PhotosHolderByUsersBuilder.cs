using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace A17_Ex03_Logic
{
    public class PhotosHolderByUsersBuilder : IPhotosHolderBuilder<String>
    {
        private PhotosHolder<String> photosHolderByUser = new PhotosHolder<String>();

        public void AddPhotosToList(List<Photo> i_Photos)
        {
            foreach (Photo photo in i_Photos)
            {
                FacebookObjectCollection<PhotoTag> photoTags = photo.Tags;

                if (photoTags != null)
                {
                    foreach (PhotoTag photoTag in photoTags)
                    {
                        photosHolderByUser.m_PhotosByList[photoTag.User.Name].Add(photo);
                    }
                }
            }
        }

        public void CreateList(List<Photo> i_Photos)
        {
            Dictionary<String, List<Photo>> photosByUserList = new Dictionary<String, List<Photo>>();

            foreach (Photo photo in i_Photos)
            {
                FacebookObjectCollection<PhotoTag> photoTags = photo.Tags;

                if (photoTags != null)
                {
                    foreach (PhotoTag photoTag in photoTags)
                    {
                        if (!photosByUserList.ContainsKey(photoTag.User.Name))
                        {
                            photosByUserList.Add(photoTag.User.Name, new List<Photo>());
                        }
                    }
                }
            }

            photosHolderByUser.m_PhotosByList = photosByUserList;
        }

        public PhotosHolder<String> GetPhotosHolderFrom(List<Photo> i_Photos)
        {
            CreateList(i_Photos);
            AddPhotosToList(i_Photos);

            return photosHolderByUser;
        }
    }
}
