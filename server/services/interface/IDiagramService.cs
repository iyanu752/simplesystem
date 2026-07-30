using System;

namespace SimpleSystem.Server;

public interface IDiagramService
{
    Task<NodeDto> CreateNodeAsync (CreateNodeDto createNodeDto);
    Task<NodeDto?> MoveNodeAsync (MoveNodeDto moveNodeDto);
    Task<bool> DeleteNodeAsync (string nodeId);

    Task<EdgeDto> CreateEdgeAsync(CreateEdgeDto createEdgeDto);

    Task<bool> DeleteEdgeAsync(int id);

}
