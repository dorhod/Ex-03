﻿using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.Threading;
using System.Collections.Generic;

namespace A17_Ex03_Logic
{
    public class ImageSearcherLogic
    {
        public List<Photo>                  m_AllPhotosList = new List<Photo>();
        public List<UserWithPhotos>         m_PhotosByUserList = new List<UserWithPhotos>();
        public Dictionary<int, List<Photo>> m_PhotosByYearList = new Dictionary<int, List<Photo>>();
        public List<Photo>                  m_ListOfYears = new List<Photo>();
        public List<PhotoTag>               m_ListOfTaggedUsers = new List<PhotoTag>();
        public List<Photo>                  m_PhotosCheckedByUser;
        public Boolean                      b_FirstCheck;

        public ImageSearcherLogic(User i_LoggedInUser)
        {
            fetchAllPicturesOfMainUser(i_LoggedInUser);
        }

        public List<Photo> fetchAllPicturesOfMainUser(User i_LoggedInUser)
        {
            PicturesColleciton picture = i_LoggedInUser.Pictures;

            foreach (Album album in i_LoggedInUser.Albums)
            {
                addAllPhotos(album.Photos);
            }

            addAllPhotos(i_LoggedInUser.PhotosTaggedIn);

            return m_AllPhotosList;
        }

        public void addAllPhotos(FacebookObjectCollection<Photo> i_Photos)
        {
            foreach (Photo photo in i_Photos)
            {
                m_AllPhotosList.Add(photo);

                // Create a list of years that has photos
                if (!m_PhotosByYearList.ContainsKey(photo.CreatedTime.GetValueOrDefault().Year))
                {
                    m_PhotosByYearList.Add(photo.CreatedTime.GetValueOrDefault().Year, new List<Photo>());
                }

                // Create a list of photos by the year they were added
                m_PhotosByYearList[photo.CreatedTime.GetValueOrDefault().Year].Add(photo);

                Thread T = new Thread(() => createListOfPhotosByUser(photo));
                T.Start();
            }
        }

        public void createListOfPhotosByUser(Photo i_Photo)
        {
            FacebookObjectCollection<PhotoTag> photoTags = i_Photo.Tags;
            int indexOfTaggedUser;

            if (i_Photo.Tags != null)
            {
                foreach (PhotoTag photoTag in photoTags)
                {
                    lock (this)
                    {
                        indexOfTaggedUser = photosByUserListContains(photoTag.User.Name);
                        if (indexOfTaggedUser != -1)
                        {
                            m_PhotosByUserList[indexOfTaggedUser].AddPhotoToUser(i_Photo);
                        }
                        else
                        {
                            m_PhotosByUserList.Add(new UserWithPhotos(photoTag.User, i_Photo));
                        }
                    }
                    // Add all tagged names to check box list
                    m_ListOfTaggedUsers.Add(photoTag);
                }
            }
        }

        private int photosByUserListContains(string i_NameOfUser)
        {
            int indexOfTaggedUser = 0;
            foreach (UserWithPhotos taggedUser in this.m_PhotosByUserList)
            {
                if (taggedUser.TaggedUser.Name.Equals(i_NameOfUser))
                    return indexOfTaggedUser;
                indexOfTaggedUser++;
            }

            return -1;
        }

        public void filterPhotosByYear(CheckedListBox.CheckedItemCollection i_CheckedItemsYearOfPhoto)
        {
            foreach (int year in m_PhotosByYearList.Keys)
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

        public void filterPhotosByUserName(CheckedListBox.CheckedItemCollection i_CheckedItemsTaggedInPhoto)
        {
            m_PhotosCheckedByUser = new List<Photo>();
            PhotoFilter.b_FirstCheck = true;

            foreach (UserWithPhotos taggedUser in m_PhotosByUserList)
            {
                if (i_CheckedItemsTaggedInPhoto.Contains(taggedUser.TaggedUser.Name))
                {
                    PhotoFilter.setPhotosBy(taggedUser.PhotosOfUser);
                }

            }

            m_PhotosCheckedByUser = PhotoFilter.GetFilteredPhotos();
        }

    }
}
