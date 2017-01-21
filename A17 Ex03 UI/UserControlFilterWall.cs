using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using A17_Ex03_Logic;

namespace A17_Ex03_UI
{
    public partial class UserControlFilterWall : UserControl
    {
        private readonly ProxyFaceBookClient r_FbUser = new ProxyFaceBookClient(AppSettings.GetSettings().LastAccessToken);
        private List<WallPost>              m_Posts;
        private int                         m_PostsAmountToDisplay;

        public UserControlFilterWall()
        {
            InitializeComponent();
            m_PostsAmountToDisplay = 10;          
        }

        public void SetPosts()
        {
            try
            {
                m_Posts = r_FbUser.Get("me/feed?fields=message,likes{name},comments{from},story,source,created_time,picture,from&limit=10000") as List<WallPost>;
                orderFeedByDate();
            }
            finally
            {

            }
        }

        private void setFeed(List<WallPost> i_PhotosToDisplay)
        {
            flowLayoutPanel.Controls.Clear();
            foreach (WallPost post in i_PhotosToDisplay.Take(m_PostsAmountToDisplay))
            {
                flowLayoutPanel.Controls.Add(new UserControlPost(post));
            }
        }

        private void orderFeedByLikes()
        {
            IEnumerable<WallPost> orderFeedByLikes = m_Posts.OrderByDescending(post => post.LikeCount);
            setFeed(orderFeedByLikes.ToList());
        }

        private void orderFeedByDate()
        {
            IEnumerable<WallPost> orderFeedByTime = m_Posts.OrderByDescending(post => post.Time);
            setFeed(orderFeedByTime.ToList());
        }

        private void comboBoxWallFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadFeed();
        }

        private void comboBoxNumberToDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_PostsAmountToDisplay = comboBoxNumberToDisplay.SelectedItem.ToString() == "All" ? m_Posts.Count : int.Parse(comboBoxNumberToDisplay.SelectedItem.ToString());
            loadFeed();
        }

        private void loadFeed()
        {
            if (comboBoxWallFilter.SelectedIndex == 1)
            {
                orderFeedByLikes();
            }
            else
            {
                setFeed(m_Posts);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SetPosts();
        }
    }
}
