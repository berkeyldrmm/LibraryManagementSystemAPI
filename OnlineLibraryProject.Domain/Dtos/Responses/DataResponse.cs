using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.Responses;

public record DataResponse<T>(T Value) : MessageResponse where T : EntityDTO;

public record ListDataResponse<T>(IEnumerable<T> Value) : MessageResponse where T : EntityDTO;

public record PagedListDataResponse<T> : MessageResponse where T : EntityDTO
{
    public PagedListDataResponse(int totalDatas, int pageNumber, int pageSize, IEnumerable<T> datas)
    {
        TotalDatas = totalDatas;
        PageNumber = pageNumber;
        PageSize = pageSize;
        Datas = datas;
        TotalPage = (int)Math.Ceiling((decimal)totalDatas / pageSize);
        IsLastPage = pageNumber == TotalPage;
        IsFirstPage = pageNumber == 1;
    }
    public IEnumerable<T> Datas { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalDatas { get; set; }
    public int TotalPage { get; set; }
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }
}
