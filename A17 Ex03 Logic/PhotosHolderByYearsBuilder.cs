using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace A17_Ex03_Logic
{
    public class PhotosHolderByYearsBuilder : IPhotosHolderBuilder<int>
    {
        private PhotosHolder<int> photosHolderByYears = new PhotosHolder<int>();

        public void AddPhotosToList(List<Photo> i_Photos)
        {
            foreach (Photo photo in i_Photos)
            {
                // Create a list of photos by the year they were added
                photosHolderByYears.m_PhotosByList[photo.CreatedTime.GetValueOrDefault().Year].Add(photo);
            }
        }

        public void CreateList(List<Photo> i_Photos)
        {
            Dictionary<int, List<Photo>> photosByYearList = new Dictionary<int, List<Photo>>();

            foreach (Photo photo in i_Photos)
            {
                // Create a list of years that has photos
                if (!photosByYearList.ContainsKey(photo.CreatedTime.GetValueOrDefault().Year))
                {
                    photosByYearList.Add(photo.CreatedTime.GetValueOrDefault().Year, new List<Photo>());
                }
            }

            photosHolderByYears.m_PhotosByList = photosByYearList;
        }

        public PhotosHolder<int> GetPhotosHolderFrom(List<Photo> i_Photos)
        {
            CreateList(i_Photos);
            AddPhotosToList(i_Photos);

            return photosHolderByYears;
        }
    }
}
