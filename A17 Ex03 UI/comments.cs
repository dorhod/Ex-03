using A17_Ex03_Logic;
using Facebook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace A17_Ex03_UI
{
    public partial class comments : Form
    {
        private readonly FacebookClient r_FbUser = new FacebookClient(AppSettings.GetSettings().LastAccessToken);

        public List<Comment> commentsList = new List<Comment>();

        public comments(String PostID)
        {
            InitializeComponent();

            object results = r_FbUser.Get(String.Format("{0}/comments?fields=like_count,from,id,message,user_likes,created_time", PostID));
           
            JsonObject jsonResults = results as JsonObject;

            JsonArray jsoncomments = (JsonArray)jsonResults[0];

            foreach (JsonObject comment in jsoncomments)
            {
                commentsList.Add(new Comment(comment));
            }
            if (commentsList != null)
            {
                try
                {
                    commentBindingSource.DataSource = commentsList;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            

        }

        private void buttonComment_Click(object sender, EventArgs e)
        {
            Comment comment = commentBindingSource.Current as Comment;
            PostReaction.CommentOnPost(comment.UserComment, comment.Id);
        }
    }
}
