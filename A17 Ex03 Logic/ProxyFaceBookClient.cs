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
            object bas = base.Get(request);

            List<WallPost> Posts = new List<WallPost>();

            JsonObject results = bas as JsonObject;
            JsonArray posts = (JsonArray)results[0];
            Thread featch = new Thread(() =>
            {
                foreach (JsonObject post in posts)
                {
                    Thread T = new Thread(() =>
                    {
                        WallPost newPost = new WallPost(post);
                        lock (this)
                        {
                            Posts.Add(newPost);
                        }

                    });
                    T.Start();
                }

                Console.WriteLine("");

            });

            featch.Start();
            featch.Join();

            return Posts;
        }
    }

}
