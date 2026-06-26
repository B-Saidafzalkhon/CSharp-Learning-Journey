namespace _24_async_chain
{
    internal class Program
    {
        static async Task<int> GetUserIdAsync()
        {
            Console.WriteLine("Getting user id...");
            await Task.Delay(2000);
            return 7;
        }
        static async Task<string> GetUserNameAsync(int id)
        {
            Console.WriteLine($"Getting user name by id: ({id})");
            await Task.Delay(2000);
            return $"User_{id}";
        }
        static async Task<string> GetUserProfileAsync()
        {
            int id = await GetUserIdAsync();
            string name = await GetUserNameAsync(id);
            return $"Profile Id: {id} | User name: {name}";
        }
        static async Task Main(string[] args)
        {
            string profile = await GetUserProfileAsync();
            Console.WriteLine(profile);
        }
        // Each method that uses await must be async and return Task or Task<T>.
        // await pauses the current method until the asynchronous operation is completed
        // and gives us the actual result instead of Task<T>.
        // If we remove await in the middle of the chain, we will get Task<int> or Task<string>
        // instead of int or string, so the next line will not work correctly.
    }
}
