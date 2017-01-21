using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace A17_Ex03_Logic
{
    public class UserWithPhotos
    {
        public List<Photo> UserPhotos { get; set; }
        public User        CurrentUser { get; set; }

        public UserWithPhotos(User i_TaggedUser, Photo i_PhotoOfUser)
        {
            this.UserPhotos = new List<Photo>();
            this.CurrentUser = i_TaggedUser;
            UserPhotos.Add(i_PhotoOfUser);
        }

        public User getUser (){
            return CurrentUser;
        }

        public void AddPhotoToUser(Photo i_Photo)
        {
            if (!IsPhotoExist(i_Photo))
            {
                this.UserPhotos.Add(i_Photo);
            }

        }

        public Boolean IsPhotoExist(Photo i_Photo)
        {
            Boolean photoExist = false;

            foreach (Photo photo in UserPhotos)
            {
                if (photo.Id == i_Photo.Id)
                {
                    photoExist = true;
                }
            }

            return photoExist;
        }

    }
}
 
