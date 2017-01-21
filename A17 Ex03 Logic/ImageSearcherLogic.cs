using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.Threading;
using System.Collections.Generic;

namespace A17_Ex03_Logic
{
    public class ImageSearcherLogic
    {
        public List<Photo>                  m_PhotosCheckedByUser;
        public List<Photo>                  m_UserPhotos = new List<Photo>();
        public PhotosHolder<int>            photosHolderByYears;
        public PhotosHolder<User>           photosHolderByUsers;

        public ImageSearcherLogic(User i_LoggedInUser)
        {
            GetPhotosFromUser(i_LoggedInUser);
            photosHolderByUsers = new PhotosHolderByUsersBuilder().GetPhotosHolderFrom(m_UserPhotos);
            photosHolderByYears = new PhotosHolderByYearsBuilder().GetPhotosHolderFrom(m_UserPhotos);       
        }

        public void GetPhotosFromUser(User i_CurrentUser)
        {
            List<Photo> userPhotos = new List<Photo>();

            foreach (Album album in i_CurrentUser.Albums)
            {
                userPhotos.AddRange(album.Photos);
            }

            userPhotos.AddRange(i_CurrentUser.PhotosTaggedIn);

            m_UserPhotos = userPhotos;
        }

        public void filterPhotosByYear(CheckedListBox.CheckedItemCollection i_CheckedItemsYearOfPhoto)
        {

            foreach (int year in photosHolderByYears.m_PhotosByList.Keys)
            {
                {
                    if (i_CheckedItemsYearOfPhoto.Contains(year))
                    {
                        PhotoFilter.setPhotosBy(m_PhotosByYearList[year]);
                    }
                }
            }
            m_PhotosCheckedByUser = PhotoFilter.GetFilteredPhotos();
        }

        private void setPhotosByYear(int i_Year)
        {

                if (b_FirstCheck == true)
                {
                    foreach (Photo photo in m_PhotosByYearList[i_Year])
                    {
                        if (!m_PhotosCheckedByUser.Contains(photo))
                        {
                            m_PhotosCheckedByUser.Add(photo);
                        }
                    }
                    b_FirstCheck = false;
                }
                else
                {
                    deletePhotos(i_Year);
                }
            
        }


        private void addUserPhotos(List<Photo> i_PhotosOfUser)
        {
            foreach (Photo photo in i_PhotosOfUser)
            {
                if (!m_PhotosCheckedByUser.Contains(photo))
                {
                    m_PhotosCheckedByUser.Add(photo);
                }
            }
            b_FirstCheck = false;
        }

        private void deletePhotos(int i_Year)
        {
            List<Photo> photosToDelete = new List<Photo>();
            foreach (Photo photo in m_PhotosCheckedByUser)
            {
                if (photo.CreatedTime.GetValueOrDefault().Year != i_Year)
                {
                    photosToDelete.Add(photo);
                }
            }

            foreach (Photo photo in photosToDelete)
            {
                m_PhotosCheckedByUser.Remove(photo);
            }
        }

        public void filterPhotosByUserName(CheckedListBox.CheckedItemCollection i_CheckedItemsTaggedInPhoto)
        {
            m_PhotosCheckedByUser = new List<Photo>();
            PhotoFilter.b_FirstCheck = true;

            foreach (UserWithPhotos taggedUser in m_PhotosByUserList)
            {
                if (i_CheckedItemsTaggedInPhoto.Contains(taggedUser.CurrentUser.Name))
                {
                    PhotoFilter.setPhotosBy(taggedUser.UserPhotos);
                }

            }

            m_PhotosCheckedByUser = PhotoFilter.GetFilteredPhotos();
        }

        private void setPhotosByUserName(UserWithPhotos i_TaggedUser)
        {
            if (b_FirstCheck == true)
            {
                addUserPhotos(i_TaggedUser.PhotosOfUser);
            }
            else
            {
                crossUsersPhotos(i_TaggedUser);
            }
        }

    }
}
