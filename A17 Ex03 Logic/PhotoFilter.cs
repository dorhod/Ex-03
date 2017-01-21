using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace A17_Ex03_Logic
{

     public class PhotoFilter
    {
        private static PhotoFilter instance;

        private List<Photo> m_FliteredPhotos;
        public Boolean b_FirstCheck { get; set; }


        private PhotoFilter() {
            this.m_FliteredPhotos = new List<Photo>();
            b_FirstCheck = true;
        }


        public static PhotoFilter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhotoFilter();
                }
                return instance;
            }
        }

        public List<Photo> GetFilteredPhotos()
        {
            return m_FliteredPhotos;
        }

        public void setPhotosBy(List<Photo> i_PhotosToAdd)
        {
            if (b_FirstCheck == true)
            {
                m_FliteredPhotos.Clear();
                addFirstFilter(i_PhotosToAdd);
;
            }
            else
            {
                crossFilters(i_PhotosToAdd);
            }

        }

        private void addFirstFilter(List<Photo> i_PhotosOfUser)
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

        private void crossFilters(List<Photo> i_PhotosToAdd)
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
