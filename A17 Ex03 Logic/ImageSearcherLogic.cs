﻿using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.Threading;
using System.Collections.Generic;

namespace A17_Ex03_Logic
{
    public class ImageSearcherLogic
    {
        public List<Photo> m_PhotosCheckedByUser;
        public List<Photo> m_UserPhotos = new List<Photo>();
        public PhotosHolder<int> photosHolderByYears;
        public PhotosHolder<User> photosHolderByUsers;

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
                        PhotoFilter.setPhotosBy(photosHolderByYears.m_PhotosByList[year]);
                    }
                }
            }
            m_PhotosCheckedByUser = PhotoFilter.GetFilteredPhotos();
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

    }
}
