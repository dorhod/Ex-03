using A17_Ex03_Logic;
using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace A17_Ex03_Logic
{
    public class ProxyFaceBookClient : FacebookClient
    {
        public ProxyFaceBookClient(string accessToken) : base(accessToken)
        {

        }

        public override object Get(string request)
        {
            object baseResult = base.Get(request);

            List<WallPost> Posts = new List<WallPost>();

            JsonObject results = baseResult as JsonObject;
            JsonArray posts = (JsonArray)results[0];
            Thread mainThread = new Thread(() =>
            {
                foreach (JsonObject post in posts)
                {
                    Thread thread = new Thread(() =>
                    {
                        WallPost newPost = new WallPost(post);
                        lock (this)
                        {
                            Posts.Add(newPost);
                        }

                    });
                    thread.Start();
                }

            });

            mainThread.Start();
            mainThread.Join();

            return Posts;
        }
    }

}
