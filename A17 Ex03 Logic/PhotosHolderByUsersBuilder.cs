using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace A17_Ex03_Logic
{
    public class PhotosHolderByUsersBuilder : IPhotosHolderBuilder<User>
    {
        private PhotosHolder<User> photosHolderByUser = new PhotosHolder<User>();

        public void AddPhotosToList(List<Photo> i_Photos)
        {
            foreach (Photo photo in i_Photos)
            {
                FacebookObjectCollection<PhotoTag> photoTags = photo.Tags;

                if (photoTags != null)
                {
                    foreach (PhotoTag photoTag in photoTags)
                    {
                        photosHolderByUser.m_PhotosByList[photoTag.User].Add(photo);
                    }
                }
            }
        }

        public void CreateList(List<Photo> i_Photos)
        {
            Dictionary<User, List<Photo>> photosByUserList = new Dictionary<User, List<Photo>>();

            foreach (Photo photo in i_Photos)
            {
                FacebookObjectCollection<PhotoTag> photoTags = photo.Tags;

                if (photoTags != null)
                {
                    foreach (PhotoTag photoTag in photoTags)
                    {
                        if (!photosByUserList.ContainsKey(photoTag.User))
                        {
                            photosByUserList.Add(photoTag.User, new List<Photo>());
                        }
                    }
                }
            }

            photosHolderByUser.m_PhotosByList = photosByUserList;
        }

        public PhotosHolder<User> GetPhotosHolderFrom(List<Photo> i_Photos)
        {
            CreateList(i_Photos);
            AddPhotosToList(i_Photos);

            return photosHolderByUser;
        }
    }
}
