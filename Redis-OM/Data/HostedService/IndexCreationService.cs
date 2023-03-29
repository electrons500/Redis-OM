using Redis.OM;
using Redis_OM.Data.Model;
using System;

namespace Redis_OM.Data.HostedService
{
    public class IndexCreationService : IHostedService
    {
        private readonly RedisConnectionProvider _provider;
        public IndexCreationService(RedisConnectionProvider provider)
        {
            _provider = provider;   
        }

        //Check if Index exist
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //_provider.Connection.DropIndexAndAssociatedRecords(typeof(Users));
            //_provider.Connection.DropIndexAndAssociatedRecords(typeof(Address));


            //Query Redis to get all Indexes
            var info = (await _provider.Connection.ExecuteAsync("FT._LIST")).ToArray().Select(x => x.ToString());
            if (info.All(x => x != "UsersIndex"))
            {
                await _provider.Connection.CreateIndexAsync(typeof(Users));
            }
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
