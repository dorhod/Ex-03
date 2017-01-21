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
            labelYearError.Hide();
            labelSelectedPhotoError.Hide();
            m_LoggedInUser = i_LoggedUser;
            m_ImageSearcherLogicItem = new ImageSearcherLogic(i_LoggedUser);
            createControl();
        }

        private void buttonSearchPhotos_Click(object sender, EventArgs e)
        {
            listViewPhotoDisplay.Clear();
            imageListFromUser.Dispose();

            if (checkedListBoxYearOfPhoto.CheckedItems.Count > 1)
            {
                labelYearError.Show();
            }
            else
            {
                labelYearError.Hide();
                m_ImageSearcherLogicItem.filterPhotosByUserName(checkBoxUserTaggedWith.CheckedItems);
                m_ImageSearcherLogicItem.filterPhotosByYear(checkedListBoxYearOfPhoto.CheckedItems);
                setPhotosToDisplay(m_ImageSearcherLogicItem.m_PhotosCheckedByUser);
            }
        }

        private void createControl()
        {
            setPhotosToDisplay(m_ImageSearcherLogicItem.m_UserPhotos);
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
                            r_PhotosDisplayed.Add(photo);
                        }

                    });
                    T.Start();
                    T.Join();
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
            List<int> yearsOfPhotos = m_ImageSearcherLogicItem.photosHolderByYears.m_PhotosByList.Keys.ToList();
            checkedListBoxYearOfPhoto.Items.Clear();

            foreach (int yearOfPhoto in yearsOfPhotos)
            {
                checkedListBoxYearOfPhoto.Items.Add(yearOfPhoto);
            }
        }

        private void setUsersList()
        {
            checkBoxUserTaggedWith.Items.Clear();
            foreach (String userName in m_ImageSearcherLogicItem.photosHolderByUsers.m_PhotosByList.Keys)
            {
                    checkBoxUserTaggedWith.Items.Add(userName);
            }
        }

        private void buttonOpenSelectedPhoto_Click(object sender, EventArgs e)
        {
            if (listViewPhotoDisplay.SelectedItems.Count == 0)
            {
                labelSelectedPhotoError.Show();
            }
            else
            {
                labelSelectedPhotoError.Hide();
                FormImageReaction newImageReaction = new FormImageReaction(r_PhotosDisplayed.ElementAt(listViewPhotoDisplay.SelectedIndices[0]));
                newImageReaction.Show();
            }

        }

    }
}
