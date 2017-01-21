using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace A17_Ex03_Logic
{

    static class PhotoFilter
    {

        private static List<Photo> m_FliteredPhotos = new List<Photo>();
        private static Boolean b_FirstCheck = true;


        public static List<Photo> GetFilteredPhotos()
        {
            return m_FliteredPhotos;
        }

        public static void setPhotosBy(List<Photo> i_PhotosToAdd)
        {
            if (b_FirstCheck == true)
            {
                addFirstFilter(i_PhotosToAdd);
;
            }
            else
            {
                crossFilters(i_PhotosToAdd);
            }

        }

        private static void addFirstFilter(List<Photo> i_PhotosOfUser)
        {
            foreach (Photo photo in i_PhotosOfUser)
            {
                if (!m_FliteredPhotos.Contains(photo))
                {
                    m_FliteredPhotos.Add(photo);
                }
            }
            b_FirstCheck = false;
        }

        private static void crossFilters(List<Photo> i_PhotosToAdd)
        {
            List<Photo> newFliteredPhotos = new List<Photo>();
            foreach (Photo photo in m_FliteredPhotos)
            {
                if (i_PhotosToAdd.Contains(photo))
                {
                    newFliteredPhotos.Add(photo);
                }
            }
            m_FliteredPhotos = newFliteredPhotos;
        }


    }
}
