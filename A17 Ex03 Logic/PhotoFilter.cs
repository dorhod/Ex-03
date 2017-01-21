using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A17_Ex01_Logic
{
    class PhotoFilter
    {
        public void filterPhotosByYear(CheckedListBox.CheckedItemCollection i_CheckedItemsYearOfPhoto)
        {
            m_PhotosCheckedByUser = new List<Photo>();

            foreach (int year in m_PhotosByYearList.Keys)
            {
                if (i_CheckedItemsYearOfPhoto.Count > 1)
                {
                    //m_PhotosCheckedByUser.Clear();
                }
                else
                {
                    setPhotosByYear(year, i_CheckedItemsYearOfPhoto);
                }
            }
        }

        public void filterPhotosByUserName(CheckedListBox.CheckedItemCollection i_CheckedItemsTaggedInPhoto)
        {
            m_PhotosCheckedByUser = new List<Photo>();
            b_FirstCheck = true;

            foreach (UserWithPhotos taggedUser in m_PhotosByUserList)
            {
                if (i_CheckedItemsTaggedInPhoto.Contains(taggedUser.TaggedUser.Name))
                {
                    setPhotosByUserName(taggedUser);
                }

            }
        }
    }
}
