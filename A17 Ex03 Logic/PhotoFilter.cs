using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace A17_Ex01_Logic
{

    class PhotoFilter
    {

        public List<Photo> m_FliteredPhotos;


        public void filterPhotosByYear<T>(IList<object> i_SelectedItemsToFilterBy, List<T> PhotoList)
        {
            m_FliteredPhotos = new List<Photo>();

            foreach (T Object in PhotoList)
            {
                if (i_SelectedItemsToFilterBy.Count < 1)
                {
                    setPhotosByYear(year, i_SelectedItemsToFilterBy);
                }
            }
        }

        public void filterPhotosByUserName(CheckedListBox.CheckedItemCollection i_CheckedItemsTaggedInPhoto)
        {
            m_FliteredPhotos = new List<Photo>();
           // b_FirstCheck = true; ADD IT ONLY ON USER NAME

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
