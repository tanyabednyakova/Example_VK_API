using System;
using System.IO;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace Example_VK_API
{
    class Program
    {
        // получить токен из файла
        public static string getAuth()
        {
            string fileName = @"auth_vk.txt";
            string token = "";
            try
            {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        token = sr.ReadLine();
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return token;
        }

        static void Main(string[] args)
        {

            var api_group = new VkApi();
            // обработать исключения!
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = getAuth()
            });

            // получить список подписчиков сообщества (для сообщества)
            var getFollowers = api_group.Groups.GetMembers(new GroupsGetMembersParams() { 
                GroupId = "205575031", 
                Fields = VkNet.Enums.Filters.UsersFields.FirstNameAbl 
            });
            foreach (User user in getFollowers)
                Console.WriteLine(user.FirstName);
            // получит запись со стены (для пользователя)
            var api_user = new VkApi();
            // обработать исключения!
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = getAuth()
            });
            var get = api_user.Wall.Get(new WallGetParams());
            foreach (var wallPosts in get.WallPosts)
                Console.WriteLine(wallPosts.Text);
  






        }
    }
}
