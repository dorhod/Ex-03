using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A17_Ex03_Logic
{
    public class Comment
    {
        public String Created_time { get; set; }
        public String Sender { get; set; }
        public String Message { get; set; }
        public String Id { get; set; }
        public bool UserLiked { get; set; }

        public String UserComment { get; set; }

        public Comment(JsonObject i_Post)
        {
            Created_time = "";
            UserComment = "";

            JsonObject From = parseJson<JsonObject>("from", i_Post);
            if (From != null)
            {
                Sender = parseJson<string>("name", From);
            }

            UserLiked = parseJson<bool>("user_likes", i_Post);
            Message = parseJson<string>("message", i_Post);
            Created_time = parseJson<string>("created_time", i_Post);
            Id = parseJson<string>("id", i_Post);
        }

        public void sendComment()
        {
            PostReaction.CommentOnPost(UserComment, Id);
        }

        private T parseJson<T>(String i_Value, JsonObject i_Json)
        {
            object jsonParse;
            i_Json.TryGetValue(i_Value, out jsonParse);

            return (T)jsonParse;
        }
    }
}
