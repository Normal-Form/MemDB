using Grpc.Core;
using MemDB.Interfaces;

namespace MemDB.Services;

public class RecordService : Record.RecordBase
{
    protected IRecordDB Record { get; set; }

    public RecordService(IRecordDB record)
    {
        this.Record = record;      
    }

    public override Task<GetResponse> Get(GetRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GetResponse
        {
            Value = this.Record.Get(request.Key)
        });
    }

    public override Task<SetResponse> Set(SetRequest request, ServerCallContext context)
    {
        this.Record.Set(request.Key, request.Value);

        return Task.FromResult(new SetResponse
        {
            Success = true
        });
    }
}
