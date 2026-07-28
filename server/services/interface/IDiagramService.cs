using System;

namespace SimpleSystem.Server;

public interface IDiagramService
{
    Task<NodeDto> CreateNodeAsync (CreateNodeDto createNodeDto);
    Task<NodeDto?> MoveNodeAsync (MoveNodeDto moveNodeDto, int id);
    Task<bool> DeleteNodeAsync (int id);

    Task<EdgeDto> CreateEdgeAsync(CreateEdgeDto createEdgeDto);

    Task<bool> DeleteEdgeAsync(int id);

}
