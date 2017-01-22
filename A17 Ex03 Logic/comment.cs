using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A17_Ex03_Logic
{
    public class Comment
    {
        String Created_time { get; set; }
        String Sender { get; set; }
        String Message { get; set; }
        String Id { get; set; }
        bool UserLiked { get; set; }

        public Comment(JsonObject i_Post)
        {
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

        private T parseJson<T>(String i_Value, JsonObject i_Json)
        {
            object jsonParse;
            i_Json.TryGetValue(i_Value, out jsonParse);

            return (T)jsonParse;
        }
    }
}
