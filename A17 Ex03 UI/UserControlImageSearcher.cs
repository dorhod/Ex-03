using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using A17_Ex03_Logic;
using System.Threading;

namespace A17_Ex03_UI
{
    public partial class UserControlImageSearcher : UserControl
    {
        readonly List<Photo>        r_PhotosDisplayed = new List<Photo>();
        private ImageSearcherLogic  m_ImageSearcherLogicItem;
        User                        m_LoggedInUser;

        public UserControlImageSearcher(User i_LoggedUser)
        {
            InitializeComponent();
            m_LoggedInUser = i_LoggedUser;
            m_ImageSearcherLogicItem = new ImageSearcherLogic(i_LoggedUser);
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

        private void buttonSearchPhotos_Click(object sender, EventArgs e)
        {
            listViewPhotoDisplay.Clear();
            imageListFromUser.Dispose();

            m_ImageSearcherLogicItem.filterPhotosByUserName(checkBoxUserTaggedWith.CheckedItems);
            m_ImageSearcherLogicItem.filterPhotosByYear(checkedListBoxYearOfPhoto.CheckedItems);
            setPhotosToDisplay(m_ImageSearcherLogicItem.m_PhotosCheckedByUser);
        }

        private void createControll()
        {
            setPhotosToDisplay(m_UserPhotos);
            setYearsList();
            setUsersList();
        }

        private void setPhotosToDisplay(List<Photo> i_Photolist)
        {
            r_PhotosDisplayed.Clear();

            List<System.Drawing.Image> sy = new List<System.Drawing.Image>();

            Thread featch = new Thread(() =>
            {
                foreach (Photo photo in i_Photolist)
                {
                    Thread T = new Thread(() =>
                    {
                        System.Drawing.Image newPhoto = photo.ImageNormal;
                        lock (this)
                        {
                            sy.Add(newPhoto);
                        }

                    });
                    T.Start();

                    r_PhotosDisplayed.Add(photo);
                }
            });

            featch.Start();
            featch.Join();

            imageListFromUser.Images.AddRange(sy.ToArray()); 

            listViewPhotoDisplay.View = View.LargeIcon;
            listViewPhotoDisplay.LargeImageList = imageListFromUser;

            for (int j = 0; j < this.imageListFromUser.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listViewPhotoDisplay.Items.Add(item);
            }
        }

        private void setYearsList()
        {
            // Create a list of years that has photos
            List<int> yearsOfPhotos = photosHolderByYears.m_PhotosByList.Keys.ToList();
            checkedListBoxYearOfPhoto.Items.Clear();

            foreach (int yearOfPhoto in yearsOfPhotos)
            {
                checkedListBoxYearOfPhoto.Items.Add(yearOfPhoto);
            }
        }

        private void setUsersList()
        {
            List<User> usersList = photosHolderByUsers.m_PhotosByList.Keys.ToList();
            checkBoxUserTaggedWith.Items.Clear();

            foreach (User user in usersList)
            {
                    checkBoxUserTaggedWith.Items.Add(user.Name);
            }
        }

        private void buttonOpenSelectedPhoto_Click(object sender, EventArgs e)
        {
            FormImageReaction newImageReaction = new FormImageReaction(r_PhotosDisplayed.ElementAt(listViewPhotoDisplay.SelectedIndices[0]));
            newImageReaction.Show();
        }

    }
}
